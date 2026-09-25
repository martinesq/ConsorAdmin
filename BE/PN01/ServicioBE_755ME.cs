namespace BE
{
    // sin DVH, solo la necesita EGRESO
    public class ServicioBE_755ME
    {
        public int IdServicio_755ME { get; set; }
        public int IdConsorcio_755ME { get; set; }
        public int? IdProveedor_755ME { get; set; }
        public string Categoria_755ME { get; set; } = "";
        public string Descripcion_755ME { get; set; } = "";
        public decimal Costo_755ME { get; set; }
        public string Estado_755ME { get; set; } = "";
    }
}
