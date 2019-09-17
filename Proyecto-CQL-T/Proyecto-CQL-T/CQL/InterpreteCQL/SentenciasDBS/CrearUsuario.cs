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
    class CrearUsuario : Instruccion
    {
        string nombre;
        string clave;
        int fila;
        int columna;
        public CrearUsuario(string nombre, string clave, int fila, int columna)
        {
            this.nombre = nombre.ToLower();
            this.clave = clave.ToLower();
            this.fila = fila;
            this.columna = columna;
        }

        public object ejecutar(Entorno.Entorno ent)
        {
            if (!Estatico.servidor.existeUsuario(nombre))
            {
                Estatico.servidor.nuevoUsuario(nombre, new Usuario(nombre, clave));
            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Ejecucion", "El usuario: " + nombre + " ya existe por lo tanto no se puede crear ", this.fila, this.columna));
            }
            return null;
        }
    }
}
