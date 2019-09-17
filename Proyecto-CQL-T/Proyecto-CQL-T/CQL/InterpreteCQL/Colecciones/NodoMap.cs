using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.Colecciones
{
    class NodoMap
    {
        public object clave;
        public object valor;

        public NodoMap(object clave, object valor)
        {
            this.clave = clave;
            this.valor = valor;
        }
    }
}
