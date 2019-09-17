using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using Proyecto_CQL_T.CQL.InterpreteCQL.Colecciones;
using Proyecto_CQL_T.CQL.InterpreteCQL.ColeccionesFunciones;
using Proyecto_CQL_T.CQL.InterpreteCQL.Entorno;
using Proyecto_CQL_T.CQL.InterpreteCQL.FuncionNativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.ValorImplicito
{
    class Acceso : Expresion
    {
        String variable;
        LinkedList<Expresion> fuciones;
        int fila;
        int columna;

        public Acceso(string variable, LinkedList<Expresion> fuciones, int fila, int columna)
        {
            this.variable = variable;
            this.fuciones = fuciones;
            this.fila = fila;
            this.columna = columna;
        }

        public Tipo getTipo(Entorno.Entorno ent)
        {

            Entorno.Entorno temp = ent;
            Object valor = getValor(temp);
            if (valor is int)
            {
                return new Tipo("int");
            }
            else if (valor is double)
            {
                return new Tipo("double");
            }
            else if (valor is String)
            {
                return new Tipo("string");
            }
            else if (valor is Boolean)
            {
                return new Tipo("bool");
            }
            else if (valor is Date)
            {
                return new Tipo("date");
            }
            else if (valor is Tiempo)
            {
                return new Tipo("time");
            }
            else if (valor is Lista)
            {
                return new Tipo("list");
            }
            else if (valor is Map)
            {
                return new Tipo("map");
            }
            else if (valor is Set)
            {
                return new Tipo("set");
            }
            else if (valor is Objeto)
            {
                Objeto obj = (Objeto)valor;
                return obj.tipo;
            }


            return new Tipo("null");
        }

        public object getValor(Entorno.Entorno ent)
        {
            if (ent.existe(variable))
            {
                Simbolo sim = ent.get(variable);

                Object valor = sim.valor;
                foreach (Expresion exp in this.fuciones)
                {

                    if (exp is Contiene)
                    {
                        Contiene exp2 = (Contiene)exp;
                        exp2.coleccion = valor;
                        valor = exp2.getValor(ent);
                    }
                    else if (exp is Insertar)
                    {
                        Insertar exp2 = (Insertar)exp;
                        exp2.coleccion = valor;
                        valor = exp2.getValor(ent);
                    }
                    else if (exp is Obtener)
                    {
                        Obtener exp2 = (Obtener)exp;
                        exp2.coleccion = valor;
                        valor = exp2.getValor(ent);
                    }
                    else if (exp is Poner)
                    {
                        Poner exp2 = (Poner)exp;
                        exp2.coleccion = valor;
                        valor = exp2.getValor(ent);
                    }
                    else if (exp is Remover)
                    {
                        Remover exp2 = (Remover)exp;
                        exp2.coleccion = valor;
                        valor = exp2.getValor(ent);
                    }
                    else if (exp is Size)
                    {
                        Size exp2 = (Size)exp;
                        exp2.coleccion = valor;
                        valor = exp2.getValor(ent);
                    }
                    else if (exp is Vaciar)
                    {
                        Vaciar exp2 = (Vaciar)exp;
                        exp2.coleccion = valor;
                        valor = exp2.getValor(ent);
                    }
                    else if (exp is endWith)
                    {
                        endWith exp2 = (endWith)exp;
                        exp2.cadena = valor;
                        valor = exp2.getValor(ent);
                    }
                    else if (exp is length)
                    {
                        length exp2 = (length)exp;
                        exp2.cadena = valor;
                        valor = exp2.getValor(ent);
                    }
                    else if (exp is startsWith)
                    {
                        startsWith exp2 = (startsWith)exp;
                        exp2.cadena = valor;
                        valor = exp2.getValor(ent);
                    }
                    else if (exp is subString)
                    {
                        subString exp2 = (subString)exp;
                        exp2.cadena = valor;
                        valor = exp2.getValor(ent);
                    }
                    else if (exp is toLower)
                    {
                        toLower exp2 = (toLower)exp;
                        exp2.cadena = valor;
                        valor = exp2.getValor(ent);
                    }
                    else if (exp is toUpper)
                    {
                        toUpper exp2 = (toUpper)exp;
                        exp2.cadena = valor;
                        valor = exp2.getValor(ent);
                    }
                    else if (exp is getDay)
                    {
                        getDay exp2 = (getDay)exp;
                        exp2.fecha = valor;
                        valor = exp2.getValor(ent);
                    }
                    else if (exp is getMonth)
                    {
                        getMonth exp2 = (getMonth)exp;
                        exp2.fecha = valor;
                        valor = exp2.getValor(ent);
                    }
                    else if (exp is getYear)
                    {
                        getYear exp2 = (getYear)exp;
                        exp2.fecha = valor;
                        valor = exp2.getValor(ent);
                    }
                    else if (exp is getHour)
                    {
                        getHour exp2 = (getHour)exp;
                        exp2.hora = valor;
                        valor = exp2.getValor(ent);
                    }
                    else if (exp is getMinuts)
                    {
                        getMinuts exp2 = (getMinuts)exp;
                        exp2.hora = valor;
                        valor = exp2.getValor(ent);
                    }
                    else if (exp is getSeconds)
                    {
                        getSeconds exp2 = (getSeconds)exp;
                        exp2.hora = valor;
                        valor = exp2.getValor(ent);
                    }
                    else if (exp is Identificador)
                    {
                        if (valor is Objeto)
                        {
                            Objeto ob = (Objeto)valor;
                            Identificador ide = (Identificador)exp;

                            valor = ide.getValor(ob.atributos);
                        }

                    }
                }
                return valor;


            }
            return null;
        }
    }
}
