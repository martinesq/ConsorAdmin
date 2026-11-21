namespace SER
{
    // los temas son archivos html en Ayuda\<idioma>\<clave>.html, junto al .exe
    public class AyudaService_755ME
    {
        private const string IdiomaPorDefecto_755ME = "es";
        private const string Indice_755ME = "indice";
        private readonly string _carpeta = Path.Combine(AppContext.BaseDirectory, "Ayuda");

        // si el tema no esta en el idioma pedido se usa el español, y si tampoco esta, el indice
        public string ObtenerRutaTema_755ME(string clave, string idioma)
        {
            string ruta = Ruta_755ME(clave, idioma);
            if (File.Exists(ruta)) return ruta;
            ruta = Ruta_755ME(clave, IdiomaPorDefecto_755ME);
            if (File.Exists(ruta)) return ruta;
            ruta = Ruta_755ME(Indice_755ME, idioma);
            return File.Exists(ruta) ? ruta : Ruta_755ME(Indice_755ME, IdiomaPorDefecto_755ME);
        }

        // claves de los temas disponibles, con el indice primero
        public List<string> ObtenerTemas_755ME(string idioma)
        {
            string carpeta = Path.Combine(_carpeta, idioma);
            if (!Directory.Exists(carpeta)) carpeta = Path.Combine(_carpeta, IdiomaPorDefecto_755ME);
            if (!Directory.Exists(carpeta)) return new List<string>();
            return Directory.GetFiles(carpeta, "*.html")
                .Select(a => Path.GetFileNameWithoutExtension(a))
                .OrderBy(c => c == Indice_755ME ? 0 : 1).ThenBy(c => c)
                .ToList();
        }

        private string Ruta_755ME(string clave, string idioma)
        {
            return Path.Combine(_carpeta, idioma, clave + ".html");
        }
    }
}
