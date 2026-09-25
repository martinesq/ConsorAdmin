using System.Runtime.CompilerServices;
using BLL;
using SER;

namespace AppBase
{
    // ayuda para los labels que muestran un valor (ej. "Saldo: 100"): el texto fijo se traduce con la etiqueta del Tag
    internal static class IdiomaUI_755ME
    {
        private class ValorLabel
        {
            public string Prefijo = "";
            public Func<string>? Valor;
        }

        private static readonly ConditionalWeakTable<Label, ValorLabel> _labels = new ConditionalWeakTable<Label, ValorLabel>();

        // traduccion de una etiqueta en el idioma actual (si no existe devuelve el texto por defecto)
        public static string Texto(string etiqueta, string porDefecto)
        {
            var traducciones = new TraductorBLL().ObtenerTraduccion(SessionManager.Idioma);
            return traducciones.ContainsKey(etiqueta) ? traducciones[etiqueta].Texto : porDefecto;
        }

        // deja "texto fijo + valor" en el label; con valor null queda solo el texto fijo
        public static void PonerValor(Label label, Func<string>? valor)
        {
            ValorLabel v = _labels.GetOrCreateValue(label);
            if (v.Prefijo == "") v.Prefijo = label.Text;
            v.Valor = valor;
            Aplicar(label, v);
        }

        // se llama despues de traducir el formulario, que deja los labels solo con el texto fijo
        public static void Refrescar(Control raiz)
        {
            foreach (Control c in raiz.Controls)
            {
                if (c is Label label && _labels.TryGetValue(label, out ValorLabel? v))
                {
                    Aplicar(label, v);
                }
                Refrescar(c);
            }
        }

        private static void Aplicar(Label label, ValorLabel v)
        {
            string prefijo = label.Tag is string etiqueta ? Texto(etiqueta, v.Prefijo) : v.Prefijo;
            label.Text = v.Valor == null ? prefijo : prefijo + " " + v.Valor();
        }
    }
}
