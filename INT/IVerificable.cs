using System;

namespace INT
{
    // entidades cubiertas por los digitos verificadores
    public interface IVerificable : IEntity
    {
        int DVH { get; set; }
        string NombreTabla { get; }
        string[] AtributosVerificables { get; }
    }
}
