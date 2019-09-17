using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.ControldeFlujo
{
    class Case
    {
        Expresion expresion;
        LinkedList<NodoAST> sentencias;

        public Case(Expresion expresion, LinkedList<NodoAST> sentencias)
        {
            this.expresion = expresion;
            this.sentencias = sentencias;
        }

        public Expresion getExpresion()
        {
            return expresion;
        }

        public void setExpresion(Expresion expresion)
        {
            this.expresion = expresion;
        }

        public LinkedList<NodoAST> getSentencias()
        {
            return sentencias;
        }

        public void setSentencias(LinkedList<NodoAST> sentencias)
        {
            this.sentencias = sentencias;
        }
    }
}
