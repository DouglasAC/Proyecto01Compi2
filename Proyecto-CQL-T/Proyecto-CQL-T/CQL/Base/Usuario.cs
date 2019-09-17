using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.Base
{
    class Usuario
    {
        public String nombre;
        public String clave;
        public HashSet<String> permisos;

        public Usuario(String nombre, String clave)
        {
            this.nombre = nombre;
            this.clave = clave;
            permisos = new HashSet<string>();
        }

        public void agregarPeermiso(string nuevo)
        {
            permisos.Add(nuevo);
        }

        public void quitarPermiso(string quitar)
        {
            permisos.Remove(quitar);
        }

        public bool tienePermiso(string nombre)
        {
            return permisos.Contains(nombre);
        }

    }
}
