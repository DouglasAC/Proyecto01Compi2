using Proyecto_CQL_T.CQL.AnalizadorCQL;
using Proyecto_CQL_T.CQL.Extras;
using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.SentenciasDBS
{
    class TruncateTable : Instruccion
    {
        string nombre;
        int fila;
        int columna;

        public TruncateTable(string nombre, int fila, int columna)
        {
            this.nombre = nombre;
            this.fila = fila;
            this.columna = columna;
        }

        public object ejecutar(Entorno.Entorno ent)
        {
            if (Estatico.actualBase != null)
            {
                if (Estatico.actualBase.existeTabla(nombre))
                {
                    Estatico.actualBase.getTabla(nombre).vaciarTabla();
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
    }
}
