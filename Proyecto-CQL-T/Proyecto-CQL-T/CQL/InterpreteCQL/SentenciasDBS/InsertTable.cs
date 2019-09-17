using Proyecto_CQL_T.CQL.AnalizadorCQL;
using Proyecto_CQL_T.CQL.Base;
using Proyecto_CQL_T.CQL.Extras;
using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using Proyecto_CQL_T.CQL.InterpreteCQL.Entorno;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.SentenciasDBS
{
    class InsertTable : Instruccion
    {
        string nombre;
        LinkedList<Expresion> valores;
        int fila;
        int columna;

        public InsertTable(string nombre, LinkedList<Expresion> valores, int fila, int columna)
        {
            this.nombre = nombre.ToLower();
            this.valores = valores;
            this.fila = fila;
            this.columna = columna;
        }

        public object ejecutar(Entorno.Entorno ent)
        {
            if (Estatico.actualBase != null)
            {
                if (Estatico.actualBase.existeTabla(nombre))
                {
                    Tabla actual = Estatico.actualBase.getTabla(nombre);
                    LinkedList<Columna> sinCounter = new LinkedList<Columna>();
                    foreach (Columna col in actual.columnas)
                    {
                        if (!(col.tipo.tipo.Equals("counter")))
                        {
                            sinCounter.AddLast(col);
                        }
                    }

                    if (sinCounter.Count == valores.Count)
                    {
                        DataRow nueva = actual.tabla.NewRow();
                        for (int x = 0; x < sinCounter.Count; x++)
                        {
                            Expresion exp = valores.ElementAt(x);
                            Columna col = sinCounter.ElementAt(x);
                            Tipo texp = exp.getTipo(ent);
                            if (col.tipo.tipo.Equals(texp.tipo))
                            {
                                nueva[col.nombre] = exp.getValor(ent);
                            }
                            else if ((!(col.tipo.Equals("int") || col.tipo.Equals("double") || col.tipo.Equals("bool"))) && texp.tipo.Equals("null"))
                            {

                            }
                            else
                            {
                                Estatico.errores.Add(new ErrorCQL("Ejecucion", "El tipo: " + texp.tipo + ", del valor a ingresar no es igual al tipo de la columna " + col.nombre + ", de tipo:  " + col.tipo.tipo, this.fila, this.columna));
                                return null;
                            }
                        }
                        try
                        {
                            actual.tabla.Rows.Add(nueva);
                        }
                        catch (Exception e)
                        {
                            Estatico.errores.Add(new ErrorCQL("Ejecucion", " No pueden haber datos repetidos en la llave primaria ", this.fila, this.columna));
                        }
                    }
                    else
                    {
                        Estatico.errores.Add(new ErrorCQL("Ejecucion", "El numero de valores no es igual al numero de columnas de la tabla: " + nombre + ", en la base: " + Estatico.actualBase.nombre, this.fila, this.columna));
                    }
                    //actual.imprimirTablaValores();
                    //Console.WriteLine(actual.GetTablaHTML());
                }
                else
                {
                    Estatico.errores.Add(new ErrorCQL("Ejecucion", "No existe la tabla: " + nombre + ", en la base: " + Estatico.actualBase.nombre, this.fila, this.columna));
                }
            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Ejecucion", "No hay base en uso", this.fila, this.columna));
            }
            return null;
        }
    }
}
