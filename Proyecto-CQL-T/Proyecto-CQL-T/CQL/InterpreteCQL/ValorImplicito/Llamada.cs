using Proyecto_CQL_T.CQL.AnalizadorCQL;
using Proyecto_CQL_T.CQL.Extras;
using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using Proyecto_CQL_T.CQL.InterpreteCQL.Entorno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.ValorImplicito
{
    class Llamada : Expresion
    {

        private string identificador;
        private LinkedList<Expresion> valores;
        int fila;
        int columna;

        public Llamada(string identificador, int fila, int columna)
        {
            this.identificador = identificador.ToLower();
            this.valores = new LinkedList<Expresion>();
            this.fila = fila;
            this.columna = columna;
        }

        public Llamada(String identificador, LinkedList<Expresion> valores, int fila, int columna)
        {
            this.identificador = identificador.ToLower();
            this.valores = valores;
            this.fila = fila;
            this.columna = columna;
        }
        public Tipo getTipo(Entorno.Entorno ent)
        {
            String nombre = this.identificador + "_";
            if (valores != null)
            {
                foreach (Expresion exp in this.valores)
                {
                    Tipo t = exp.getTipo(ent);
                    nombre += t.tipo + "_";
                }
            }
            if (ent.existe(nombre))
            {
                Funcion funcion = (Funcion)ent.get(nombre);
                return funcion.tipo;

            }
            else
            {
                return new Tipo("null");
            }
        }

        public object getValor(Entorno.Entorno ent)
        {
            String nombre = this.identificador + "_";
            if (valores != null)
            {
                foreach (Expresion exp in this.valores)
                {
                    Tipo t = exp.getTipo(ent);
                    nombre += t.tipo + "_";
                }
            }
            if (ent.existe(nombre))
            {
                Funcion funcion = (Funcion)ent.get(nombre);
                Entorno.Entorno global = ent.gloval();
                Entorno.Entorno local = new Entorno.Entorno(global);
                if (verificarParametros(valores, funcion.parametros, local, ent))
                {
                    Object val = funcion.ejecutar(local);

                    return val;
                }
            }
            else
            {

                Estatico.errores.Add(new ErrorCQL("Semantico", "Error en la funcion " + identificador + " no tiene la misma cantidad de parametros o los tipos de parametro no coinciden o no existe", this.fila, this.columna));
            }
            return null;
        }


        bool verificarParametros(LinkedList<Expresion> valores, LinkedList<Simbolo> parametros, Entorno.Entorno ent, Entorno.Entorno actual)
        {

            if (valores.Count == parametros.Count)
            {
                for (int i = 0; i < parametros.Count; i++)
                {




                    if (parametros.ElementAt(i).tipo.tipo.Equals(valores.ElementAt(i).getTipo(actual).tipo))
                    {
                        parametros.ElementAt(i).valor = valores.ElementAt(i).getValor(actual);
                        ent.agregar(parametros.ElementAt(i).identificador, parametros.ElementAt(i));
                    }
                    else
                    {
                        Estatico.errores.Add(new ErrorCQL("Semantico", "Llamada el tipo de los parametros no coinciden con los de la funcion ", this.fila, this.columna));
                        return false;
                    }
                }
                return true;
            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Semantico", "Llamada la cantidad de parametros no coincide ", this.fila, this.columna));
            }
            return false;
        }
    }
}
