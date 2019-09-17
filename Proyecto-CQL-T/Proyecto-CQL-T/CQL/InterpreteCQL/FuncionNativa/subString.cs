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
    class subString : Expresion
    {
        Expresion inicio;
        Expresion cantidad;
        public Object cadena;
        int fila;
        int columna;

        public subString(Expresion inicio, Expresion cantidad, int fila, int columna)
        {
            this.inicio = inicio;
            this.cantidad = cantidad;
            this.fila = fila;
            this.columna = columna;
        }

        public Tipo getTipo(Entorno.Entorno ent)
        {
            if (cadena is String)
                return new Tipo("string");
            return new Tipo("null");
        }

        public object getValor(Entorno.Entorno ent)
        {
            if (cadena is String)
            {
                object inci = inicio.getValor(ent);
                object canti = cantidad.getValor(ent);
                if (inci is int && canti is int)
                {
                    return ((String)cadena).Substring((int)inci, (int)canti);
                }
                else
                {
                    Estatico.errores.Add(new ErrorCQL("Semantico", "Error subString inicio y fin debe ser int ", this.fila, this.columna));
                }
            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Semantico", "Error subString debe de ser string ", this.fila, this.columna));
            }
            return null;
        }
    }
}
