using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;

namespace SER
{
    // exportador generico de PDF
    public class ExportadorPdfService
    {
        private const double Margen = 30;

        static ExportadorPdfService()
        {
            try
            {
                GlobalFontSettings.UseWindowsFontsUnderWindows = true;
            }
            catch (InvalidOperationException)
            {
            }
        }

        public void ExportarTabla(string titulo, List<string> encabezados, List<List<string>> filas, string ruta)
        {
            PdfDocument documento = new PdfDocument();
            documento.Info.Title = titulo;
            AgregarTabla(documento, titulo, encabezados, filas);
            documento.Save(ruta);
        }

        public void AgregarTabla(PdfDocument documento, string titulo, List<string> encabezados, List<List<string>> filas)
        {
            XFont fuenteTitulo = new XFont("Arial", 14, XFontStyleEx.Bold);
            XFont fuenteEncabezado = new XFont("Arial", 9, XFontStyleEx.Bold);
            XFont fuenteCelda = new XFont("Arial", 9, XFontStyleEx.Regular);
            double altoFila = 16;

            PdfPage pagina = documento.AddPage();
            pagina.Size = PdfSharp.PageSize.A4;
            pagina.Orientation = PdfSharp.PageOrientation.Landscape;
            XGraphics grafico = XGraphics.FromPdfPage(pagina);
            double anchoUtil = pagina.Width.Point - 2 * Margen;
            double anchoColumna = anchoUtil / Math.Max(1, encabezados.Count);
            double y = Margen;

            grafico.DrawString(titulo, fuenteTitulo, XBrushes.Black, new XPoint(Margen, y + 10));
            y += 30;
            y += DibujarFila(grafico, encabezados, fuenteEncabezado, y, anchoColumna, altoFila, true);

            foreach (List<string> fila in filas)
            {
                if (y + AltoFila_755ME(grafico, fila, fuenteCelda, anchoColumna, altoFila) > pagina.Height.Point - Margen)
                {
                    grafico.Dispose();
                    pagina = documento.AddPage();
                    pagina.Size = PdfSharp.PageSize.A4;
                    pagina.Orientation = PdfSharp.PageOrientation.Landscape;
                    grafico = XGraphics.FromPdfPage(pagina);
                    y = Margen;
                    y += DibujarFila(grafico, encabezados, fuenteEncabezado, y, anchoColumna, altoFila, true);
                }
                y += DibujarFila(grafico, fila, fuenteCelda, y, anchoColumna, altoFila, false);
            }
            grafico.Dispose();
        }

        // devuelve el alto que ocupo la fila: crece si algun texto no entra en una linea
        private static double DibujarFila(XGraphics grafico, List<string> celdas, XFont fuente, double y, double anchoColumna, double altoMinimo, bool encabezado)
        {
            double alto = AltoFila_755ME(grafico, celdas, fuente, anchoColumna, altoMinimo);
            double altoLinea = fuente.GetHeight();
            for (int i = 0; i < celdas.Count; i++)
            {
                XRect rect = new XRect(Margen + i * anchoColumna, y, anchoColumna, alto);
                if (encabezado)
                {
                    grafico.DrawRectangle(XBrushes.LightGray, rect);
                }
                grafico.DrawRectangle(XPens.Gray, rect);
                List<string> lineas = PartirTexto_755ME(grafico, celdas[i] ?? "", fuente, anchoColumna - 4);
                double inicio = y + (alto - lineas.Count * altoLinea) / 2;
                for (int l = 0; l < lineas.Count; l++)
                {
                    grafico.DrawString(lineas[l], fuente, XBrushes.Black,
                        new XRect(rect.X + 2, inicio + l * altoLinea, rect.Width - 4, altoLinea), XStringFormats.CenterLeft);
                }
            }
            return alto;
        }

        private static double AltoFila_755ME(XGraphics grafico, List<string> celdas, XFont fuente, double anchoColumna, double altoMinimo)
        {
            int lineas = celdas.Max(c => PartirTexto_755ME(grafico, c ?? "", fuente, anchoColumna - 4).Count);
            return Math.Max(altoMinimo, lineas * fuente.GetHeight() + 4);
        }

        // corta por palabras para que el texto no se pise con la celda de al lado
        private static List<string> PartirTexto_755ME(XGraphics grafico, string texto, XFont fuente, double ancho)
        {
            List<string> lineas = new List<string>();
            string actual = "";
            foreach (string palabra in texto.Split(' '))
            {
                string prueba = actual == "" ? palabra : actual + " " + palabra;
                if (actual != "" && grafico.MeasureString(prueba, fuente).Width > ancho)
                {
                    lineas.Add(actual);
                    actual = palabra;
                }
                else
                {
                    actual = prueba;
                }
            }
            lineas.Add(actual);
            return lineas;
        }
    }
}
