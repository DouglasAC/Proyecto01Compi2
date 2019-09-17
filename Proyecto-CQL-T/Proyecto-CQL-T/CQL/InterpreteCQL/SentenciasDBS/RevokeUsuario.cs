using Proyecto_CQL_T.CQL.AnalizadorCQL;
using Proyecto_CQL_T.CQL.Extras;
using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.SentenciasDBS
{
    class RevokeUsuario : Instruccion
    {
        string nombre;
        string nombre_base;
        int fila;
        int columna;

        public RevokeUsuario(string nombre, string nombre_base, int fila, int columna)
        {
            this.nombre = nombre.ToLower();
            this.nombre_base = nombre_base.ToLower();
            this.fila = fila;
            this.columna = columna;
        }

        public object ejecutar(Entorno.Entorno ent)
        {
            if (Estatico.servidor.existeUsuario(nombre))
            {
                if (Estatico.servidor.existeBase(nombre_base))
                {
                    if (Estatico.servidor.GetUsuario(nombre).tienePermiso(nombre_base))
                    {
                        Estatico.servidor.GetUsuario(nombre).quitarPermiso(nombre_base);
                    }
                    else
                    {
                        Estatico.errores.Add(new ErrorCQL("Ejecucion", "El usuario: " + nombre + ",  no puesee perimiso en la base: " + nombre_base + ", por lo cual no se puede quitar el permiso", this.fila, this.columna));
                    }
                }
                else
                {
                    Estatico.errores.Add(new ErrorCQL("Ejecucion", "La base: " + nombre_base + ", no existe ", this.fila, this.columna));
                }
            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Ejecucion", "El usuario: " + nombre + ", no existe ", this.fila, this.columna));
            }
            return null;
        }
    }
}
