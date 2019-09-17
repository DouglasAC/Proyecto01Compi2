using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using Proyecto_CQL_T.CQL.InterpreteCQL.Colecciones;
using Proyecto_CQL_T.CQL.InterpreteCQL.Entorno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.ValorImplicito
{
    class Identificador : Expresion
    {

        public String identificador;
        int fila;
        int columna;

        public Identificador(String identificador, int fila, int columna)
        {
            this.identificador = identificador.ToLower();
            this.fila = fila;
            this.columna = columna;
        }

        public Tipo getTipo(Entorno.Entorno ent)
        {
            Object valor = this.getValor(ent);
            if (valor is int)
            {
                return new Tipo("int");
            }
            else if (valor is double)
            {
                return new Tipo("double");
            }
            else if (valor is String)
            {
                return new Tipo("string");
            }
            else if (valor is Boolean)
            {
                return new Tipo("bool");
            }
            else if (valor is Date)
            {
                return new Tipo("date");
            }
            else if (valor is Tiempo)
            {
                return new Tipo("time");
            }
            else if (valor is Lista)
            {
                return new Tipo("list");
            }
            else if (valor is Map)
            {
                return new Tipo("map");
            }
            else if (valor is Set)
            {
                return new Tipo("set");
            }
            else if (valor is Objeto)
            {
                Objeto obj = (Objeto)valor;
                return obj.tipo;
            }

            return new Tipo("null");
        }

        public object getValor(Entorno.Entorno ent)
        {
            Simbolo aux = ent.get(this.identificador.ToLower());
            if (aux is Objeto)
            {
                Objeto axus = (Objeto)aux;
                return axus;
            }
            return aux != null ? aux.valor : null;
        }
    }
}
