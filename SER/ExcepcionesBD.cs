using System;

namespace SER
{
    public class ExcepcionesBD : Exception
    {
        public ExcepcionesBD(string mensaje, Exception interna) : base(mensaje, interna)
        {
        }
    }
}
