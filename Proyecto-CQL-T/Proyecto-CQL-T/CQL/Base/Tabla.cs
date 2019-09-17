using Proyecto_CQL_T.CQL.InterpreteCQL.SentenciasDBS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.Base
{
    class Tabla
    {
        public string nombre;
        public DataTable tabla;
        LinkedList<String> llaves_primarias;
        public LinkedList<Columna> columnas;
        public Tabla(string nombre, DataTable tabla, LinkedList<String> llaves_primarias, LinkedList<Columna> columnas)
        {
            this.nombre = nombre.ToLower();
            this.tabla = tabla;
            this.llaves_primarias = llaves_primarias;
            this.columnas = columnas;
        }

        public void imprimirTabla()
        {
            Console.WriteLine("--------------------- Inicio nombre columnas ----------------------");
            foreach (DataColumn col in tabla.Columns)
            {
                Console.WriteLine("columna : " + col.ColumnName);
            }
            Console.WriteLine("--------------------- Fin nombre columnas ----------------------");
        }


        public void imprimirTablaValores()
        {
            Console.WriteLine("--------------------- Inicio nombre columnas ----------------------");
            int x = 0;
            foreach (DataRow row in tabla.Rows)
            {
                Console.WriteLine("------------------ Columna " + x + " ----------------");
                foreach (DataColumn col in tabla.Columns)
                {
                    if (row[col].GetType() != typeof(System.DBNull))
                    {
                        Console.WriteLine("columna: " + col.ColumnName + " valor: " + row[col]);
                    }
                    else
                    {
                        Console.WriteLine("columna: " + col.ColumnName + " valor: nulo");
                    }

                }
                x++;
            }
            Console.WriteLine("--------------------- Fin nombre columnas ----------------------");
        }

        public bool existeColumna(string nombre)
        {
            return this.tabla.Columns.Contains(nombre);
        }

        public Columna GetColumna(string nombre)
        {
            foreach (Columna col in this.columnas)
            {
                if (col.nombre.Equals(nombre))
                {
                    return col;
                }
            }
            return null;
        }

        public bool esPrimaria(string nombre)
        {
            foreach (String st in this.llaves_primarias)
            {
                if (st.Equals(nombre))
                {
                    return true;
                }
            }
            return false;
        }

        public void eliminarColumna(string nombre)
        {
            this.tabla.Columns.Remove(nombre);
            Columna elim = null;
            foreach (Columna col in columnas)
            {
                if (col.nombre.Equals(nombre))
                {
                    elim = col;
                }
            }
            this.columnas.Remove(elim);

        }

        public void nuevaColumna(Columna nueva, DataColumn nuevacolumna)
        {
            this.tabla.Columns.Add(nuevacolumna);
            this.columnas.AddLast(nueva);
        }

        public void imprimirCountColumnas()
        {
            Console.WriteLine("--------------------- Inicio numero de columnas ----------------------");
            Console.WriteLine("Columnas en lista " + this.columnas.Count);
            Console.WriteLine("Columnas en tabla " + this.tabla.Columns.Count);
            Console.WriteLine("--------------------- Fin numero de columnas ----------------------");
        }

        public void vaciarTabla()
        {
            this.tabla.Rows.Clear();
        }

        public String GetTablaHTML()
        {
            String html = "<table class=\"table table-bordered\">";
            html += "<thead class=\"thead-dark\">";
            html += "<tr>";
            html += "<th scope=\"col\">#</th>";
            foreach (DataColumn col in tabla.Columns)
            {
                html += "<th scope=\"col\">" + col.ColumnName + "</th>";
            }
            html += "</tr>";
            html += "</thead>";
            html += "<tbody>";
            int x = 1;
            foreach (DataRow row in tabla.Rows)
            {
                html += "<tr class=\"bg-primary text-white\">";
                html += "<th scope=\"row\">" + x + "</th>";
                foreach (DataColumn col in tabla.Columns)
                {
                    if (row[col].GetType() != typeof(System.DBNull))
                    {
                        html += "<td>" + row[col] + "</td>";
                    }
                    else
                    {
                        html += "<td> </td>";
                    }

                }
                html += "</tr>";
                x++;
            }
            html += "</tbody>";
            html += "</table>";
            return html;
        }


    }
}
