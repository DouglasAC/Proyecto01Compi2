using Proyecto_CQL_T.CQL.AnalizadorCQL;
using Proyecto_CQL_T.CQL.Extras;
using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using Proyecto_CQL_T.CQL.InterpreteCQL.Entorno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.FuncionNativa
{
    class endWith : Expresion
    {
        public Object cadena;
        Expresion inicio;
        int fila;
        int columna;

        public endWith(Expresion inicio, int fila, int columna)
        {
            this.inicio = inicio;
            this.fila = fila;
            this.columna = columna;
        }

        public Tipo getTipo(Entorno.Entorno ent)
        {
            if (cadena is String)
            {
                return new Tipo("bool");
            }
            return new Tipo("null");
        }

        public object getValor(Entorno.Entorno ent)
        {
            if (cadena is String)
            {
                Object valor = inicio.getValor(ent);
                if (valor is String)
                {
                    return ((String)cadena).EndsWith((String)valor);
                }
                else
                {
                    Estatico.errores.Add(new ErrorCQL("Semantico", "Error endWith el fin debe de ser string ", this.fila, this.columna));
                }
            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Semantico", "Error endWith debe de ser string ", this.fila, this.columna));
            }
            return null;
        }

    }
}
