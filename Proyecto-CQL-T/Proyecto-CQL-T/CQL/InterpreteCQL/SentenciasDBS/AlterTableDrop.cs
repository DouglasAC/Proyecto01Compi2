using Proyecto_CQL_T.CQL.AnalizadorCQL;
using Proyecto_CQL_T.CQL.Base;
using Proyecto_CQL_T.CQL.Extras;
using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.SentenciasDBS
{
    class AlterTableDrop : Instruccion
    {
        String nombre_tabla;
        LinkedList<String> columnas_eliminar;
        int fila;
        int columna;

        public AlterTableDrop(string nombre_tabla, LinkedList<string> columnas_eliminar, int fila, int columna)
        {
            this.nombre_tabla = nombre_tabla.ToLower();
            this.columnas_eliminar = columnas_eliminar;
            this.fila = fila;
            this.columna = columna;
        }

        public object ejecutar(Entorno.Entorno ent)
        {

            if (Estatico.actualBase != null)
            {
                if (Estatico.actualBase.existeTabla(nombre_tabla))
                {
                    Tabla actual = Estatico.actualBase.getTabla(nombre_tabla);
                    bool todosexisten = true;
                    foreach (String columna in this.columnas_eliminar)
                    {
                        if (!actual.existeColumna(columna))
                        {
                            todosexisten = false;
                            Estatico.errores.Add(new ErrorCQL("Ejecucion", "En la tabla: " + nombre_tabla + ", no existe en la columna: " + columna + " por lo tanto no se puede eliminar", this.fila, this.columna));
                        }
                    }

                    if (todosexisten)
                    {
                        bool noprimarias = true;
                        foreach (String columna in this.columnas_eliminar)
                        {
                            if (actual.esPrimaria(columna))
                            {
                                noprimarias = false;
                                Estatico.errores.Add(new ErrorCQL("Ejecucion", "En la tabla: " + nombre_tabla + ", la columna: " + columna + ", es llave primaria por lo tanto no se puede eliminar", this.fila, this.columna));
                            }
                        }
                        if (noprimarias)
                        {
                            foreach (String columna in this.columnas_eliminar)
                            {
                                actual.eliminarColumna(columna);
                            }
                        }
                    }

                    //Estatico.actualBase.getTabla(nombre_tabla).imprimirTabla();
                    //Estatico.actualBase.getTabla(nombre_tabla).imprimirCountColumnas();
                }
                else
                {
                    Estatico.errores.Add(new ErrorCQL("Ejecucion", "La tabla: " + nombre_tabla + " no existe en la base: " + Estatico.actualBase.nombre, this.fila, this.columna));
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
