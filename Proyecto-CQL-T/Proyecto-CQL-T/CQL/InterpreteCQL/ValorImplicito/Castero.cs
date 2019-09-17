using Proyecto_CQL_T.CQL.AnalizadorCQL;
using Proyecto_CQL_T.CQL.Extras;
using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using Proyecto_CQL_T.CQL.InterpreteCQL.Colecciones;
using Proyecto_CQL_T.CQL.InterpreteCQL.Entorno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.ValorImplicito
{
    class Castero : Expresion
    {
        Tipo tipo;
        Expresion exp;
        int fila;
        int columna;

        public Castero(Tipo tipo, Expresion exp, int fila, int columna)
        {
            this.tipo = tipo;
            this.exp = exp;
            this.fila = fila;
            this.columna = columna;
        }

        public Tipo getTipo(Entorno.Entorno ent)
        {
            Object valor = getValor(ent);
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
            Object valor = exp.getValor(ent);
            if (tipo.tipo.Equals("int"))
            {
                try
                {
                    if (valor is double)
                    {
                        int val = Convert.ToInt32((double)valor);
                        return val;
                    }
                    else if (valor is string)
                    {
                        int val = Int32.Parse((string)valor);
                        return val;
                    }
                }
                catch (Exception e)
                {

                }
            }
            else if (tipo.tipo.Equals("double"))
            {
                try
                {
                    if (valor is int)
                    {
                        double val = Convert.ToDouble((int)valor);
                        return val;
                    }
                    else if (valor is string)
                    {
                        double val = Convert.ToDouble(((String)valor));
                        return val;
                    }
                }
                catch (Exception e)
                {

                }
            }
            else if (tipo.tipo.Equals("string"))
            {
                try
                {
                    String val = valor.ToString();
                    return val;
                }
                catch (Exception e)
                {

                }
            }
            else if (tipo.tipo.Equals("date"))
            {
                try
                {
                    Date dat = new Date(valor.ToString());
                    return dat;
                }
                catch (Exception e)
                {

                }
            }
            else if (tipo.tipo.Equals("time"))
            {
                try
                {
                    DateTime day = DateTime.ParseExact(valor.ToString(), "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    Tiempo dat = new Tiempo(day);
                    return dat;
                }
                catch (Exception e)
                {

                }
            }
            Estatico.errores.Add(new ErrorCQL("Ejecucion", "Error al momento de realizar el casteo", this.fila, this.columna));
            return new Nulo();
        }
    }
}
