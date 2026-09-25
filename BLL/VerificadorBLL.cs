using BE;
using DAL;
using INT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BLL
{
    // calcula y guarda los digitos verificadores (DVH por fila, DVV por tabla)
    // para sumar una entidad: IVerificable en el BE, columna DVH y agregarla en VerificarIntegridadSistema()
    public class VerificadorBLL
    {
        // modulo primo fijo
        private const int MODULO = 97;

        public int CalcularDVH(IVerificable entidad)
        {
            long suma = 0;
            string[] atributos = entidad.AtributosVerificables;
            for (int posAtributo = 1; posAtributo <= atributos.Length; posAtributo++)
            {
                PropertyInfo prop = entidad.GetType().GetProperty(atributos[posAtributo - 1]);
                string valor = prop.GetValue(entidad)?.ToString() ?? "";
                for (int posCaracter = 1; posCaracter <= valor.Length; posCaracter++)
                {
                    suma += (long)valor[posCaracter - 1] * posCaracter * posAtributo;
                }
            }
            return (int)(suma % MODULO);
        }

        public void ActualizarDVH(IVerificable entidad)
        {
            entidad.DVH = CalcularDVH(entidad);
        }

        public bool VerificarDVH(IVerificable entidad)
        {
            return entidad.DVH == CalcularDVH(entidad);
        }

        // el DVV se calcula por tabla: suma el DVH de cada fila ponderado por su posicion
        public int CalcularDVV(IList<IVerificable> filas)
        {
            long suma = 0;
            IList<IVerificable> ordenadas = filas.OrderBy(f => f.Id).ToList();
            for (int posFila = 1; posFila <= ordenadas.Count; posFila++)
            {
                suma += (long)CalcularDVH(ordenadas[posFila - 1]) * posFila;
            }
            return (int)(suma % MODULO);
        }

        public void ActualizarDVV(string tabla, IList<IVerificable> filas)
        {
            int valor = CalcularDVV(filas);
            DigitoVerificadorVerticalDAL dal = new DigitoVerificadorVerticalDAL();
            DigitoVerificadorVertical dvv = dal.ObtenerPorTabla(tabla);
            if (dvv == null)
            {
                dvv = new DigitoVerificadorVertical();
                dvv.Tabla = tabla;
                dvv.Estado = TipoEstado.Agregado;
            }
            else
            {
                dvv.Estado = TipoEstado.Modificado;
            }
            dvv.Valor = valor;
            dvv.FechaCalculo = DateTime.Now;
            dal.Save(dvv);
        }

        public ResultadoIntegridad VerificarIntegridad(IList<IVerificable> filas)
        {
            ResultadoIntegridad resultado = new ResultadoIntegridad();
            if (filas.Count == 0) return resultado;
            string tabla = filas[0].NombreTabla;
            foreach (IVerificable fila in filas)
            {
                if (!VerificarDVH(fila))
                {
                    resultado.Discrepancias.Add(new DiscrepanciaIntegridad { Tabla = tabla, FilaId = fila.Id, ErrorHorizontal = true });
                }
            }
            DigitoVerificadorVertical dvvAlmacenado = new DigitoVerificadorVerticalDAL().ObtenerPorTabla(tabla);
            int dvvCalculado = CalcularDVV(filas);
            if (dvvAlmacenado == null || dvvAlmacenado.Valor != dvvCalculado)
            {
                resultado.Discrepancias.Add(new DiscrepanciaIntegridad { Tabla = tabla, FilaId = null, ErrorVertical = true });
            }
            return resultado;
        }

        // dice si ya hay linea de base calculada (algun DVV guardado)
        public bool EstaInicializado()
        {
            return new DigitoVerificadorVerticalDAL().GetAll().Count > 0;
        }

        // calcula la linea de base la primera vez; no sirve para reparar discrepancias (eso lo hace el admin en ResolucionIntegridadBLL)
        public void Inicializar()
        {
            RecalcularDigitosVerificadores();
        }

        // recalcula y guarda el DVH y el DVV con los datos actuales, sin tocar los datos
        public void RecalcularDigitosVerificadores()
        {
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            IList<Usuario> usuarios = usuarioDAL.GetAll();
            foreach (Usuario u in usuarios)
            {
                u.DVH = CalcularDVH(u);
                usuarioDAL.ActualizarDVH(u.Id, u.DVH);
            }
            if (usuarios.Count > 0)
            {
                ActualizarDVV("Usuario", usuarios.Cast<IVerificable>().ToList());
            }

            // PN01: CONSORCIO, EXPENSA, PAGO, ORDEN_PAGO y EGRESO (UNIDAD_FUNCIONAL no tiene DVH)
            ConsorcioDAL_755ME consorcioDAL = new ConsorcioDAL_755ME();
            List<ConsorcioBE_755ME> consorcios = consorcioDAL.ObtenerTodos_755ME();
            foreach (ConsorcioBE_755ME c in consorcios)
            {
                c.DVH = CalcularDVH(c);
                consorcioDAL.ActualizarDvh_755ME(c.IdConsorcio_755ME, c.DVH);
            }
            if (consorcios.Count > 0)
            {
                ActualizarDVV("CONSORCIO", consorcios.Cast<IVerificable>().ToList());
            }

            ExpensaDAL_755ME expensaDAL = new ExpensaDAL_755ME();
            List<ExpensaBE_755ME> expensas = expensaDAL.ObtenerTodas_755ME();
            foreach (ExpensaBE_755ME e in expensas)
            {
                e.DVH = CalcularDVH(e);
                expensaDAL.ActualizarDvh_755ME(e.IdExpensa_755ME, e.DVH);
            }
            if (expensas.Count > 0)
            {
                ActualizarDVV("EXPENSA", expensas.Cast<IVerificable>().ToList());
            }

            PagoDAL_755ME pagoDAL = new PagoDAL_755ME();
            List<PagoBE_755ME> pagos = pagoDAL.ObtenerTodos_755ME();
            foreach (PagoBE_755ME p in pagos)
            {
                p.DVH = CalcularDVH(p);
                pagoDAL.ActualizarDvh_755ME(p.IdPago_755ME, p.DVH);
            }
            if (pagos.Count > 0)
            {
                ActualizarDVV("PAGO", pagos.Cast<IVerificable>().ToList());
            }

            OrdenPagoDAL_755ME ordenPagoDAL = new OrdenPagoDAL_755ME();
            List<OrdenDePagoBE_755ME> ordenes = ordenPagoDAL.ObtenerTodas_755ME();
            foreach (OrdenDePagoBE_755ME o in ordenes)
            {
                o.DVH = CalcularDVH(o);
                ordenPagoDAL.ActualizarDvh_755ME(o.IdOrdenPago_755ME, o.DVH);
            }
            if (ordenes.Count > 0)
            {
                ActualizarDVV("ORDEN_PAGO", ordenes.Cast<IVerificable>().ToList());
            }

            EgresoDAL_755ME egresoDAL = new EgresoDAL_755ME();
            List<EgresoBE_755ME> egresos = egresoDAL.ObtenerTodos_755ME();
            foreach (EgresoBE_755ME g in egresos)
            {
                g.DVH = CalcularDVH(g);
                egresoDAL.ActualizarDvh_755ME(g.IdEgreso_755ME, g.DVH);
            }
            if (egresos.Count > 0)
            {
                ActualizarDVV("EGRESO", egresos.Cast<IVerificable>().ToList());
            }
        }

        // verificacion de integridad: se llama en cada login y al restaurar o recalcular
        public ResultadoIntegridad VerificarIntegridadSistema()
        {
            ResultadoIntegridad resultado = new ResultadoIntegridad();
            IList<IVerificable> usuarios = new UsuarioDAL().GetAll().Cast<IVerificable>().ToList();
            foreach (DiscrepanciaIntegridad d in VerificarIntegridad(usuarios).Discrepancias)
            {
                resultado.Discrepancias.Add(d);
            }
            IList<IVerificable> consorcios = new ConsorcioDAL_755ME().ObtenerTodos_755ME().Cast<IVerificable>().ToList();
            foreach (DiscrepanciaIntegridad d in VerificarIntegridad(consorcios).Discrepancias)
            {
                resultado.Discrepancias.Add(d);
            }
            IList<IVerificable> expensas = new ExpensaDAL_755ME().ObtenerTodas_755ME().Cast<IVerificable>().ToList();
            foreach (DiscrepanciaIntegridad d in VerificarIntegridad(expensas).Discrepancias)
            {
                resultado.Discrepancias.Add(d);
            }
            IList<IVerificable> pagos = new PagoDAL_755ME().ObtenerTodos_755ME().Cast<IVerificable>().ToList();
            foreach (DiscrepanciaIntegridad d in VerificarIntegridad(pagos).Discrepancias)
            {
                resultado.Discrepancias.Add(d);
            }
            IList<IVerificable> ordenes = new OrdenPagoDAL_755ME().ObtenerTodas_755ME().Cast<IVerificable>().ToList();
            foreach (DiscrepanciaIntegridad d in VerificarIntegridad(ordenes).Discrepancias)
            {
                resultado.Discrepancias.Add(d);
            }
            IList<IVerificable> egresos = new EgresoDAL_755ME().ObtenerTodos_755ME().Cast<IVerificable>().ToList();
            foreach (DiscrepanciaIntegridad d in VerificarIntegridad(egresos).Discrepancias)
            {
                resultado.Discrepancias.Add(d);
            }
            return resultado;
        }
    }
}
