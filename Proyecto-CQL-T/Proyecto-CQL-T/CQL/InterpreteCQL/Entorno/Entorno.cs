using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.Entorno
{
    class Entorno
    {
        public Hashtable tabla { get; set; }

        public Entorno anterior { get; set; }

        public Entorno(Entorno anterior)
        {
            this.tabla = new Hashtable();
            this.anterior = anterior;
        }

        public void agregar(String id, Simbolo simbolo)
        {
            this.tabla.Add(id, simbolo);
        }

        public bool existe(String id)
        {
            for (Entorno e = this; e != null; e = e.anterior)
            {
                if (e.tabla.Contains(id))
                {
                    return true;
                }
            }
            return false;
        }
        public bool existeEnActual(String id)
        {
            Simbolo encontrado = (Simbolo)(this.tabla[id]);
            return encontrado != null;
        }

        public Simbolo get(String id)
        {
            for (Entorno e = this; e != null; e = e.anterior)
            {
                Simbolo encontrado = (Simbolo)(e.tabla[id]);
                if (encontrado != null)
                {
                    return encontrado;
                }
            }
            Console.WriteLine("El simbolo \"" + id + "\" no ha sido declarado en el entorno actual ni en alguno externo");
            return null;
        }

        public void reemplazar(String id, Simbolo nuevoValor)
        {
            for (Entorno e = this; e != null; e = e.anterior)
            {
                Simbolo encontrado = (Simbolo)(e.tabla[id]);
                if (encontrado != null)
                {
                    tabla[id] = nuevoValor;
                }
            }
            Console.WriteLine("El simbolo \"" + id + "\" no ha sido declarado en el entorno actual ni en alguno externo");
        }

        public void imprimir()
        {
            Console.WriteLine("----- Inicio Tabla -----");
            foreach (DictionaryEntry item in tabla)
            {
                Simbolo sim = (Simbolo)(item.Value);
                Console.WriteLine("Simbolo: " + sim.identificador + " Tipo: " + sim.tipo.tipo + " Valor: " + sim.valor.ToString());
            }
            Console.WriteLine("----- Fin Tabla -----");
        }

        public Entorno gloval()
        {
            Entorno e;
            for (e = this; e != null; e = e.anterior)
            {
                if (e.anterior == null)
                {
                    return e;
                }
            }
            return e;
        }
    }
}
