using BE;
using DAL;
using INT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SER.Composite;

namespace BLL
{
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

        public bool EstaInicializado()
        {
            return new DigitoVerificadorVerticalDAL().GetAll().Count > 0;
        }

        public void Inicializar()
        {
            RecalcularDigitosVerificadores();
        }

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

            GastoDAL_755ME gastoDAL = new GastoDAL_755ME();
            List<GastoBE_755ME> gastos = gastoDAL.ObtenerTodos_755ME();
            foreach (GastoBE_755ME g in gastos)
            {
                g.DVH = CalcularDVH(g);
                gastoDAL.ActualizarDvh_755ME(g.IdGasto_755ME, g.DVH);
            }
            if (gastos.Count > 0)
            {
                ActualizarDVV("GASTO", gastos.Cast<IVerificable>().ToList());
            }

            UnidadFuncionalDAL_755ME ufDAL = new UnidadFuncionalDAL_755ME();
            List<UnidadFuncionalBE_755ME> unidades = ufDAL.ObtenerTodas_755ME();
            foreach (UnidadFuncionalBE_755ME u in unidades)
            {
                u.DVH = CalcularDVH(u);
                ufDAL.ActualizarDvh_755ME(u.IdUnidadFuncional_755ME, u.DVH);
            }
            if (unidades.Count > 0)
            {
                ActualizarDVV("UNIDAD_FUNCIONAL", unidades.Cast<IVerificable>().ToList());
            }

            ConsorcistaDAL_755ME consorcistaDAL = new ConsorcistaDAL_755ME();
            List<ConsorcistaBE_755ME> consorcistas = consorcistaDAL.ObtenerTodos_755ME();
            foreach (ConsorcistaBE_755ME c in consorcistas)
            {
                c.DVH = CalcularDVH(c);
                consorcistaDAL.ActualizarDvh_755ME(c.IdConsorcista_755ME, c.DVH);
            }
            if (consorcistas.Count > 0)
            {
                ActualizarDVV("CONSORCISTA", consorcistas.Cast<IVerificable>().ToList());
            }

            UnidadConsorcistaDAL_755ME unidadConsorcistaDAL = new UnidadConsorcistaDAL_755ME();
            List<UnidadConsorcistaBE_755ME> propietarios = unidadConsorcistaDAL.ObtenerTodos_755ME();
            foreach (UnidadConsorcistaBE_755ME uc in propietarios)
            {
                uc.DVH = CalcularDVH(uc);
                unidadConsorcistaDAL.ActualizarDvh_755ME(uc.IdUnidadFuncional_755ME, uc.IdConsorcista_755ME, uc.DVH);
            }
            if (propietarios.Count > 0)
            {
                ActualizarDVV("UNIDAD_CONSORCISTA", propietarios.Cast<IVerificable>().ToList());
            }

            ServicioDAL_755ME servicioDAL = new ServicioDAL_755ME();
            List<ServicioBE_755ME> servicios = servicioDAL.ObtenerTodos_755ME();
            foreach (ServicioBE_755ME s in servicios)
            {
                s.DVH = CalcularDVH(s);
                servicioDAL.ActualizarDvh_755ME(s.IdServicio_755ME, s.DVH);
            }
            if (servicios.Count > 0)
            {
                ActualizarDVV("SERVICIO", servicios.Cast<IVerificable>().ToList());
            }

            ProveedorDAL_755ME proveedorDAL = new ProveedorDAL_755ME();
            List<ProveedorBE_755ME> proveedores = proveedorDAL.ObtenerTodos_755ME();
            foreach (ProveedorBE_755ME p in proveedores)
            {
                p.DVH = CalcularDVH(p);
                proveedorDAL.ActualizarDvh_755ME(p.IdProveedor_755ME, p.DVH);
            }
            if (proveedores.Count > 0)
            {
                ActualizarDVV("PROVEEDOR", proveedores.Cast<IVerificable>().ToList());
            }

            BitacoraDAL bitacoraDAL = new BitacoraDAL();
            IList<Bitacora> registros = bitacoraDAL.GetAll();
            foreach (Bitacora b in registros)
            {
                b.DVH = CalcularDVH(b);
                bitacoraDAL.ActualizarDvh(b.Id, b.DVH);
            }
            if (registros.Count > 0)
            {
                ActualizarDVV("Bitacora", registros.Cast<IVerificable>().ToList());
            }

            TraductorDAL traductorDAL = new TraductorDAL();
            List<Idioma> idiomas = traductorDAL.ObtenerIdiomas().Cast<Idioma>().ToList();
            foreach (Idioma i in idiomas)
            {
                i.DVH = CalcularDVH(i);
                traductorDAL.ActualizarDvhIdioma(i.Id, i.DVH);
            }
            if (idiomas.Count > 0)
            {
                ActualizarDVV("Idioma", idiomas.Cast<IVerificable>().ToList());
            }

            List<Etiqueta> etiquetas = traductorDAL.ObtenerEtiquetas();
            foreach (Etiqueta e in etiquetas)
            {
                e.DVH = CalcularDVH(e);
                traductorDAL.ActualizarDvhEtiqueta(e.Id, e.DVH);
            }
            if (etiquetas.Count > 0)
            {
                ActualizarDVV("Etiqueta", etiquetas.Cast<IVerificable>().ToList());
            }

            List<Traduccion> traducciones = traductorDAL.ObtenerTodasLasTraducciones();
            foreach (Traduccion t in traducciones)
            {
                t.DVH = CalcularDVH(t);
                traductorDAL.ActualizarDvhTraduccion(t.EtiquetaId, t.IdiomaId, t.DVH);
            }
            if (traducciones.Count > 0)
            {
                ActualizarDVV("Traduccion", traducciones.Cast<IVerificable>().ToList());
            }

            PermisoDAL permisoDAL = new PermisoDAL();
            List<PermisoCompuesto> permisos = permisoDAL.ObtenerDiccionario().Values.Cast<PermisoCompuesto>().ToList();
            foreach (PermisoCompuesto p in permisos)
            {
                p.DVH = CalcularDVH(p);
                permisoDAL.ActualizarDvhPermiso(p.Id, p.DVH);
            }
            if (permisos.Count > 0)
            {
                ActualizarDVV("Permiso", permisos.Cast<IVerificable>().ToList());
            }

            List<FamiliaPatenteBE_755ME> familiaPatente = permisoDAL.ObtenerFamiliaPatente();
            foreach (FamiliaPatenteBE_755ME fp in familiaPatente)
            {
                fp.DVH = CalcularDVH(fp);
                permisoDAL.ActualizarDvhFamiliaPatente(fp.PadreId, fp.HijoId, fp.DVH);
            }
            if (familiaPatente.Count > 0)
            {
                ActualizarDVV("Familia_Patente", familiaPatente.Cast<IVerificable>().ToList());
            }

            List<UsuarioPermisoBE_755ME> usuarioPermiso = permisoDAL.ObtenerUsuarioPermiso();
            foreach (UsuarioPermisoBE_755ME up in usuarioPermiso)
            {
                up.DVH = CalcularDVH(up);
                permisoDAL.ActualizarDvhUsuarioPermiso(up.PermisoId, up.UsuarioId, up.DVH);
            }
            if (usuarioPermiso.Count > 0)
            {
                ActualizarDVV("Usuario_Permiso", usuarioPermiso.Cast<IVerificable>().ToList());
            }
        }

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
            IList<IVerificable> gastos = new GastoDAL_755ME().ObtenerTodos_755ME().Cast<IVerificable>().ToList();
            foreach (DiscrepanciaIntegridad d in VerificarIntegridad(gastos).Discrepancias)
            {
                resultado.Discrepancias.Add(d);
            }
            IList<IVerificable> unidades = new UnidadFuncionalDAL_755ME().ObtenerTodas_755ME().Cast<IVerificable>().ToList();
            foreach (DiscrepanciaIntegridad d in VerificarIntegridad(unidades).Discrepancias)
            {
                resultado.Discrepancias.Add(d);
            }
            IList<IVerificable> consorcistas = new ConsorcistaDAL_755ME().ObtenerTodos_755ME().Cast<IVerificable>().ToList();
            foreach (DiscrepanciaIntegridad d in VerificarIntegridad(consorcistas).Discrepancias)
            {
                resultado.Discrepancias.Add(d);
            }
            IList<IVerificable> propietarios = new UnidadConsorcistaDAL_755ME().ObtenerTodos_755ME().Cast<IVerificable>().ToList();
            foreach (DiscrepanciaIntegridad d in VerificarIntegridad(propietarios).Discrepancias)
            {
                resultado.Discrepancias.Add(d);
            }
            IList<IVerificable> servicios = new ServicioDAL_755ME().ObtenerTodos_755ME().Cast<IVerificable>().ToList();
            foreach (DiscrepanciaIntegridad d in VerificarIntegridad(servicios).Discrepancias)
            {
                resultado.Discrepancias.Add(d);
            }
            IList<IVerificable> proveedores = new ProveedorDAL_755ME().ObtenerTodos_755ME().Cast<IVerificable>().ToList();
            foreach (DiscrepanciaIntegridad d in VerificarIntegridad(proveedores).Discrepancias)
            {
                resultado.Discrepancias.Add(d);
            }
            IList<IVerificable> registros = new BitacoraDAL().GetAll().Cast<IVerificable>().ToList();
            foreach (DiscrepanciaIntegridad d in VerificarIntegridad(registros).Discrepancias)
            {
                resultado.Discrepancias.Add(d);
            }
            IList<IVerificable> idiomas = new TraductorDAL().ObtenerIdiomas().Cast<IVerificable>().ToList();
            foreach (DiscrepanciaIntegridad d in VerificarIntegridad(idiomas).Discrepancias)
            {
                resultado.Discrepancias.Add(d);
            }
            IList<IVerificable> etiquetas = new TraductorDAL().ObtenerEtiquetas().Cast<IVerificable>().ToList();
            foreach (DiscrepanciaIntegridad d in VerificarIntegridad(etiquetas).Discrepancias)
            {
                resultado.Discrepancias.Add(d);
            }
            IList<IVerificable> traducciones = new TraductorDAL().ObtenerTodasLasTraducciones().Cast<IVerificable>().ToList();
            foreach (DiscrepanciaIntegridad d in VerificarIntegridad(traducciones).Discrepancias)
            {
                resultado.Discrepancias.Add(d);
            }
            IList<IVerificable> permisos = new PermisoDAL().ObtenerDiccionario().Values.Cast<IVerificable>().ToList();
            foreach (DiscrepanciaIntegridad d in VerificarIntegridad(permisos).Discrepancias)
            {
                resultado.Discrepancias.Add(d);
            }
            IList<IVerificable> familiaPatente = new PermisoDAL().ObtenerFamiliaPatente().Cast<IVerificable>().ToList();
            foreach (DiscrepanciaIntegridad d in VerificarIntegridad(familiaPatente).Discrepancias)
            {
                resultado.Discrepancias.Add(d);
            }
            IList<IVerificable> usuarioPermiso = new PermisoDAL().ObtenerUsuarioPermiso().Cast<IVerificable>().ToList();
            foreach (DiscrepanciaIntegridad d in VerificarIntegridad(usuarioPermiso).Discrepancias)
            {
                resultado.Discrepancias.Add(d);
            }
            return resultado;
        }
    }
}
