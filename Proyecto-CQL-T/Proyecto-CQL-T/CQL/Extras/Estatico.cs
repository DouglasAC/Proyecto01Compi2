using Proyecto_CQL_T.CQL.AnalizadorCQL;
using Proyecto_CQL_T.CQL.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.Extras
{
    class Estatico
    {
        public static List<ErrorCQL> errores;
        public static List<String> mensajes;
        public static Servidor servidor;
        public static Usuario actualUsuario;
        public static BaseDatos actualBase;
        public static int NumeroErroes()
        {
            return errores.Count();
        }

        public static Boolean paraEjecucionPorCantidadErrores()
        {
            if (NumeroErroes() > 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void agregarMensaje(String mensaje)
        {
            mensajes.Add(mensaje);
        }
    }
}
