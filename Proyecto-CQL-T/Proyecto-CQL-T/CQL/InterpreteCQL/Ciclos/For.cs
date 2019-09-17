using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using Proyecto_CQL_T.CQL.InterpreteCQL.CambioFlujo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.Ciclos
{
    class For : Instruccion
    {
        Instruccion inicializacion;
        Expresion condicion;
        NodoAST actualizacion;
        LinkedList<NodoAST> sentencias;
        int fila;
        int columna;

        public For(Instruccion inicializacion, Expresion condicion, NodoAST actualizacion, LinkedList<NodoAST> sentencias, int fila, int columna)
        {
            this.inicializacion = inicializacion;
            this.condicion = condicion;
            this.actualizacion = actualizacion;
            this.sentencias = sentencias;
            this.fila = fila;
            this.columna = columna;
        }

        public object ejecutar(Entorno.Entorno ent)
        {
            Entorno.Entorno local = new Entorno.Entorno(ent);
            object inicio = this.inicializacion.ejecutar(local);
            while ((Boolean)this.condicion.getValor(local))
            {
                Entorno.Entorno local2 = new Entorno.Entorno(local);
                foreach (NodoAST nodo in this.sentencias)
                {
                    if (nodo is Instruccion)
                    {
                        Instruccion ins = (Instruccion)nodo;
                        Object result = ins.ejecutar(local);

                        if (result != null)
                        {
                            if (result is Break)
                            {
                                return null;
                            }
                            else if (result is Continue)
                            {
                                goto siguiente;
                            }
                            else
                            {
                                return result;
                            }
                        }

                    }
                    else if (nodo is Expresion)
                    {
                        Expresion expr = (Expresion)nodo;
                        Object ret = expr.getValor(local);
                        if (ret is Return)
                        {
                            return ret;
                        }
                    }
                }
            siguiente:
                if (actualizacion is Instruccion)
                {
                    Instruccion act = (Instruccion)this.actualizacion;
                    Object valact = act.ejecutar(local);
                }
                else if (actualizacion is Expresion)
                {
                    Expresion act = (Expresion)this.actualizacion;
                    Object valact = act.getValor(local);
                }
            }
            return null;
        }
    }
}
