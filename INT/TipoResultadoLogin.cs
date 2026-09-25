using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INT
{
    public enum TipoResultadoLogin
    {
        UsuarioInvalido,
        PasswordInvalido,
        UsuarioValido,
        UsuarioBloqueado,
        UsuarioBaja,
        // credencial valida pero integridad fallida (usuario comun): no inicia sesion
        SistemaNoDisponible,
        // integridad fallida y admin global: sesion solo para resolver la integridad
        IntegridadRequiereResolucion,
    }
}
