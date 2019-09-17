using Proyecto_CQL_T.CQL.InterpreteCQL.Entorno;
using Proyecto_CQL_T.CQL.InterpreteCQL.ValorImplicito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.Colecciones
{
    class Set
    {
        List<Object> contenido;
        public Tipo tipointerno;

        public Set(List<object> contenido, Tipo tipointerno)
        {
            this.contenido = contenido;
            this.tipointerno = tipointerno;
        }

        public Set(Tipo tipointerno)
        {
            this.contenido = new List<object>();
            this.tipointerno = tipointerno;
        }

        public Boolean insertar(Object nuevo, Tipo tiponuevo)
        {
            if (this.tipointerno.tipo.Equals(tiponuevo.tipo))
            {
                bool existe = this.existe(nuevo);
                if (!existe)
                {
                    contenido.Add(nuevo);
                    try
                    {
                        this.contenido.Sort();
                    }
                    catch (Exception e)
                    {

                    }

                    return true;
                }
            }
            return false;
        }

        public Boolean existe(Object nuevo)
        {
            foreach (Object ob in this.contenido)
            {
                if (ob.Equals(nuevo))
                {
                    return true;
                }
            }
            return false;
        }

        public Object getElemento(int posicion)
        {
            if (posicion < this.contenido.Count)
            {
                return contenido[posicion];
            }
            return null;
        }

        public Boolean setElemento(int posicion, Object nuevo, Tipo tiponuevo)
        {
            if (posicion < this.contenido.Count)
            {
                if (this.tipointerno.tipo.Equals(tiponuevo.tipo))
                {
                    bool existe = this.existe(nuevo);
                    if (!existe)
                    {
                        contenido[posicion] = nuevo;
                        this.contenido.Sort();
                        return true;
                    }

                }

            }
            return false;
        }

        public Boolean remove(int posicion)
        {
            if (posicion < this.contenido.Count)
            {
                contenido.RemoveAt(posicion);
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

        public Boolean contiene(Object contenido, Tipo tipocontenido)
        {

            if (tipocontenido.tipo.Equals(tipointerno.tipo))
            {
                foreach (Object nodo in this.contenido)
                {
                    if (nodo is int)
                    {
                        if ((int)nodo == (int)contenido)
                        {
                            return true;
                        }
                    }
                    else if (nodo is double)
                    {
                        if ((double)nodo == (double)contenido)
                        {
                            return true;
                        }
                    }
                    else if (nodo is String)
                    {
                        if (((String)nodo).Equals((String)contenido))
                        {
                            return true;
                        }
                    }
                    else if (nodo is Boolean)
                    {
                        if ((Boolean)nodo == (Boolean)contenido)
                        {
                            return true;
                        }
                    }
                    else if (nodo is Date)
                    {
                        if (((Date)nodo).ToString().Equals(((Date)contenido).ToString()))
                        {
                            return true;
                        }
                    }
                    else if (nodo is Tiempo)
                    {
                        if (((Tiempo)nodo).ToString().Equals(((Tiempo)contenido).ToString()))
                        {
                            return true;
                        }
                    }
                }
            }
            else if (tipocontenido.tipo.Equals("int") && tipointerno.tipo.Equals("double"))
            {
                int valor = (int)contenido;
                double valor2 = Convert.ToDouble(valor);
                foreach (Object nodo in this.contenido)
                {
                    if ((double)nodo == valor2)
                    {
                        return true;
                    }
                }
            }
            else if (tipointerno.tipo.Equals("int") && tipocontenido.tipo.Equals("double"))
            {
                double valor = (double)contenido;
                int valor2 = Convert.ToInt32(valor);
                foreach (Object nodo in this.contenido)
                {
                    if ((int)nodo == valor2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override string ToString()
        {
            String cad = "{";
            bool primero = true;
            foreach (Object nodo in contenido)
            {
                if (!primero)
                {
                    cad += ", ";
                }
                if (nodo is String)
                {
                    cad += "\"" + nodo.ToString() + "\"";
                }
                else if (nodo is Date || nodo is Tiempo)
                {
                    cad += "\'" + nodo.ToString() + "\'";
                }
                else
                {
                    cad += nodo.ToString();
                }
                primero = false;
            }
            cad += "}";
            return cad;
        }

    }
}
