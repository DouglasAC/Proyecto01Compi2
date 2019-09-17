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
    class Use : Instruccion
    {
        string nombre;
        int fila;
        int columna;

        public Use(string nombre, int fila, int columna)
        {
            this.nombre = nombre.ToLower();
            this.fila = fila;
            this.columna = columna;
        }

        public object ejecutar(Entorno.Entorno ent)
        {
            if (Estatico.servidor.existeBase(nombre))
            {
                BaseDatos usar = Estatico.servidor.getBase(nombre);
                if (Estatico.actualUsuario.nombre.Equals("admin"))
                {
                    Estatico.actualBase = usar;
                }
                else if (Estatico.actualUsuario.tienePermiso(nombre))
                {
                    Estatico.actualBase = usar;
                }
                else
                {
                    Estatico.errores.Add(new ErrorCQL("Ejecucion", "El usuario: " + Estatico.actualUsuario.nombre + " No tiene permisos en la base: " + usar.nombre, this.fila, this.columna));
                }
            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Ejecucion", "La base: " + nombre + " no existe", this.fila, this.columna));
            }

            return null;
        }
    }
}
