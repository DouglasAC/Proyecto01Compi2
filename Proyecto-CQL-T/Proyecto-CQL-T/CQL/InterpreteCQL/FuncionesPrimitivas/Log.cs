using Proyecto_CQL_T.CQL.Extras;
using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.FuncionesPrimitivas
{
    class Log : Instruccion
    {
        private Expresion expresion;
        int fila;
        int columna;

        public Log(Expresion expresion, int fila, int columna)
        {
            this.expresion = expresion;
            this.fila = fila;
            this.columna = columna;
        }

        public object ejecutar(Entorno.Entorno ent)
        {
            Object ob = expresion.getValor(ent);
            if (ob != null)
            {
                Estatico.agregarMensaje("[+MESSAGE]\n" + ob.ToString() + "\n[-MESSAGE]\n");
            }
            return null;
        }
    }
}
