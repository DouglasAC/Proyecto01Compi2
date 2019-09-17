using Proyecto_CQL_T.CQL.AnalizadorCQL;
using Proyecto_CQL_T.CQL.Extras;
using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using Proyecto_CQL_T.CQL.InterpreteCQL.Entorno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.ValorImplicito
{
    class OperadorTernario : Expresion
    {
        Expresion condicion;
        Expresion expresion1;
        Expresion expresion2;
        int fila;
        int columna;

        public OperadorTernario(Expresion condicion, Expresion expresion1, Expresion expresion2, int fila, int columna)
        {
            this.condicion = condicion;
            this.expresion1 = expresion1;
            this.expresion2 = expresion2;
            this.fila = fila;
            this.columna = columna;
        }

        public Tipo getTipo(Entorno.Entorno ent)
        {
            Object valcon = this.condicion.getValor(ent);
            if (valcon is Boolean)
            {
                if ((bool)valcon)
                {
                    return expresion1.getTipo(ent);
                }
                else
                {
                    return expresion2.getTipo(ent);
                }
            }

            return new Tipo("null"); ;
        }

        public object getValor(Entorno.Entorno ent)
        {
            Object valcon = this.condicion.getValor(ent);
            if (valcon is Boolean)
            {
                if ((bool)valcon)
                {
                    return expresion1.getValor(ent);
                }
                else
                {
                    return expresion2.getValor(ent);
                }
            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Semantico", "La condicion del operador ternario debe ser de tipo boolean", this.fila, this.columna));
            }

            return null;
        }
    }
}
