using Proyecto_CQL_T.CQL.AnalizadorCQL;
using Proyecto_CQL_T.CQL.Extras;
using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using Proyecto_CQL_T.CQL.InterpreteCQL.Entorno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.Colecciones
{
    class ExpresionMap : Expresion
    {
        Tipo tipo_clave;
        Tipo tipo_valor;
        LinkedList<NodoExpresionMapa> contenido;
        int fila;
        int columna;
        public ExpresionMap(Tipo tipo_clave, Tipo tipo_valor, int fila, int columna)
        {
            this.tipo_clave = tipo_clave;
            this.contenido = null;
            this.fila = fila;
            this.columna = columna;
            this.tipo_valor = tipo_valor;
        }

        public ExpresionMap(LinkedList<NodoExpresionMapa> contenido, int fila, int columna)
        {
            this.contenido = contenido;
            this.fila = fila;
            this.columna = columna;
        }
        public Tipo getTipo(Entorno.Entorno ent)
        {
            return new Tipo("map", tipo_clave, tipo_valor);
        }

        public object getValor(Entorno.Entorno ent)
        {
            if (contenido == null)
            {
                return new Map(tipo_clave, tipo_valor);
            }
            else
            {
                NodoExpresionMapa primero = contenido.First();
                Tipo tipo_primero = primero.clava.getTipo(ent);
                bool todos_igual = true;
                foreach (NodoExpresionMapa exp in contenido)
                {
                    Tipo exp_tipo = exp.clava.getTipo(ent);
                    if (!tipo_primero.tipo.Equals(exp_tipo.tipo))
                    {
                        todos_igual = false;
                    }
                }
                Tipo tipo_primero_valor = primero.valor.getTipo(ent);
                bool todos_igual_valor = true;
                foreach (NodoExpresionMapa exp in contenido)
                {
                    Tipo exp_tipo = exp.valor.getTipo(ent);
                    if (!tipo_primero_valor.tipo.Equals(exp_tipo.tipo))
                    {
                        todos_igual_valor = false;
                    }
                }
                if (todos_igual && todos_igual_valor)
                {
                    Map nuevo = new Map(tipo_primero, tipo_primero_valor);

                    foreach (NodoExpresionMapa exp in contenido)
                    {
                        Object exp_clave = exp.clava.getValor(ent);
                        Object exp_valor = exp.valor.getValor(ent);
                        Tipo exp_tipo_clave = exp.clava.getTipo(ent);
                        Tipo exp_tipo_valor = exp.valor.getTipo(ent);
                        bool inserto = nuevo.insertar(exp_tipo_valor, exp_valor, exp_tipo_clave, exp_clave);
                        if (!inserto)
                        {
                            Estatico.errores.Add(new ErrorCQL("Semantico", "Error valor repetido en el map ", this.fila, this.columna));
                        }
                    }
                    return nuevo;
                }
                else
                {
                    Estatico.errores.Add(new ErrorCQL("Semantico", "Error de tipos en el map no todos son del mismo tipo ", this.fila, this.columna));
                }

            }
            return null;
        }
    }
}
