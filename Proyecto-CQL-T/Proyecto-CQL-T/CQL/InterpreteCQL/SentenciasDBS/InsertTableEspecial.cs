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
    class InsertTableEspecial : Instruccion
    {
        string nombre;
        LinkedList<String> campos;
        LinkedList<Expresion> valores;
        int fila;
        int columna;
        public InsertTableEspecial(string nombre, LinkedList<string> campos, LinkedList<Expresion> valores, int fila, int columna)
        {
            this.nombre = nombre.ToLower();
            this.campos = campos;
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

                    if (campos.Count == valores.Count)
                    {
                        bool existentodos = true;
                        LinkedList<Columna> cols = new LinkedList<Columna>();
                        foreach (String nom in this.campos)
                        {
                            if (actual.existeColumna(nom))
                            {
                                Columna col = actual.GetColumna(nom);
                                if (col.tipo.tipo.Equals("counter"))
                                {
                                    Estatico.errores.Add(new ErrorCQL("Ejecucion", "El campo: " + nom + ", es tipo counter su valor se incrementa automaticamente por lo cual no se puede insertar este valor", this.fila, this.columna));
                                    return null;
                                }
                                else
                                {
                                    cols.AddLast(actual.GetColumna(nom));
                                }

                            }
                            else
                            {
                                Estatico.errores.Add(new ErrorCQL("Ejecucion", "El campo: " + nom + ", no existe en la tabla:" + actual.nombre, this.fila, this.columna));
                                return null;
                            }
                        }

                        DataRow nueva = actual.tabla.NewRow();
                        for (int x = 0; x < campos.Count; x++)
                        {
                            Expresion exp = valores.ElementAt(x);
                            Columna col = cols.ElementAt(x);
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
                        Estatico.errores.Add(new ErrorCQL("Ejecucion", "El numero de valores no es igual al numero de campos seleccionados de la tabla: " + nombre + ", en la base: " + Estatico.actualBase.nombre, this.fila, this.columna));
                    }
                    //actual.imprimirTablaValores();
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
