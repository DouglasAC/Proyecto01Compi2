using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using Proyecto_CQL_T.CQL.InterpreteCQL.CambioFlujo;
using Proyecto_CQL_T.CQL.InterpreteCQL.ValorImplicito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Proyecto_CQL_T.CQL.InterpreteCQL.ValorImplicito.Operacion;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.ControldeFlujo
{
    class Switch : Instruccion
    {
        LinkedList<Case> casos;
        Expresion expresion;
        Case defecto;
        int fila;
        int columna;

        public Switch(Expresion expresion, LinkedList<Case> casos, Case defecto, int fila, int columna)
        {
            this.expresion = expresion;
            this.casos = casos;
            this.defecto = defecto;
            this.fila = fila;
            this.columna = columna;
        }

        public object ejecutar(Entorno.Entorno ent)
        {
            bool entro = false;
            bool encontro = false;
            foreach (Case caso in this.casos)
            {

                Operacion operacion = new Operacion(this.expresion, caso.getExpresion(), Operador.IGUAL_IGUAL, fila, columna);
                Object re = operacion.getValor(ent);
                if (re is Boolean)
                {
                    if ((bool)re || encontro)
                    {
                        entro = true;
                        encontro = true;
                        foreach (NodoAST nodo in caso.getSentencias())
                        {
                            Entorno.Entorno local = new Entorno.Entorno(ent);
                            if (nodo is Instruccion)
                            {
                                Instruccion ins = (Instruccion)nodo;
                                Object result = ins.ejecutar(local);
                                if (result is Break)
                                {
                                    return null;
                                }
                                else if (result != null)
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
            if (!entro)
            {
                if (this.defecto != null)
                {
                    Case caso = this.defecto;

                    foreach (NodoAST nodo in caso.getSentencias())
                    {
                        Entorno.Entorno local = new Entorno.Entorno(ent);
                        if (nodo is Instruccion)
                        {
                            Instruccion ins = (Instruccion)nodo;
                            Object result = ins.ejecutar(local);
                            if (result is Break)
                            {
                                return null;
                            }
                            else if (result != null)
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

            return null;
        }
    }
}
