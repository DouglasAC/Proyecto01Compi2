using Proyecto_CQL_T.CQL.AnalizadorCQL;
using Proyecto_CQL_T.CQL.Extras;
using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using Proyecto_CQL_T.CQL.InterpreteCQL.Colecciones;
using Proyecto_CQL_T.CQL.InterpreteCQL.Entorno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.ColeccionesFunciones
{
    class Insertar : Expresion
    {
        public Object coleccion;
        public Expresion valor;
        public Expresion clave;
        int fila;
        int columna;

        public Insertar(Expresion valor, int fila, int columna)
        {
            this.valor = valor;
            this.fila = fila;
            this.columna = columna;
        }
        public Insertar(Expresion valor, Expresion clave, int fila, int columna)
        {
            this.valor = valor;
            this.clave = clave;
            this.fila = fila;
            this.columna = columna;
        }

        public Tipo getTipo(Entorno.Entorno ent)
        {
            return new Tipo("null");
        }

        public object getValor(Entorno.Entorno ent)
        {
            if (coleccion != null)
            {
                if (coleccion is Lista)
                {
                    Lista l = (Lista)coleccion;
                    Object val = valor.getValor(ent);
                    Tipo tipo = valor.getTipo(ent);
                    bool ingreso = l.insertar(val, tipo);
                    if (!ingreso)
                    {
                        Estatico.errores.Add(new ErrorCQL("Semantico", "Error al insertar en la lista", this.fila, this.columna));
                    }
                }
                else if (coleccion is Map)
                {
                    Map m = (Map)coleccion;
                    Tipo tclave = clave.getTipo(ent);
                    Object vclave = clave.getValor(ent);
                    Tipo tvalor = valor.getTipo(ent);
                    Object vvalor = valor.getValor(ent);
                    bool ingreso = m.insertar(tvalor, vvalor, tclave, vclave);
                    if (!ingreso)
                    {
                        Estatico.errores.Add(new ErrorCQL("Semantico", "Error al insertar en la map", this.fila, this.columna));
                    }
                }
                else if (coleccion is Set)
                {
                    Set m = (Set)coleccion;
                    Object val = valor.getValor(ent);
                    Tipo tipo = valor.getTipo(ent);
                    bool ingreso = m.insertar(val, tipo);
                    if (!ingreso)
                    {
                        Estatico.errores.Add(new ErrorCQL("Semantico", "Error al insertar en la set", this.fila, this.columna));
                    }
                }
            }
            return null;
        }
    }
}
