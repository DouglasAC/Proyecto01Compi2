using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.Entorno
{
    class Tipo
    {
        public String tipo;
        public Tipo map_primitivo;
        public Tipo tipo_interno;

        public Tipo(String tipo)
        {
            this.tipo = tipo;
            this.tipo_interno = null;
            this.map_primitivo = null;
        }

        public Tipo(String tipo, Tipo map_primitivo, Tipo tipo_interno) : this(tipo)
        {
            this.map_primitivo = map_primitivo;
            this.tipo_interno = tipo_interno;
        }

        public Tipo(String tipo, Tipo tipo_interno) : this(tipo)
        {
            this.tipo_interno = tipo_interno;
        }
    }
}
