using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using Proyecto_CQL_T.CQL.InterpreteCQL.Colecciones;
using Proyecto_CQL_T.CQL.InterpreteCQL.Entorno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.ColeccionesFunciones
{
    class Size : Expresion
    {
        public Object coleccion;

        int fila;
        int columna;

        public Size(int fila, int columna)
        {
            this.fila = fila;
            this.columna = columna;
        }

        public Tipo getTipo(Entorno.Entorno ent)
        {
            Object val = this.getValor(ent);
            if (val is int)
                return new Tipo("int");

            return new Tipo("null");
        }

        public object getValor(Entorno.Entorno ent)
        {
            if (coleccion != null)
            {
                if (coleccion is Lista)
                {
                    Lista l = (Lista)coleccion;
                    return l.tamano();
                }
                else if (coleccion is Map)
                {
                    Map l = (Map)coleccion;
                    return l.tamano();
                }
                else if (coleccion is Set)
                {
                    Set l = (Set)coleccion;
                    return l.tamano();
                }
            }
            return null;
        }
    }
}
