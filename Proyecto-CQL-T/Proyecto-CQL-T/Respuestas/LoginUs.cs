using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.Respuestas
{
    public class LoginUs
    {
        public LoginUs(string respuesta)
        {
            this.respuesta = respuesta;
        }
        public string respuesta { get; set; }

    }
}
