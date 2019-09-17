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
    class CrearTabla : Instruccion
    {

        String nombre;
        bool noexiste;
        LinkedList<Columna> columnas;
        LinkedList<String> llaves_primarias;
        int fila;
        int columna;

        public CrearTabla(string nombre, bool noexiste, LinkedList<Columna> columnas, LinkedList<string> llaves_primarias, int fila, int columna)
        {
            this.nombre = nombre.ToLower();
            this.noexiste = noexiste;
            this.columnas = columnas;
            this.llaves_primarias = llaves_primarias;
            this.fila = fila;
            this.columna = columna;
        }

        public object ejecutar(Entorno.Entorno ent)
        {
            if (Estatico.actualBase != null)
            {

                if (noexiste)
                {
                    if (!(Estatico.actualBase.existeTabla(nombre)))
                    {
                        Tabla nueva = this.crearTabla();
                        if (nueva != null)
                        {
                            //nueva.imprimirTabla();
                            Estatico.actualBase.nuevaTanbla(nombre, nueva);
                        }
                    }
                }
                else
                {
                    if (!(Estatico.actualBase.existeTabla(nombre)))
                    {
                        Tabla nueva = this.crearTabla();
                        if (nueva != null)
                        {
                            //nueva.imprimirTabla();
                            Estatico.actualBase.nuevaTanbla(nombre, nueva);
                        }
                    }
                    else
                    {
                        Estatico.errores.Add(new ErrorCQL("Ejecucion", "La tabla: " + nombre + " ya existe en la base: " + Estatico.actualBase.nombre, this.fila, this.columna));
                    }
                }

            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Ejecucion", "No hay base en uso", this.fila, this.columna));
            }
            return null;
        }

        public Tabla crearTabla()
        {
            bool existe_llave = false;
            int con = 0;
            foreach (Columna col in columnas)
            {
                if (col.primaria)
                {
                    existe_llave = true;
                    con++;
                }
            }
            if (existe_llave)
            {
                if (con == 1 && llaves_primarias.Count == 0)
                {
                    DataTable nueva = new DataTable();
                    DataColumn[] primarias = new DataColumn[1];
                    foreach (Columna col in this.columnas)
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
                        else if (col.tipo.tipo.Equals("counter"))
                        {
                            if (col.primaria == true)
                            {
                                ncol.DataType = typeof(int);
                                ncol.AutoIncrement = true;
                            }
                            else
                            {
                                Estatico.errores.Add(new ErrorCQL("Ejecucion", "Solo los campos llave primaria pueden ser tipo counter", this.fila, this.columna));
                                return null;
                            }
                        }
                        else
                        {
                            ncol.DataType = typeof(Objeto);
                        }
                        if (col.primaria)
                        {
                            this.llaves_primarias.AddLast(col.nombre);
                            primarias[0] = ncol;
                        }
                        nueva.Columns.Add(ncol);
                    }

                    nueva.PrimaryKey = primarias;
                    return new Tabla(nombre, nueva, llaves_primarias, this.columnas);

                }
                else
                {
                    Estatico.errores.Add(new ErrorCQL("Ejecucion", "Solo debe de haber una llave primaria de lo contrario quitar primary key de los diferentes campos y utilizar una llave compuesta", this.fila, this.columna));
                }
            }
            else
            {
                if (llaves_primarias.Count == 0)
                {
                    DataTable nueva = new DataTable();

                    foreach (Columna col in this.columnas)
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
                        else if (col.tipo.tipo.Equals("counter"))
                        {
                            if (col.primaria == true)
                            {
                                ncol.DataType = typeof(int);
                                ncol.AutoIncrement = true;
                            }
                            else
                            {
                                Estatico.errores.Add(new ErrorCQL("Ejecucion", "Solo los campos llave primaria pueden ser tipo counter", this.fila, this.columna));
                                return null;
                            }
                        }
                        else
                        {
                            ncol.DataType = typeof(Objeto);
                        }

                        nueva.Columns.Add(ncol);
                    }
                    return new Tabla(nombre, nueva, llaves_primarias, this.columnas);
                }
                else
                {
                    DataTable nueva = new DataTable();
                    foreach (Columna col in this.columnas)
                    {
                        foreach (String prim in this.llaves_primarias)
                        {
                            if (col.nombre.Equals(prim))
                            {
                                col.primaria = true;
                            }
                        }
                    }

                    bool existecount = false;

                    foreach (Columna col in this.columnas)
                    {
                        if (col.tipo.tipo.Equals("counter"))
                        {
                            existecount = true;
                        }
                    }

                    if (existecount)
                    {
                        int todoscount = 0;
                        foreach (Columna col in this.columnas)
                        {
                            if (col.tipo.tipo.Equals("counter"))
                            {
                                todoscount++;
                            }
                        }
                        if (todoscount == llaves_primarias.Count)
                        {
                            DataColumn[] primarias = new DataColumn[this.llaves_primarias.Count];
                            int x = 0;

                            foreach (Columna col in this.columnas)
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
                                else if (col.tipo.tipo.Equals("counter"))
                                {
                                    ncol.DataType = typeof(int);
                                    ncol.AutoIncrement = true;
                                }
                                else
                                {
                                    ncol.DataType = typeof(Objeto);
                                }
                                if (col.primaria)
                                {
                                    primarias[x] = ncol;
                                    x++;
                                }
                                nueva.Columns.Add(ncol);
                            }
                            nueva.PrimaryKey = primarias;
                            return new Tabla(nombre, nueva, llaves_primarias, this.columnas);
                        }
                        else
                        {
                            Estatico.errores.Add(new ErrorCQL("Ejecucion", "Todos los campos de la llave compuesta deben ser tipo count o ninguno", this.fila, this.columna));
                            return null;
                        }
                    }
                    else
                    {

                        DataColumn[] primarias = new DataColumn[this.llaves_primarias.Count];
                        int x = 0;

                        foreach (Columna col in this.columnas)
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
                            else if (col.tipo.tipo.Equals("COUNT"))
                            {
                                ncol.DataType = typeof(int);
                                ncol.AutoIncrement = true;
                            }
                            else
                            {
                                ncol.DataType = typeof(Objeto);
                            }
                            if (col.primaria)
                            {
                                primarias[x] = ncol;
                                x++;
                            }
                            nueva.Columns.Add(ncol);
                        }
                        nueva.PrimaryKey = primarias;
                        return new Tabla(nombre, nueva, llaves_primarias, this.columnas);
                    }
                }
            }

            return null;
        }


    }
}
