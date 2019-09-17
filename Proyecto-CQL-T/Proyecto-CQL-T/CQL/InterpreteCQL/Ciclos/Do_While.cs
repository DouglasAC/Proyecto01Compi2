using Proyecto_CQL_T.CQL.AnalizadorCQL;
using Proyecto_CQL_T.CQL.Extras;
using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using Proyecto_CQL_T.CQL.InterpreteCQL.CambioFlujo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.Ciclos
{
    class Do_While : Instruccion
    {
        Expresion condicion;
        LinkedList<NodoAST> sentencias;
        int fila;
        int columna;

        public Do_While(Expresion condicion, LinkedList<NodoAST> sentencias, int fila, int columna)
        {
            this.condicion = condicion;
            this.sentencias = sentencias;
            this.fila = fila;
            this.columna = columna;
        }

        public object ejecutar(Entorno.Entorno ent)
        {
            Object condicion_while = this.condicion.getValor(ent);
            if (condicion_while is Boolean)
            {
                do
                {
                    Entorno.Entorno local = new Entorno.Entorno(ent);
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
                                    break;
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
                } while ((Boolean)this.condicion.getValor(ent));
            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Semantico", "La expresion del Do_While no es booleana ", fila, columna));
            }
            return null;
        }
    }
}
