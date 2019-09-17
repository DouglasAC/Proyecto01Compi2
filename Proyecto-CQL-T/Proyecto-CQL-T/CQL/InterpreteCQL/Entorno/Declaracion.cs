using Proyecto_CQL_T.CQL.AnalizadorCQL;
using Proyecto_CQL_T.CQL.Extras;
using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using Proyecto_CQL_T.CQL.InterpreteCQL.ValorImplicito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.Entorno
{
    class Declaracion : Instruccion
    {
        public Expresion valorInicial;

        private LinkedList<Simbolo> variables;

        private int fila;
        private int columna;


        public Declaracion(Tipo tipo, LinkedList<Simbolo> variables, Expresion valor, int fila, int columna)
        {
            this.columna = columna;
            this.fila = fila;
            foreach (Simbolo variable in variables)
            {
                variable.identificador = variable.identificador.ToLower();
                variable.tipo = tipo;
            }
            this.variables = variables;
            this.valorInicial = valor;
        }

        public Declaracion(Tipo tipo, LinkedList<Simbolo> variables, int fila, int columna)
        {
            this.columna = columna;
            this.fila = fila;
            foreach (Simbolo variable in variables)
            {
                variable.identificador = variable.identificador.ToLower();
                variable.tipo = tipo;
            }
            this.variables = variables;
            this.valorInicial = null;
        }

        public Declaracion(Tipo tipo, Simbolo variable, int fila, int columna)
        {
            this.columna = columna;
            this.fila = fila;
            variable.tipo = tipo;
            variable.identificador.ToLower();
            LinkedList<Simbolo> variables = new LinkedList<Simbolo>();
            variables.AddLast(variable);
            this.variables = variables;
            this.valorInicial = null;
        }

        bool tieneValorInicial()
        {
            return this.valorInicial != null;
        }

        public object ejecutar(Entorno ent)
        {
            foreach (Simbolo variable in variables)
            {
                string nombreVariable = variable.identificador.ToLower();
                if (tieneValorInicial())
                {
                    Tipo tipoVal = valorInicial.getTipo(ent);
                    Tipo tipoVar = variable.tipo;
                    if (ent.existeEnActual(nombreVariable))
                    {
                        Estatico.errores.Add(new ErrorCQL("Semantico", "La variable: " + nombreVariable + " ya existe ", this.fila, this.columna));
                    }
                    else
                    {
                        Simbolo sim_nuevo = new Simbolo(variable.identificador);
                        sim_nuevo.tipo = tipoVal;
                        if (tipoVal.tipo.Equals(tipoVar.tipo))
                        {
                            Object val = valorInicial.getValor(ent);
                            if (val is Objeto)
                            {


                            }
                            sim_nuevo.valor = val;

                            ent.agregar(nombreVariable, sim_nuevo);
                        }
                        else if (tipoVal.tipo.Equals("int") && tipoVar.tipo.Equals("double"))
                        {
                            int valor = (int)valorInicial.getValor(ent);
                            double valor2 = Convert.ToDouble(valor);
                            sim_nuevo.valor = valor2;
                            ent.agregar(nombreVariable, sim_nuevo);
                        }
                        else if (tipoVar.tipo.Equals("int") && tipoVal.tipo.Equals("double"))
                        {
                            double valor = (double)valorInicial.getValor(ent);
                            int valor2 = Convert.ToInt32(valor);
                            sim_nuevo.valor = valor2;
                            ent.agregar(nombreVariable, sim_nuevo);
                        }
                        else if ((!(tipoVar.tipo.Equals("int") || tipoVar.tipo.Equals("double") || tipoVar.tipo.Equals("bool"))) && tipoVal.tipo.Equals("null"))
                        {
                            sim_nuevo.valor = new Nulo();
                            ent.agregar(nombreVariable, sim_nuevo);
                        }
                        else
                        {
                            Estatico.errores.Add(new ErrorCQL("Semantico", "Error de tipos en la variable: " + nombreVariable + " de tipo " + tipoVar.tipo + " se intento poner tipo: " + tipoVal.tipo, this.fila, this.columna));
                        }
                    }
                }
                else
                {
                    if (ent.existeEnActual(nombreVariable))
                    {
                        Estatico.errores.Add(new ErrorCQL("Semantico", "La variable: " + nombreVariable + " ya existe ", this.fila, this.columna));
                    }
                    else
                    {
                        Tipo tipov = variable.tipo;
                        bool agreegar = true;
                        Simbolo sim_nuevo = new Simbolo(variable.identificador);
                        sim_nuevo.tipo = tipov;
                        if (tipov.tipo.Equals("int"))
                        {
                            sim_nuevo.valor = (int)0;
                        }
                        else if (tipov.tipo.Equals("double"))
                        {
                            sim_nuevo.valor = (double)0.0;
                        }
                        else if (tipov.tipo.Equals("bool"))
                        {
                            sim_nuevo.valor = false;
                        }
                        else if (tipov.tipo.Equals("string") || tipov.tipo.Equals("date") || tipov.tipo.Equals("time") || tipov.tipo.Equals("map") || tipov.tipo.Equals("set") || tipov.tipo.Equals("list"))
                        {
                            sim_nuevo.valor = new Nulo();
                        }
                        else
                        {
                            if (Estatico.actualBase != null)
                            {
                                if (Estatico.actualBase.existeObjetoDefinido(tipov.tipo))
                                {
                                    sim_nuevo.valor = new Nulo();
                                }
                                else
                                {
                                    Estatico.errores.Add(new ErrorCQL("Ejecucion", "No existe el objeto: " + tipov.tipo + " en la base: " + Estatico.actualBase.nombre, this.fila, this.columna));
                                    agreegar = false;
                                }
                            }
                            else
                            {
                                Estatico.errores.Add(new ErrorCQL("Ejecucion", "No hay base en uso ", this.fila, this.columna));
                                agreegar = false;
                            }
                        }
                        if (agreegar)
                        {
                            ent.agregar(nombreVariable, sim_nuevo);
                        }

                    }
                }

            }

            return null;
        }

    }
}
