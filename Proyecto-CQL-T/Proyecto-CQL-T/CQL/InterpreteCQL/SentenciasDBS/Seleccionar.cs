using Proyecto_CQL_T.CQL.AnalizadorCQL;
using Proyecto_CQL_T.CQL.Base;
using Proyecto_CQL_T.CQL.Extras;
using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using Proyecto_CQL_T.CQL.InterpreteCQL.Entorno;
using Proyecto_CQL_T.CQL.InterpreteCQL.ValorImplicito;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.SentenciasDBS
{
    class Seleccionar : Instruccion
    {

        bool todos;
        LinkedList<Expresion> campos;
        String nombre;
        Expresion where;
        String order;
        Expresion limit;
        bool html;
        public Tabla tabla;
        int fila;
        int columna;


        public Seleccionar(bool todos, LinkedList<Expresion> campos, string nombre, Expresion where, string order, Expresion limit, bool html, int fila, int columna)
        {
            this.todos = todos;
            this.campos = campos;
            this.nombre = nombre;
            this.where = where;
            this.order = order;
            this.limit = limit;
            this.html = html;
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
                    if (todos)
                    {
                        campos = new LinkedList<Expresion>();
                        foreach (Columna col in actual.columnas)
                        {
                            campos.AddLast(new Identificador(col.nombre, this.fila, this.columna));
                        }

                        DataTable tabla_select = GenerarTabla(actual, ent);
                        if (tabla_select != null)
                        {
                            Tabla ntabla = new Tabla("consulta", tabla_select, new LinkedList<string>(), new LinkedList<Columna>());
                            if (this.html)
                            {
                                Estatico.agregarMensaje("[+DATA]" + ntabla.GetTablaHTML() + "[-DATA]");
                            }
                            this.tabla = ntabla;
                        }
                        else
                        {
                            this.tabla = null;
                        }
                    }
                    else
                    {
                        DataTable tabla_select = GenerarTabla(actual, ent);
                        if (tabla_select != null)
                        {
                            Tabla ntabla = new Tabla("consulta", tabla_select, new LinkedList<string>(), new LinkedList<Columna>());
                            if (this.html)
                            {
                                Estatico.agregarMensaje("[+DATA]" + ntabla.GetTablaHTML() + "[-DATA]");
                            }
                            this.tabla = ntabla;
                        }
                        else
                        {
                            this.tabla = null;
                        }
                    }

                }
                else
                {
                    Estatico.errores.Add(new ErrorCQL("Ejecucion", "La tabla: " + nombre + " no existe en la base: " + Estatico.actualBase.nombre, this.fila, this.columna));
                }
            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Ejecucion", "No hay base en uso", this.fila, this.columna));
            }


            return null;
        }

        public DataTable GenerarTabla(Tabla actual, Entorno.Entorno ent)
        {
            DataTable nueva = new DataTable();
            int x = 0;
            foreach (Expresion exp in this.campos)
            {
                if (exp is Identificador)
                {
                    Identificador ident = (Identificador)exp;
                    DataColumn ncol = new DataColumn(ident.identificador);
                    ncol.DataType = typeof(Object);
                    nueva.Columns.Add(ncol);
                }
                else
                {
                    DataColumn ncol = new DataColumn("Columna_" + x);
                    ncol.DataType = typeof(Object);
                    nueva.Columns.Add(ncol);
                }
                x++;
            }

            foreach (DataRow row in actual.tabla.Rows)
            {
                Entorno.Entorno local = new Entorno.Entorno(ent);
                int y = 0;
                foreach (DataColumn col in actual.tabla.Columns)
                {
                    if (row[col].GetType() != typeof(System.DBNull))
                    {
                        local.agregar(col.ColumnName, new Simbolo(col.ColumnName, actual.columnas.ElementAt(y).tipo, row[col]));

                    }
                    else
                    {
                        local.agregar(col.ColumnName, new Simbolo(col.ColumnName, actual.columnas.ElementAt(y).tipo, new Nulo()));
                    }
                    y++;
                }
                if (where == null)
                {

                    int z = 0;
                    DataRow row_nueva = nueva.NewRow();
                    foreach (Expresion exp in this.campos)
                    {

                        if (exp is Identificador)
                        {

                            Identificador ident = (Identificador)exp;
                            if (local.existe(ident.identificador))
                            {
                                object ob = exp.getValor(local);
                                if (!(ob is Nulo))
                                {
                                    row_nueva[ident.identificador] = ob;
                                }
                            }
                            else
                            {
                                Estatico.errores.Add(new ErrorCQL("Ejecucion", "La columna: " + ident.identificador + ", no existe en la tabla: " + nombre + ", en la base: " + Estatico.actualBase.nombre, this.fila, this.columna));
                                return null;
                            }
                        }
                        else
                        {
                            object ob = exp.getValor(local);
                            if (!(ob is Nulo))
                            {
                                row_nueva["Columna_" + z] = ob;
                            }

                        }
                        z++;
                    }
                    try
                    {
                        nueva.Rows.Add(row_nueva);
                    }
                    catch (Exception e)
                    {
                        Estatico.errores.Add(new ErrorCQL("Ejecucion", "Problema en agregar a la tabla del select ", this.fila, this.columna));
                    }
                }
                else
                {

                    int z = 0;
                    Object val_exp = where.getValor(local);
                    if (val_exp is bool)
                    {
                        if ((bool)val_exp)
                        {
                            DataRow row_nueva = nueva.NewRow();
                            foreach (Expresion exp in this.campos)
                            {
                                if (exp is Identificador)
                                {
                                    Identificador ident = (Identificador)exp;
                                    object ob = exp.getValor(local);
                                    if (!(ob is Nulo))
                                    {
                                        row_nueva[ident.identificador] = ob;
                                    }

                                }
                                else
                                {
                                    object ob = exp.getValor(local);
                                    if (!(ob is Nulo))
                                    {
                                        row_nueva["Columna_" + z] = ob;
                                    }

                                }
                                z++;
                            }
                            try
                            {
                                nueva.Rows.Add(row_nueva);
                            }
                            catch (Exception e)
                            {
                                Estatico.errores.Add(new ErrorCQL("Ejecucion", "Problema en agregar a la tabla del select ", this.fila, this.columna));
                            }
                        }
                    }
                    else
                    {
                        Estatico.errores.Add(new ErrorCQL("Ejecucion", "Where debe de dar un resultado booleano ", this.fila, this.columna));
                    }

                }



            }
            if (order != null)
            {
                try
                {
                    nueva.DefaultView.Sort = order;
                    nueva = nueva.DefaultView.ToTable();
                }
                catch (Exception e)
                {
                    Estatico.errores.Add(new ErrorCQL("Ejecucion", "Problema en order by a la tabla del select ", this.fila, this.columna));
                }
            }

            if (limit != null)
            {
                Object val = limit.getValor(ent);
                if (val is int)
                {
                    int limite = (int)val;
                    while (nueva.Rows.Count > limite)
                    {
                        //dataTable.Rows[dataTable.Rows.Count - 1].Delete();
                        nueva.Rows[nueva.Rows.Count - 1].Delete();
                    }
                }
                else if (val is double)
                {
                    double valor = (double)val;
                    int limite = Convert.ToInt32(valor);

                    while (nueva.Rows.Count > limite)
                    {
                        //dataTable.Rows[dataTable.Rows.Count - 1].Delete();
                        nueva.Rows[nueva.Rows.Count - 1].Delete();
                    }
                }
                else
                {
                    Estatico.errores.Add(new ErrorCQL("Ejecucion", "El valor del limit no es un numero", this.fila, this.columna));
                }
            }

            return nueva;
        }
    }
}
