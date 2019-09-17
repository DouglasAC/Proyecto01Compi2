using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion
{
    interface Instruccion : NodoAST
    {
        object ejecutar(InterpreteCQL.Entorno.Entorno ent);
    }
}
