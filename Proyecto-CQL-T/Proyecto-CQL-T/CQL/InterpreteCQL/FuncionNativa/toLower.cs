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
    class toLower : Expresion
    {

        public Object cadena;
        int fila;
        int columna;
        public toLower(int fila, int columna)
        {
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
                return ((String)cadena).ToLower();
            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Semantico", "Error toLowerCase debe de ser string ", this.fila, this.columna));
            }
            return null;
        }
    }
}
