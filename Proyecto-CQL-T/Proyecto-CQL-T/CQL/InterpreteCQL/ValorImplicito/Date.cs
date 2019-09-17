using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.ValorImplicito
{
    class Date : IComparable
    {
        public DateTime date;
        public int year { get; }
        public int mes { get; }
        public int dia { get; }

        public Date(String fecha)
        {
            date = DateTime.ParseExact(fecha, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            this.year = date.Year;
            this.mes = date.Month;
            this.dia = date.Day;
        }

        public override string ToString()
        {
            String cad = this.year + "-";
            if (this.mes < 10)
            {
                cad += "0";
            }
            cad += this.mes + "-";
            if (dia < 10)
            {
                cad += "0";
            }
            cad += this.dia;

            return cad;
        }


        public int CompareTo(object obj)
        {
            if (obj is Date)
            {
                return this.date.CompareTo(((Date)obj).date);
            }
            return 0;
        }
    }
}
