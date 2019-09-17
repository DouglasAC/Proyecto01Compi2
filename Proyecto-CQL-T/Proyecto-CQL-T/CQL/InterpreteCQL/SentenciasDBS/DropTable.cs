using Proyecto_CQL_T.CQL.AnalizadorCQL;
using Proyecto_CQL_T.CQL.Extras;
using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.SentenciasDBS
{
    class DropTable : Instruccion
    {

        String nombre;
        bool noexiste;
        int fila;
        int columna;

        public DropTable(string nombre, bool noexiste, int fila, int columna)
        {
            this.nombre = nombre.ToLower();
            this.noexiste = noexiste;
            this.fila = fila;
            this.columna = columna;
        }

        public object ejecutar(Entorno.Entorno ent)
        {
            if (Estatico.actualBase != null)
            {

                if (noexiste)
                {
                    bool existe = Estatico.actualBase.existeTabla(nombre);
                    if (Estatico.actualBase.existeTabla(nombre))
                    {
                        Estatico.actualBase.eliminarTabla(nombre);
                    }
                }
                else
                {
                    if (Estatico.actualBase.existeTabla(nombre))
                    {
                        Estatico.actualBase.eliminarTabla(nombre);
                    }
                    else
                    {
                        Estatico.errores.Add(new ErrorCQL("Ejecucion", "La tabla: " + nombre + " no existe en la base: " + Estatico.actualBase.nombre, this.fila, this.columna));
                    }
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
