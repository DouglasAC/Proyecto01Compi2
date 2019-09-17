using Proyecto_CQL_T.CQL.AnalizadorCQL;
using Proyecto_CQL_T.CQL.Extras;
using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using Proyecto_CQL_T.CQL.InterpreteCQL.Colecciones;
using Proyecto_CQL_T.CQL.InterpreteCQL.Entorno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.ColeccionesFunciones
{
    class Remover : Expresion
    {

        public Object coleccion;
        public Expresion valor;
        int fila;
        int columna;

        public Remover(Expresion valor, int fila, int columna)
        {
            this.valor = valor;
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
                    Object val = valor.getValor(ent);
                    if (val is int)
                    {
                        Boolean removio = l.remove((int)val);
                        if (!removio)
                        {
                            Estatico.errores.Add(new ErrorCQL("Semantico", "Error no se puedo remover ", this.fila, this.columna));
                        }
                    }
                    else
                    {
                        Estatico.errores.Add(new ErrorCQL("Semantico", "Error el indice debe de ser int ", this.fila, this.columna));
                    }
                }
                else if (coleccion is Map)
                {
                    Map l = (Map)coleccion;
                    Object val = valor.getValor(ent);
                    Tipo clave = valor.getTipo(ent);
                    Boolean removio = l.remove(clave, val);
                    if (!removio)
                    {
                        Estatico.errores.Add(new ErrorCQL("Semantico", "Error no se puedo remover ", this.fila, this.columna));
                    }
                }
                if (coleccion is Set)
                {
                    Set l = (Set)coleccion;
                    Object val = valor.getValor(ent);
                    if (val is int)
                    {
                        Boolean removio = l.remove((int)val);
                        if (!removio)
                        {
                            Estatico.errores.Add(new ErrorCQL("Semantico", "Error no se puedo remover ", this.fila, this.columna));
                        }
                    }
                    else
                    {
                        Estatico.errores.Add(new ErrorCQL("Semantico", "Error el indice debe de ser int ", this.fila, this.columna));
                    }
                }
            }
            return null;
        }
    }
}
