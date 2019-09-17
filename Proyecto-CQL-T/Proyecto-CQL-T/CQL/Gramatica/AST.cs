using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.Gramatica
{
    class AST
    {
        public LinkedList<NodoAST> arbol;
        public AST(LinkedList<NodoAST> arbol)
        {
            this.arbol = arbol;
        }

    }
}
