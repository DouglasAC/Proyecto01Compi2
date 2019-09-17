using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.Entorno
{
    class Objeto : Simbolo
    {
        Tipo tipo;
        public Entorno atributos;

        public Objeto(Tipo tipo, String identificador, Entorno atributos) : base(identificador, tipo)
        {
            this.tipo = tipo;
            this.atributos = atributos;
        }


        public void imprimirAtributos()
        {

            Console.WriteLine("----- Inicio Tabla -----");
            foreach (DictionaryEntry item in this.atributos.tabla)
            {
                Simbolo sim = (Simbolo)(item.Value);
                Console.WriteLine("atributo: " + sim.identificador + " Tipo: " + sim.tipo.tipo + " Valor: " + sim.valor.ToString());
            }
            Console.WriteLine("----- Fin Tabla -----");

        }


        public override string ToString()
        {
            String cad = "{ ";
            bool primero = true;
            foreach (DictionaryEntry item in this.atributos.tabla)
            {
                Simbolo sim = (Simbolo)(item.Value);
                if (primero)
                {
                    cad += sim.identificador + " : " + sim.valor;
                    primero = false;
                }
                else
                {
                    cad += ", " + sim.identificador + " : " + sim.valor;
                }
            }
            cad += "} AS " + this.tipo.tipo;
            return cad;
        }
    }
}
