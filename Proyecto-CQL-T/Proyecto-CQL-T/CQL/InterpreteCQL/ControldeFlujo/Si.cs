using Proyecto_CQL_T.CQL.AnalizadorCQL;
using Proyecto_CQL_T.CQL.Extras;
using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using Proyecto_CQL_T.CQL.InterpreteCQL.CambioFlujo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.ControldeFlujo
{
    class Si : Condicional, Instruccion
    {

        private LinkedList<NodoAST> instruccionesElse;
        private int fila;
        private int columna;

        public Si(LinkedList<NodoAST> intrucciones, Expresion condicion, LinkedList<NodoAST> instruccionesElse, int fila, int columna) : base(condicion, intrucciones)
        {

            this.instruccionesElse = instruccionesElse;
            this.fila = fila;
            this.columna = columna;
        }

        public LinkedList<NodoAST> getInstruccionesElse()
        {
            return instruccionesElse;
        }

        public void setInstruccionesElse(LinkedList<NodoAST> instruccionesElse)
        {
            this.instruccionesElse = instruccionesElse;
        }

        public object ejecutar(Entorno.Entorno ent)
        {
            Object condicion_si = this.condicion.getValor(ent);
            if (condicion_si is Boolean)
            {
                if ((Boolean)(condicion_si))
                {
                    Entorno.Entorno local = new Entorno.Entorno(ent);
                    foreach (NodoAST nodo in this.getIntrucciones())
                    {
                        if (nodo is Instruccion)
                        {
                            Instruccion ins = (Instruccion)nodo;
                            Object result = ins.ejecutar(local);
                            if (result != null)
                            {
                                return result;
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
                }
                else
                {
                    if (this.instruccionesElse != null)
                    {
                        Entorno.Entorno local = new Entorno.Entorno(ent);
                        foreach (NodoAST nodo in this.instruccionesElse)
                        {
                            if (nodo is Instruccion)
                            {
                                Instruccion ins = (Instruccion)nodo;
                                Object result = ins.ejecutar(local);
                                if (result != null)
                                {
                                    return result;
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
                    }
                }
            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Semantico", "La expresion del If no es booleana ", fila, columna));
            }
            return null;
        }
    }
}
