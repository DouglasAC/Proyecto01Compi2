using Proyecto_CQL_T.CQL.AnalizadorCQL;
using Proyecto_CQL_T.CQL.Extras;
using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.Entorno
{
    class DefinirObjeto : Instruccion
    {
        public string identificador;
        public LinkedList<Declaracion> atributos;
        public bool noexiste;
        public int fila;
        public int columna;

        public DefinirObjeto(string identificador, LinkedList<Declaracion> atributos, bool noexiste, int fila, int columna)
        {
            this.identificador = identificador.ToLower();
            this.atributos = atributos;
            this.fila = fila;
            this.columna = columna;
            this.noexiste = noexiste;
        }

        public object ejecutar(Entorno ent)
        {
            if (Estatico.actualBase != null)
            {
                if (noexiste)
                {
                    if (!(Estatico.actualBase.existeObjetoDefinido(identificador)))
                    {
                        Estatico.actualBase.agregarObjetoDefinido(identificador, new ObjetoDefinido(atributos, identificador));
                    }
                }
                else
                {
                    if (!(Estatico.actualBase.existeObjetoDefinido(identificador)))
                    {
                        Estatico.actualBase.agregarObjetoDefinido(identificador, new ObjetoDefinido(atributos, identificador));
                    }
                    else
                    {
                        Estatico.errores.Add(new ErrorCQL("Ejecucion", "User type: " + identificador + " ya existe en la base: " + Estatico.actualBase.nombre, this.fila, this.columna));
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
