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
    class InstanciarObjeto : Expresion
    {

        public Tipo tipo;
        public LinkedList<Expresion> valores_obejeto;
        public bool valores;
        public int fila;
        public int columna;

        public InstanciarObjeto(Tipo tipo, int fila, int columna)
        {
            this.tipo = tipo;
            this.fila = fila;
            this.columna = columna;
            this.valores = false;
        }

        public InstanciarObjeto(Tipo tipo, LinkedList<Expresion> valores_obejeto, int fila, int columna)
        {
            this.tipo = tipo;
            this.valores_obejeto = valores_obejeto;
            this.fila = fila;
            this.columna = columna;
            this.valores = true;
        }

        public Tipo getTipo(Entorno.Entorno ent)
        {

            Object val = getValor(ent);
            if (val is Objeto)
            {
                Objeto obj = (Objeto)val;
                return obj.tipo;
            }
            return new Tipo("null");
        }

        public object getValor(Entorno.Entorno ent)
        {

            if (Estatico.actualBase != null)
            {

                if (Estatico.actualBase.existeObjetoDefinido(tipo.tipo))
                {
                    if (!valores)
                    {
                        ObjetoDefinido declarar = Estatico.actualBase.GetObjetoDefinido(tipo.tipo);
                        Entorno.Entorno atributos = new Entorno.Entorno(null);
                        foreach (Declaracion declaracion in declarar.declaraciones)
                        {
                            declaracion.ejecutar(atributos);
                        }
                        Objeto ob = new Objeto(tipo, tipo.tipo, atributos);
                        //ob.imprimirAtributos();
                        return ob;
                    }
                    else
                    {
                        //Console.Write("entro aaaaaaaaaaaaaa");
                        ObjetoDefinido declarar = Estatico.actualBase.GetObjetoDefinido(tipo.tipo);
                        if (declarar.declaraciones.Count == valores_obejeto.Count)
                        {
                            Entorno.Entorno atributos = new Entorno.Entorno(ent);
                            int x = 0;
                            foreach (Declaracion declaracion in declarar.declaraciones)
                            {
                                declaracion.valorInicial = valores_obejeto.ElementAt(x);
                                declaracion.ejecutar(atributos);
                                x++;
                            }
                            Entorno.Entorno atributos2 = new Entorno.Entorno(null);
                            atributos2.tabla = atributos.tabla;
                            Objeto ob = new Objeto(tipo, tipo.tipo, atributos2);
                            ob.imprimirAtributos();
                            //atributos.imprimir();
                            return ob;
                        }
                        else
                        {
                            Estatico.errores.Add(new ErrorCQL("Ejecucion", "Faltan valores en el objeto: " + tipo.tipo + " en la base: " + Estatico.actualBase.nombre, this.fila, this.columna));
                        }


                    }
                }
                else
                {
                    Estatico.errores.Add(new ErrorCQL("Ejecucion", "No existe el objeto: " + tipo.tipo + " en la base: " + Estatico.actualBase.nombre, this.fila, this.columna));
                }
            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Ejecucion", "No hay base en uso", this.fila, this.columna));
            }
            return new Nulo();
        }
    }
}
