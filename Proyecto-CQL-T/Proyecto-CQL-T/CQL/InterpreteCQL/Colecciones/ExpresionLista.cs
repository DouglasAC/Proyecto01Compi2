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
    class ExpresionLista : Expresion
    {
        List<Object> valores;
        Tipo tipo;
        LinkedList<Expresion> contenido;
        int fila;
        int columna;
        public ExpresionLista(Tipo tipo, int fila, int columna)
        {
            this.tipo = tipo;
            this.contenido = null;
            this.fila = fila;
            this.columna = columna;
        }

        public ExpresionLista(LinkedList<Expresion> contenido, int fila, int columna)
        {
            this.contenido = contenido;
            this.fila = fila;
            this.columna = columna;
        }
        public object getValor(Entorno.Entorno ent)
        {
            if (contenido == null)
            {
                return new Lista(tipo);
            }
            else
            {
                Expresion primero = contenido.First();
                Tipo tipo_primero = primero.getTipo(ent);
                bool todos_igual = true;
                foreach (Expresion exp in contenido)
                {
                    Tipo exp_tipo = exp.getTipo(ent);
                    if (!tipo_primero.tipo.Equals(exp_tipo.tipo))
                    {
                        todos_igual = false;
                    }
                }
                if (todos_igual)
                {
                    valores = new List<object>();
                    foreach (Expresion exp in contenido)
                    {
                        Object exp_valor = exp.getValor(ent);
                        valores.Add(exp_valor);
                    }
                    return new Lista(valores, tipo_primero);
                }
                else
                {
                    Estatico.errores.Add(new ErrorCQL("Semantico", "Error de tipos en la lista no todos son del mismo tipo ", this.fila, this.columna));
                }

            }
            return null;
        }

        public Tipo getTipo(Entorno.Entorno ent)
        {
            return new Tipo("list", tipo);
        }
    }
}
