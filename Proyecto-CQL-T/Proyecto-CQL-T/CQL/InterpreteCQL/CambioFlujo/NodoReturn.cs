using Proyecto_CQL_T.CQL.InterpreteCQL.Entorno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.CambioFlujo
{
    class NodoReturn
    {
        Tipo tipo;
        Object valor;
        public NodoReturn(Tipo tipo, object valor)
        {
            this.tipo = tipo;
            this.valor = valor;
        }
    }
}
