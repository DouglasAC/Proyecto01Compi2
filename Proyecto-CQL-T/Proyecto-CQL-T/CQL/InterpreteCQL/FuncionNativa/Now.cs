using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using Proyecto_CQL_T.CQL.InterpreteCQL.Entorno;
using Proyecto_CQL_T.CQL.InterpreteCQL.ValorImplicito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.FuncionNativa
{
    class Now : Expresion
    {

        public Tipo getTipo(Entorno.Entorno ent)
        {
            return new Tipo("time");
        }

        public object getValor(Entorno.Entorno ent)
        {
            DateTime localDate = DateTime.Now;
            int hora = localDate.Hour;
            int minutos = localDate.Minute;
            int segundos = localDate.Second;

            String hora_2 = hora.ToString() + ":";
            if (minutos < 10)
            {
                hora_2 += "0";
            }
            hora_2 += minutos + ":";

            if (segundos < 10)
            {
                hora_2 += "0";
            }
            hora_2 += segundos;

            Tiempo nuevo = new Tiempo(hora_2);

            return nuevo;
        }
    }
}
