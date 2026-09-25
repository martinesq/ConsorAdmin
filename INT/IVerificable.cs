using System;

namespace INT
{
    // entidades cubiertas por los digitos verificadores
    public interface IVerificable : IEntity
    {
        int DVH { get; set; }
        string NombreTabla { get; }
        // orden fijo de atributos para el DVH (sin Id, Estado ni DVH)
        string[] AtributosVerificables { get; }
    }
}
