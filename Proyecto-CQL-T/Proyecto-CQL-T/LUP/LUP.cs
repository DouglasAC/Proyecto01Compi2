using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.LUP
{
    public class LUP
    {
        public String user { get; set; }
        public String tipo { get; set; }
        public String data { get; set; }

        public LUP(String user, String tipo)
        {
            this.user = user;
            this.tipo = tipo;
            this.data = "";
        }
        public LUP(String user, String tipo, String data)
        {
            this.user = user;
            this.tipo = tipo;
            this.data = data;
        }
    }
}
