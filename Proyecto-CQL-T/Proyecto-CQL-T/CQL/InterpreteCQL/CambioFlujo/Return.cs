using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using Proyecto_CQL_T.CQL.InterpreteCQL.Entorno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.CambioFlujo
{
    class Return : Expresion
    {

        Expresion valor;

        LinkedList<Expresion> valores;
        public Object retorno;
        public LinkedList<NodoReturn> retornos;
        public Return()
        {
            this.valor = null;
            this.valores = null;
        }

        public Return(Expresion valor)
        {
            this.valor = valor;
            this.valores = null;
        }

        public Return(LinkedList<Expresion> valores)
        {
            this.valor = null;
            this.valores = valores;
        }


        public Tipo getTipo(Entorno.Entorno ent)
        {
            if (valor != null)
            {
                return valor.getTipo(ent);
            }
            else if (valores != null)
            {
                return new Tipo("procedure");
            }

            return new Tipo("nulo");
        }

        public object getValor(Entorno.Entorno ent)
        {
            if (valor != null)
            {
                object val = valor.getValor(ent);
                retorno = val;
                return this;
            }
            else if (valores != null)
            {
                retornos = new LinkedList<NodoReturn>();
                foreach (Expresion exp in valores)
                {
                    Object val = exp.getValor(ent);
                    Tipo tipo = exp.getTipo(ent);
                    retornos.AddLast(new NodoReturn(tipo, val));
                }
                return this;
            }
            return this;
        }
    }
}
