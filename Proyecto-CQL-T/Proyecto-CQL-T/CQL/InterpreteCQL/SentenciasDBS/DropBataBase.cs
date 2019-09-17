using Proyecto_CQL_T.CQL.AnalizadorCQL;
using Proyecto_CQL_T.CQL.Extras;
using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.SentenciasDBS
{
    class DropBataBase : Instruccion
    {

        string nombre;
        int fila;
        int columna;

        public DropBataBase(string nombre, int fila, int columna)
        {
            this.nombre = nombre.ToLower();
            this.fila = fila;
            this.columna = columna;
        }

        public object ejecutar(Entorno.Entorno ent)
        {
            if (Estatico.servidor.existeBase(nombre))
            {
                Estatico.servidor.eliminarBase(nombre);
            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Ejecucion", "Base de datos: " + nombre + " no ya existe ", this.fila, this.columna));
            }
            return null;
        }
    }
}
