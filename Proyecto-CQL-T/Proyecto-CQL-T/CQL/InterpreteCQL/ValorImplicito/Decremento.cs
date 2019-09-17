using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using Proyecto_CQL_T.CQL.InterpreteCQL.Entorno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.ValorImplicito
{
    class Decremento : Expresion
    {
        String variable;
        int fila;
        int columna;

        public Decremento(String variable, int fila, int columna)
        {
            this.variable = variable.ToLower();
            this.fila = fila;
            this.columna = columna;
        }

        public Tipo getTipo(Entorno.Entorno ent)
        {
            Simbolo sm = ent.get(variable);
            Object valor = sm.valor;
            if (valor is int)
            {
                return new Tipo("int");
            }
            else if (valor is double)
            {
                return new Tipo("double");
            }
            return new Tipo("null");
        }

        public object getValor(Entorno.Entorno ent)
        {
            Simbolo sm = ent.get(variable);
            Object valor = sm.valor;
            if (valor is int)
            {
                int val = (int)valor;
                int valt = val;
                val = val - 1;
                sm.valor = val;
                return valt;
            }
            else if (valor is double)
            {
                double val = (double)valor;
                double valt = val;
                val = val - 1.0;
                sm.valor = val;
                return valt;
            }
            return null;
        }
    }
}
