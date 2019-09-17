using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using Proyecto_CQL_T.CQL.InterpreteCQL.Colecciones;
using Proyecto_CQL_T.CQL.InterpreteCQL.Entorno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.ColeccionesFunciones
{
    class Vaciar : Expresion
    {

        public Object coleccion;

        int fila;
        int columna;

        public Vaciar(int fila, int columna)
        {
            this.fila = fila;
            this.columna = columna;
        }

        public Tipo getTipo(Entorno.Entorno ent)
        {
            return new Tipo("null");
        }

        public object getValor(Entorno.Entorno ent)
        {
            if (coleccion != null)
            {
                if (coleccion is Lista)
                {
                    Lista l = (Lista)coleccion;
                    l.vaciar();
                }
                else if (coleccion is Map)
                {
                    Map l = (Map)coleccion;
                    l.vaciar();
                }
                else if (coleccion is Set)
                {
                    Set l = (Set)coleccion;
                    l.vaciar();
                }
            }
            return null;
        }
    }
}
