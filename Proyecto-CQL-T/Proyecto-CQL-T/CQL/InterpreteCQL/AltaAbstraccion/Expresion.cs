using Proyecto_CQL_T.CQL.InterpreteCQL.Entorno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion
{
    interface Expresion : NodoAST
    {
        Object getValor(Entorno.Entorno ent);

        Tipo getTipo(Entorno.Entorno ent);
    }
}
