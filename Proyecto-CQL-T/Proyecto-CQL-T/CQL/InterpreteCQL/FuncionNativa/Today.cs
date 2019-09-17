using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using Proyecto_CQL_T.CQL.InterpreteCQL.Entorno;
using Proyecto_CQL_T.CQL.InterpreteCQL.ValorImplicito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.FuncionNativa
{
    class Today : Expresion
    {
        public Tipo getTipo(Entorno.Entorno ent)
        {
            return new Tipo("date");
        }

        public object getValor(Entorno.Entorno ent)
        {
            DateTime localDate = DateTime.Now;
            int year = localDate.Year;
            int mes = localDate.Month;
            int dia = localDate.Day;

            String fecha = year.ToString() + "-";
            if (mes < 10)
            {
                fecha += "0";
            }
            fecha += mes + "-";

            if (dia < 10)
            {
                fecha += "0";
            }
            fecha += dia;

            Date nuevo = new Date(fecha);

            return nuevo;
        }
    }
}
