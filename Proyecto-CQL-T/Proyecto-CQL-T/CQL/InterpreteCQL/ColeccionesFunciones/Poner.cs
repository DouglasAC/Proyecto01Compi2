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
    class Poner : Expresion
    {
        public Object coleccion;
        public Expresion valor;
        public Expresion posicion;
        int fila;
        int columna;

        public Poner(Expresion valor, Expresion posicion, int fila, int columna)
        {
            this.valor = valor;
            this.fila = fila;
            this.columna = columna;
            this.posicion = posicion;
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

                    Object valpos = posicion.getValor(ent);
                    if (valpos is int)
                    {
                        Object val = valor.getValor(ent);
                        Tipo tipo = valor.getTipo(ent);
                        bool ingreso = l.setElemento((int)valpos, val, tipo);
                        if (!ingreso)
                        {
                            Estatico.errores.Add(new ErrorCQL("Semantico", "Error en set en la lista", this.fila, this.columna));
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
                    Object valpos = posicion.getValor(ent);
                    Tipo tclave = posicion.getTipo(ent);
                    Object val = valor.getValor(ent);
                    Tipo tipo = valor.getTipo(ent);
                    bool ingreso = l.setElemento(tipo, val, tclave, valpos);
                    if (!ingreso)
                    {
                        Estatico.errores.Add(new ErrorCQL("Semantico", "Error en set en del map", this.fila, this.columna));
                    }
                }
                else if (coleccion is Set)
                {
                    Set l = (Set)coleccion;
                    Object valpos = posicion.getValor(ent);
                    if (valpos is int)
                    {
                        Object val = valor.getValor(ent);
                        Tipo tipo = valor.getTipo(ent);
                        bool ingreso = l.setElemento((int)valpos, val, tipo);
                        if (!ingreso)
                        {
                            Estatico.errores.Add(new ErrorCQL("Semantico", "Error en set en tipo SET", this.fila, this.columna));
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