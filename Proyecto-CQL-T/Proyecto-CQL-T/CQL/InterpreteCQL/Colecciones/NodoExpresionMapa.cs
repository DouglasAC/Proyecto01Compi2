using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.Colecciones
{
    class NodoExpresionMapa
    {
        public Expresion clava;
        public Expresion valor;

        public NodoExpresionMapa(Expresion clava, Expresion valor)
        {
            this.clava = clava;
            this.valor = valor;
        }
    }
}
