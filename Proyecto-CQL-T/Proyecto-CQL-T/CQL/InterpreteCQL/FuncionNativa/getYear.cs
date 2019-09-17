using Proyecto_CQL_T.CQL.AnalizadorCQL;
using Proyecto_CQL_T.CQL.Extras;
using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using Proyecto_CQL_T.CQL.InterpreteCQL.Entorno;
using Proyecto_CQL_T.CQL.InterpreteCQL.ValorImplicito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.FuncionNativa
{
    class getYear : Expresion
    {

        public Object fecha;
        int fila;
        int columna;

        public getYear(int fila, int columna)
        {
            this.fila = fila;
            this.columna = columna;
        }

        public Tipo getTipo(Entorno.Entorno ent)
        {
            if (fecha is Date)
            {
                return new Tipo("int");
            }
            return new Tipo("null");
        }

        public object getValor(Entorno.Entorno ent)
        {
            if (fecha is Date)
            {
                return ((Date)fecha).year;
            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Semantico", "Error getYeat debe de ser date ", this.fila, this.columna));
            }
            return null;
        }
    }
}
