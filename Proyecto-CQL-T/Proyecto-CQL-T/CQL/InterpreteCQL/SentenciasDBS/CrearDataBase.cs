using Proyecto_CQL_T.CQL.AnalizadorCQL;
using Proyecto_CQL_T.CQL.Extras;
using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.SentenciasDBS
{
    class CrearDataBase : Instruccion
    {

        string nombre;
        bool noexiste;
        int fila;
        int columna;

        public CrearDataBase(string nombre, bool noexiste, int fila, int columna)
        {
            this.nombre = nombre.ToLower();
            this.noexiste = noexiste;
            this.fila = fila;
            this.columna = columna;
        }

        public object ejecutar(Entorno.Entorno ent)
        {
            if (noexiste)
            {
                if (!(Estatico.servidor.existeBase(nombre)))
                {
                    Estatico.servidor.nuevaBase(nombre, new Base.BaseDatos(nombre));
                    Estatico.actualUsuario.agregarPeermiso(nombre);
                }
            }
            else
            {
                if (!(Estatico.servidor.existeBase(nombre)))
                {
                    Estatico.servidor.nuevaBase(nombre, new Base.BaseDatos(nombre));
                    Estatico.actualUsuario.agregarPeermiso(nombre);
                }
                else
                {
                    Estatico.errores.Add(new ErrorCQL("Ejecucion", "Base de datos: " + nombre + " ya existe ", this.fila, this.columna));
                }
            }

            return null;
        }
    }
}
