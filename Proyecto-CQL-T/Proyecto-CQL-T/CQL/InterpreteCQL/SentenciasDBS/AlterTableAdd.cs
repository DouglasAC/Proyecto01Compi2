using Proyecto_CQL_T.CQL.AnalizadorCQL;
using Proyecto_CQL_T.CQL.Base;
using Proyecto_CQL_T.CQL.Extras;
using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using Proyecto_CQL_T.CQL.InterpreteCQL.Colecciones;
using Proyecto_CQL_T.CQL.InterpreteCQL.Entorno;
using Proyecto_CQL_T.CQL.InterpreteCQL.ValorImplicito;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.SentenciasDBS
{
    class AlterTableAdd : Instruccion
    {
        string nombre;
        LinkedList<Columna> columnasNuevas;
        int fila;
        int columna;

        public AlterTableAdd(string nombre, LinkedList<Columna> columnasNuevas, int fila, int columna)
        {
            this.nombre = nombre.ToLower();
            this.columnasNuevas = columnasNuevas;
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
                    bool noexiste = true;
                    bool noprimary = true;
                    foreach (Columna col in columnasNuevas)
                    {
                        foreach (Columna col2 in actual.columnas)
                        {
                            if (col.nombre.Equals(col2.nombre))
                            {
                                noexiste = false;
                                Estatico.errores.Add(new ErrorCQL("Ejecucion", "En la tabla: " + actual.nombre + " ya existe la columna: " + col.nombre, this.fila, this.columna));
                            }
                        }
                        if (col.primaria)
                        {
                            noprimary = false;
                            Estatico.errores.Add(new ErrorCQL("Ejecucion", "La columna: " + col.nombre + ", a agregar no debe ser llave primaria", this.fila, this.columna));
                        }
                        if (col.tipo.tipo.Equals("counter"))
                        {
                            noprimary = false;
                            Estatico.errores.Add(new ErrorCQL("Ejecucion", "La columna: " + col.nombre + ", a agregar no debe ser de tipo counter", this.fila, this.columna));
                        }
                    }
                    if (noprimary && noexiste)
                    {

                        foreach (Columna col in columnasNuevas)
                        {
                            DataColumn ncol = new DataColumn(col.nombre);

                            if (col.tipo.tipo.Equals("int"))
                            {
                                ncol.DataType = typeof(int);
                            }
                            else if (col.tipo.tipo.Equals("double"))
                            {
                                ncol.DataType = typeof(double);
                            }
                            else if (col.tipo.tipo.Equals("string"))
                            {
                                ncol.DataType = typeof(string);
                            }
                            else if (col.tipo.tipo.Equals("bool"))
                            {
                                ncol.DataType = typeof(bool);
                            }
                            else if (col.tipo.tipo.Equals("time"))
                            {
                                ncol.DataType = typeof(Tiempo);
                            }
                            else if (col.tipo.tipo.Equals("date"))
                            {
                                ncol.DataType = typeof(Date);
                            }
                            else if (col.tipo.tipo.Equals("map"))
                            {
                                ncol.DataType = typeof(Map);
                            }
                            else if (col.tipo.tipo.Equals("list"))
                            {
                                ncol.DataType = typeof(Lista);
                            }
                            else if (col.tipo.tipo.Equals("set"))
                            {
                                ncol.DataType = typeof(Set);
                            }
                            else
                            {
                                ncol.DataType = typeof(Objeto);
                            }
                            actual.nuevaColumna(col, ncol);
                        }
                    }
                    //Estatico.actualBase.getTabla(nombre).imprimirTabla();
                }
                else
                {
                    Estatico.errores.Add(new ErrorCQL("Ejecucion", "La tabla: " + nombre + " no existe en la base: " + Estatico.actualBase.nombre, this.fila, this.columna));
                }
            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Ejecucion", "No hay base de datos seleccionada ", this.fila, this.columna));
            }
            return null;
        }
    }
}
