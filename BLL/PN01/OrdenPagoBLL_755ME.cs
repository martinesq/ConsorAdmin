using BE;
using DAL;

namespace BLL
{
    public class OrdenPagoBLL_755ME
    {
        private readonly ConsorcioDAL_755ME _consorcioDAL = new ConsorcioDAL_755ME();
        private readonly ExpensaDAL_755ME _expensaDAL = new ExpensaDAL_755ME();
        private readonly OrdenPagoDAL_755ME _ordenDAL = new OrdenPagoDAL_755ME();
        private readonly UnidadFuncionalDAL_755ME _ufDAL = new UnidadFuncionalDAL_755ME();
        private readonly VerificadorBLL _verificador = new VerificadorBLL();
        private readonly BitacoraBLL _bitacora = new BitacoraBLL();

        // lo deja ArmarTalon_755ME para GenerarOrdenPago_755ME
        private string _propietarioSnapshotEnCurso = "";

        public List<ConsorcioBE_755ME> ObtenerConsorciosAsignados_755ME()
        {
            return _consorcioDAL.ObtenerConsorciosConUnidadesActivas_755ME();
        }

        public List<UnidadFuncionalBE_755ME> ObtenerUnidadesPendientesDeOrden_755ME(int idConsorcio)
        {
            return _expensaDAL.ObtenerUnidadesConExpensaSinOrden_755ME(idConsorcio);
        }

        public OrdenDePagoBE_755ME GenerarOrdenPago_755ME(int idUF)
        {
            ExpensaBE_755ME expensa = _expensaDAL.ObtenerExpensaLiquidada_755ME(idUF);
            ConsorcistaBE_755ME propietario = _ufDAL.ObtenerDatosPropietario_755ME(idUF);
            UnidadFuncionalBE_755ME uf = new UnidadFuncionalBE_755ME { IdUnidadFuncional_755ME = idUF };
            ArmarTalon_755ME(uf, propietario);

            OrdenDePagoBE_755ME orden = new OrdenDePagoBE_755ME
            {
                IdExpensa_755ME = expensa.IdExpensa_755ME,
                NumeroOrden_755ME = _ordenDAL.ObtenerProximoNumero_755ME(),
                Monto_755ME = expensa.Monto_755ME,
                FechaVencimiento_755ME = expensa.FechaVencimiento_755ME,
                Estado_755ME = "Vigente",
                PropietarioSnapshot_755ME = _propietarioSnapshotEnCurso
            };
            orden.DVH = _verificador.CalcularDVH(orden);
            _ordenDAL.GuardarOrdenPago_755ME(orden, orden.DVH);
            // recalcula el DVV de la tabla
            _verificador.ActualizarDVV("ORDEN_PAGO", _ordenDAL.ObtenerTodas_755ME().Cast<INT.IVerificable>().ToList());
            _bitacora.RegistrarDeUsuarioActual("Generar orden de pago", orden.IdOrdenPago_755ME.ToString(),
                "Expensa " + expensa.IdExpensa_755ME + ", monto " + expensa.Monto_755ME.ToString("F2"));
            return orden;
        }

        // copia el nombre del propietario al momento de emitir
        private void ArmarTalon_755ME(UnidadFuncionalBE_755ME uf, ConsorcistaBE_755ME propietario)
        {
            _propietarioSnapshotEnCurso = propietario.Nombre_755ME + " " + propietario.Apellido_755ME;
        }
    }
}
