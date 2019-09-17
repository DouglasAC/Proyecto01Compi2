using Proyecto_CQL_T.CQL.InterpreteCQL.Entorno;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.Base
{
    class BaseDatos
    {

        public Hashtable ObjetosDefinido { get; set; }
        public String nombre;
        public Hashtable Tablas;
        public BaseDatos(string nombre)
        {
            this.nombre = nombre.ToLower();
            this.ObjetosDefinido = new Hashtable();
            this.Tablas = new Hashtable();
        }

        public void agregarObjetoDefinido(String identificador, ObjetoDefinido nuevo)
        {
            this.ObjetosDefinido.Add(identificador, nuevo);
        }

        public bool existeObjetoDefinido(String identificador)
        {
            return this.ObjetosDefinido.ContainsKey(identificador);
        }

        public ObjetoDefinido GetObjetoDefinido(string identificador)
        {
            return (ObjetoDefinido)ObjetosDefinido[identificador];
        }

        public bool existeTabla(string nombre)
        {
            return this.Tablas.ContainsKey(nombre);
        }

        public void nuevaTanbla(string nombre, Tabla nueva)
        {
            this.Tablas.Add(nombre, nueva);
        }

        public void eliminarTabla(string nombre)
        {
            this.Tablas.Remove(nombre);
        }

        public Tabla getTabla(string tabla)
        {
            return (Tabla)this.Tablas[tabla];
        }

        public void imprimirDefiniciones()
        {
            Console.WriteLine("----- Inicio Definicion -----");
            Console.WriteLine("* Base Nombre: " + this.nombre);
            foreach (DictionaryEntry item in ObjetosDefinido)
            {
                ObjetoDefinido sim = (ObjetoDefinido)(item.Value);
                Console.WriteLine("** Deficnion nombre: " + sim.identificador);
            }
            Console.WriteLine("----- Fin Definicion -----");
        }

    }
}
