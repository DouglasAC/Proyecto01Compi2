using Proyecto_CQL_T.CQL.InterpreteCQL.Entorno;
using Proyecto_CQL_T.CQL.InterpreteCQL.ValorImplicito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.Colecciones
{
    class Map
    {
        Tipo tipo_clave;
        public Tipo tipo_valor;
        List<NodoMap> contenido;

        public Map(Tipo tipo_clave, Tipo tipo_valor, List<NodoMap> contenido) : this(tipo_clave, tipo_valor)
        {
            this.contenido = contenido;
        }

        public Map(Tipo tipo_clave, Tipo tipo_valor)
        {
            this.tipo_clave = tipo_clave;
            this.tipo_valor = tipo_valor;
            this.contenido = new List<NodoMap>();
        }

        public Boolean insertar(Tipo nuevo_tipo, Object nuevo_valor, Tipo clave, Object clave_valor)
        {
            if (clave.tipo.Equals(tipo_clave.tipo))
            {
                if (tipo_valor.tipo.Equals(nuevo_tipo.tipo))
                {
                    bool repite = false;
                    foreach (NodoMap nodo in contenido)
                    {
                        if (nodo.clave.ToString().Equals(clave_valor.ToString()))
                        {
                            repite = true;
                        }
                    }
                    if (!repite)
                    {
                        this.contenido.Add(new NodoMap(clave_valor, nuevo_valor));
                        return true;
                    }
                }
            }
            return false;
        }


        public Object getElemento(Object posicion)
        {
            foreach (NodoMap nodo in this.contenido)
            {
                if (nodo.clave.ToString().Equals(posicion.ToString()))
                {
                    return nodo.valor;
                }
            }
            return null;
        }

        public Boolean setElemento(Tipo nuevo_tipo, Object nuevo_valor, Tipo clave, Object clave_valor)
        {
            if (clave.tipo.Equals(tipo_clave.tipo))
            {
                if (tipo_valor.tipo.Equals(nuevo_tipo.tipo))
                {
                    foreach (NodoMap nodo in contenido)
                    {
                        if (nodo.clave.ToString().Equals(clave_valor.ToString()))
                        {
                            nodo.valor = nuevo_valor;
                            return true;
                        }
                    }

                }
            }
            return false;
        }

        public Boolean remove(Tipo clave, Object clave_valor)
        {
            if (clave.tipo.Equals(tipo_clave.tipo))
            {
                int x = 0;
                int posicion = 0;
                bool encontro = false;
                foreach (NodoMap nodo in contenido)
                {
                    if (nodo.clave.ToString().Equals(clave_valor.ToString()))
                    {
                        posicion = x;
                        encontro = true;
                    }
                    x++;
                }
                if (encontro)
                {
                    contenido.RemoveAt(posicion);
                    return true;
                }

            }
            return false;
        }

        public int tamano()
        {
            return contenido.Count;
        }

        public void vaciar()
        {
            contenido.Clear();
        }

        public Boolean contiene(Object posicion)
        {
            foreach (NodoMap nodo in this.contenido)
            {
                if (nodo.clave.ToString().Equals(posicion.ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            String cad = "[";
            bool primero = true;
            foreach (NodoMap nodo in contenido)
            {
                if (!primero)
                {
                    cad += ", ";
                }
                if (nodo.clave is String)
                {
                    cad += "\"" + nodo.clave.ToString() + "\"" + " : ";
                }
                else if (nodo.clave is Date || nodo.clave is Tiempo)
                {
                    cad += "\'" + nodo.clave.ToString() + "\'" + " : ";
                }
                else
                {
                    cad += nodo.clave.ToString() + " : ";
                }
                if (nodo.valor is string)
                {
                    cad += "\"" + nodo.valor.ToString() + "\"";
                }
                else if (nodo.valor is Date || nodo.clave is Tiempo)
                {
                    cad += "\'" + nodo.valor.ToString() + "\'";
                }
                else
                {
                    cad += nodo.valor.ToString();
                }





                primero = false;
            }
            cad += "]";
            return cad;
        }
    }
}
