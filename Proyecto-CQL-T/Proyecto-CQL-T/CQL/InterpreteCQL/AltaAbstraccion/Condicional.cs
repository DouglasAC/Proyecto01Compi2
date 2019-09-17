using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion
{
    class Condicional
    {
        public LinkedList<NodoAST> instrucciones { get; set; }

        public Expresion condicion { get; set; }

        public Condicional(Expresion condicion, LinkedList<NodoAST> instrucciones)
        {
            this.instrucciones = instrucciones;
            this.condicion = condicion;
        }
        public LinkedList<NodoAST> getIntrucciones()
        {
            return instrucciones;
        }

        public void setIntrucciones(LinkedList<NodoAST> instrucciones)
        {
            this.instrucciones = instrucciones;
        }

        public Expresion getCondicion()
        {
            return condicion;
        }

        public void setCondicion(Expresion condicion)
        {
            this.condicion = condicion;
        }
    }
}
