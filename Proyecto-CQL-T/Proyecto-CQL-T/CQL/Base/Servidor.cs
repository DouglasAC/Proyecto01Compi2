using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.Base
{
    class Servidor
    {
        public Hashtable bases;
        public Hashtable usuarios;
        public Servidor()
        {
            bases = new Hashtable();
            usuarios = new Hashtable();
        }

        public void nuevaBase(string nombre, BaseDatos nueva)
        {
            bases.Add(nombre, nueva);
        }

        public bool existeBase(string nombre)
        {
            return bases.Contains(nombre);
        }

        public BaseDatos getBase(string nombre)
        {
            return (BaseDatos)(bases[nombre]);
        }

        public void eliminarBase(string nombre)
        {
            bases.Remove(nombre);
        }

        public bool existeUsuario(string nombre)
        {
            return usuarios.Contains(nombre);
        }

        public void nuevoUsuario(string nombre, Usuario nuevo)
        {
            this.usuarios.Add(nombre, nuevo);
        }

        public Usuario GetUsuario(string nombre)
        {
            return (Usuario)(usuarios[nombre]);
        }

    }
}
