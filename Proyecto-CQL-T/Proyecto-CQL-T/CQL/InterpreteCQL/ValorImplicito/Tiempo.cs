using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.ValorImplicito
{
    class Tiempo : IComparable
    {

        public DateTime tiempo;
        public int hora { get; }
        public int minutos { get; }
        public int segundos { get; }

        public Tiempo(String tiempo)
        {
            this.tiempo = DateTime.ParseExact(tiempo, "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            this.hora = this.tiempo.Hour;
            this.minutos = this.tiempo.Minute;
            this.segundos = this.tiempo.Second;
        }

        public Tiempo(DateTime tiempo)
        {
            this.tiempo = tiempo;
            this.hora = this.tiempo.Hour;
            this.minutos = this.tiempo.Minute;
            this.segundos = this.tiempo.Second;
        }

        public override string ToString()
        {
            String cad = "";
            if (hora < 10)
            {
                cad += "0";
            }
            cad += this.hora + ":";
            if (minutos < 10)
            {
                cad += "0";
            }
            cad += this.minutos + ":";
            if (segundos < 10)
            {
                cad += "0";
            }
            cad += this.segundos;
            return cad;
        }

        public int CompareTo(object obj)
        {
            if (obj is Tiempo)
            {
                return this.tiempo.CompareTo(((Tiempo)obj).tiempo);
            }
            return 0;
        }
    }
}
