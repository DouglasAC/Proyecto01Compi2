using Proyecto_CQL_T.CQL.AnalizadorCQL;
using Proyecto_CQL_T.CQL.Extras;
using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using Proyecto_CQL_T.CQL.InterpreteCQL.CambioFlujo;
using Proyecto_CQL_T.CQL.InterpreteCQL.Colecciones;
using Proyecto_CQL_T.CQL.InterpreteCQL.ValorImplicito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.Entorno
{
    class Funcion : Simbolo, Instruccion
    {
        LinkedList<NodoAST> instrucciones;
        private int fila, columna;

        public Funcion(Tipo tipo, string identificador, LinkedList<Simbolo> listaParametros, LinkedList<NodoAST> instrucciones, int fila, int columna)
            : base(identificador, tipo, listaParametros)
        {
            String nombre = identificador.ToLower() + "_";
            if (listaParametros != null)
            {
                foreach (Simbolo sim in listaParametros)
                {
                    nombre += sim.tipo.tipo + "_";
                }
            }
            this.identificador = nombre;
            this.instrucciones = instrucciones;
            this.fila = fila;
            this.columna = columna;
        }

        public object ejecutar(Entorno ent)
        {
            foreach (NodoAST nodo in this.instrucciones)
            {
                if (nodo is Instruccion)
                {
                    Instruccion ins = (Instruccion)nodo;
                    Object result = ins.ejecutar(ent);
                    if (result is Break)
                    {
                        Estatico.errores.Add(new ErrorCQL("Semantico", "Error break en funcion ", this.fila, this.columna));
                    }
                    else if (result is Continue)
                    {
                        Estatico.errores.Add(new ErrorCQL("Semantico", "Error continue en funcion ", this.fila, this.columna));
                    }
                    else if (result is Return)
                    {
                        Return ret = (Return)result;
                        if (ret.retorno != null)
                        {
                            if (verificarTipo(this.tipo, ret.retorno))
                            {
                                return ret.retorno;
                            }
                            else
                            {
                                Estatico.errores.Add(new ErrorCQL("Semantico", "Error retorno no es del mismo tipo que la funcion en funcion ", this.fila, this.columna));
                                return null;
                            }

                        }
                    }

                }
                else if (nodo is Expresion)
                {
                    Expresion exp = (Expresion)nodo;
                    Object result = exp.getValor(ent);
                    if (result is Return)
                    {
                        Return ret = (Return)result;
                        if (ret.retorno != null)
                        {
                            if (verificarTipo(this.tipo, ret.retorno))
                            {
                                return ret.retorno;
                            }
                            else
                            {
                                Estatico.errores.Add(new ErrorCQL("Semantico", "Error retorno no es del mismo tipo que la funcion en funcion ", this.fila, this.columna));
                                return null;
                            }

                        }
                    }
                    else if (result is Break)
                    {
                        Estatico.errores.Add(new ErrorCQL("Semantico", "Error break en funcion ", this.fila, this.columna));
                    }
                    else if (result is Continue)
                    {
                        Estatico.errores.Add(new ErrorCQL("Semantico", "Error continue en funcion ", this.fila, this.columna));
                    }
                }
            }
            return null;
        }

        private bool verificarTipo(Tipo tipo, object result)
        {
            if (tipo.tipo.Equals("int") && result is int)
            {
                return true;
            }
            else if (tipo.tipo.Equals("string") && result is string)
            {
                return true;
            }
            else if (tipo.tipo.Equals("double") && result is Double)
            {
                return true;
            }
            else if (tipo.tipo.Equals("bool") && result is bool)
            {
                return true;
            }
            else if (tipo.tipo.Equals("date") && result is Date)
            {
                return true;
            }
            else if (tipo.tipo.Equals("time") && result is Tiempo)
            {
                return true;
            }
            else if (tipo.tipo.Equals("list") && result is Lista)
            {
                return true;
            }
            else if (tipo.tipo.Equals("map") && result is Map)
            {
                return true;
            }
            else if (tipo.tipo.Equals("set") && result is Set)
            {
                return true;
            }

            else
            {
                return false;
            }

        }

    }
}
