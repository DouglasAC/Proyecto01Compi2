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
    class Asignacion : Instruccion
    {

        private string nombreVar;
        private bool accesoObjeto;
        private LinkedList<Expresion> atributos;
        private Expresion valor;
        int fila;
        int columna;

        public Asignacion(String nombreVar, Expresion valor, int fila, int columna)
        {
            this.nombreVar = nombreVar;
            this.valor = valor;
            this.accesoObjeto = false;
            this.columna = columna;
            this.fila = fila;
        }


        public Asignacion(String nombreVar, LinkedList<Expresion> atributos, Expresion valor, int fila, int columna)
        {
            this.nombreVar = nombreVar;
            this.atributos = atributos;
            this.valor = valor;
            this.accesoObjeto = true;
            this.fila = fila;
            this.columna = columna;
        }


        public object ejecutar(Entorno ent)
        {
            object val = valor.getValor(ent);
            if (!accesoObjeto)
            {

                Tipo tipoVal = valor.getTipo(ent);
                Tipo tipoVar = ent.get(nombreVar).tipo;
                if (ent.existe(nombreVar))
                {
                    if (tipoVal.tipo.Equals(tipoVar.tipo))
                    {
                        //ent.get(nombreVar).valor = val;

                        ent.reemplazar(nombreVar, new Simbolo(nombreVar, tipoVar, val));

                    }
                    else if (tipoVal.tipo.Equals("int") && tipoVar.tipo.Equals("double"))
                    {
                        int valor = (int)val;
                        double valor2 = Convert.ToDouble(valor);
                        //ent.get(nombreVar).valor = valor2;
                        ent.reemplazar(nombreVar, new Simbolo(nombreVar, tipoVar, valor2));
                    }
                    else if (tipoVar.tipo.Equals("int") && tipoVal.tipo.Equals("double"))
                    {
                        double valor = (double)val;
                        int valor2 = Convert.ToInt32(valor);
                        //ent.get(nombreVar).valor = valor2;
                        ent.reemplazar(nombreVar, new Simbolo(nombreVar, tipoVar, valor2));
                    }
                    else if ((!(tipoVar.tipo.Equals("int") || tipoVar.tipo.Equals("double") || tipoVar.tipo.Equals("bool"))) && tipoVal.tipo.Equals("null"))
                    {

                        ent.reemplazar(nombreVar, new Simbolo(nombreVar, tipoVar, new Nulo()));
                    }
                    else
                    {
                        Estatico.errores.Add(new ErrorCQL("Semantico", "Error de tipos en la variable: " + nombreVar + " de tipo " + tipoVar + " se intento poner tipo: " + tipoVal, this.fila, this.columna));

                    }


                }
                else
                {
                    Estatico.errores.Add(new ErrorCQL("Semantico", "La variable: " + nombreVar + " no existe ", this.fila, this.columna));
                }
            }
            else
            {

                if (ent.existe(nombreVar))
                {
                    Simbolo sim = ent.get(nombreVar);

                    Object valor = sim.valor;
                    int x = 0;
                    for (x = 0; x < this.atributos.Count - 1; x++)
                    {
                        Expresion exp = atributos.ElementAt(x);

                        if (exp is Identificador)
                        {
                            if (valor is Objeto)
                            {
                                Objeto ob = (Objeto)valor;
                                Identificador ide = (Identificador)exp;

                                valor = ide.getValor(ob.atributos);
                            }

                        }
                    }
                    if (valor is Objeto)
                    {
                        Objeto actual = (Objeto)valor;
                        Expresion exp;
                        if (atributos.Count == 1)
                        {
                            exp = atributos.ElementAt(0);
                        }
                        else
                        {
                            exp = atributos.ElementAt(x);
                        }

                        if (exp is Identificador)
                        {
                            Identificador ide = (Identificador)exp;
                            if (actual.atributos.existe(ide.identificador))
                            {
                                Tipo tipoVar = actual.atributos.get(ide.identificador).tipo;
                                Tipo tipoVal = this.valor.getTipo(ent);
                                if (tipoVal.tipo.Equals(tipoVar.tipo))
                                {
                                    //ent.get(nombreVar).valor = val;

                                    actual.atributos.reemplazar(ide.identificador, new Simbolo(ide.identificador, tipoVar, val));

                                }
                                else if (tipoVal.tipo.Equals("int") && tipoVar.tipo.Equals("double"))
                                {
                                    int valo = (int)val;
                                    double valor2 = Convert.ToDouble(valo);
                                    //ent.get(nombreVar).valor = valor2;
                                    actual.atributos.reemplazar(ide.identificador, new Simbolo(ide.identificador, tipoVar, valor2));
                                }
                                else if (tipoVar.tipo.Equals("int") && tipoVal.tipo.Equals("double"))
                                {
                                    double valo = (double)val;
                                    int valor2 = Convert.ToInt32(valo);
                                    //ent.get(nombreVar).valor = valor2;
                                    actual.atributos.reemplazar(ide.identificador, new Simbolo(ide.identificador, tipoVar, valor2));
                                }
                                else if ((!(tipoVar.tipo.Equals("int") || tipoVar.tipo.Equals("double") || tipoVar.tipo.Equals("bool"))) && tipoVal.tipo.Equals("null"))
                                {

                                    actual.atributos.reemplazar(ide.identificador, new Simbolo(ide.identificador, tipoVar, new Nulo()));
                                }
                                else
                                {
                                    Estatico.errores.Add(new ErrorCQL("Semantico", "Error de tipos en atributo de la variable " + nombreVar, this.fila, this.columna));

                                }
                            }

                            else
                            {
                                Estatico.errores.Add(new ErrorCQL("Semantico", "La variable: " + nombreVar + " no existe ", this.fila, this.columna));
                            }
                        }





                    }

                }
                else
                {
                    Estatico.errores.Add(new ErrorCQL("Semantico", "La variable: " + nombreVar + " no existe ", this.fila, this.columna));
                }
            }

            return null;
        }
    }
}
