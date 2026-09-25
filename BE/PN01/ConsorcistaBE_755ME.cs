namespace BE
{
    public class ConsorcistaBE_755ME
    {
        public int IdConsorcista_755ME { get; set; }
        public string Nombre_755ME { get; set; } = "";
        public string Apellido_755ME { get; set; } = "";
        public string DNI_755ME { get; set; } = "";
        // no tiene DVH, no entra en la verificacion de integridad
        public bool Activo_755ME { get; set; } = true;
    }
}
