using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.CambioFlujo
{
    class Break : Instruccion
    {
        public object ejecutar(Entorno.Entorno ent)
        {
            return this;
        }
    }
}
