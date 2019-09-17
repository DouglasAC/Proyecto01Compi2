using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using Proyecto_CQL_T.CQL.InterpreteCQL.Colecciones;
using Proyecto_CQL_T.CQL.InterpreteCQL.Entorno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.ColeccionesFunciones
{
    class Contiene : Expresion
    {
        public Object coleccion;
        public Expresion valor;
        int fila;
        int columna;


        public Contiene(Expresion valor, int fila, int columna)
        {
            this.valor = valor;
            this.fila = fila;
            this.columna = columna;
        }

        public Tipo getTipo(Entorno.Entorno ent)
        {
            if (coleccion != null)
            {
                if (coleccion is Lista)
                {
                    return new Tipo("bool");
                }
                else if (coleccion is Map)
                {
                    return new Tipo("bool");
                }
                else if (coleccion is Set)
                {
                    return new Tipo("bool");
                }
            }


            return new Tipo("null");
        }

        public object getValor(Entorno.Entorno ent)
        {
            if (coleccion != null)
            {
                if (coleccion is Lista)
                {
                    Lista l = (Lista)coleccion;
                    Object val = valor.getValor(ent);
                    Tipo valtipo = valor.getTipo(ent);
                    return l.contiene(val, valtipo);
                }
                else if (coleccion is Map)
                {
                    Map m = (Map)coleccion;
                    Object val = valor.getValor(ent);
                    return m.contiene(val);
                }
                else if (coleccion is Set)
                {
                    Set l = (Set)coleccion;
                    Object val = valor.getValor(ent);
                    Tipo valtipo = valor.getTipo(ent);
                    return l.contiene(val, valtipo);
                }
            }
            return null;
        }
    }
}
