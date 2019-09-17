using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.Entorno
{
    class Simbolo
    {


        public String identificador { get; set; }

        public Object valor { get; set; }

        public Tipo tipo { get; set; }

        public LinkedList<Simbolo> parametros { get; set; }

        public Boolean funcion { get; set; }

        public Simbolo(String identificador)
        {
            this.identificador = identificador;
            this.funcion = false;
        }

        public Simbolo(String identificador, Tipo tipo)
        {
            this.identificador = identificador;
            this.tipo = tipo;
            this.funcion = false;
        }

        public Simbolo(String identificador, Tipo tipo, Object valor)
        {
            this.identificador = identificador;
            this.tipo = tipo;
            this.valor = valor;
            this.funcion = false;
        }

        public Simbolo(String identificador, Tipo tipo, LinkedList<Simbolo> parametros)
        {
            this.identificador = identificador;
            this.tipo = tipo;
            this.parametros = parametros;
            this.funcion = true;
        }

    }
}
