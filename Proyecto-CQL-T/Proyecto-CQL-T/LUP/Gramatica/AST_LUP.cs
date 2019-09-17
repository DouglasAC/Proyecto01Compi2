using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.LUP.Gramatica
{
    class AST_LUP
    {
        public LinkedList<LUP> Construr(ParseTreeNode raiz)
        {
            return (LinkedList<LUP>)auxiliar(raiz);
        }

        public object auxiliar(ParseTreeNode actual)
        {
            if (EstoyAca(actual, "init"))
            {
                return auxiliar(actual.ChildNodes[0]);
            }
            else if (EstoyAca(actual, "paquetes"))
            {
                LinkedList<LUP> paquetes = new LinkedList<LUP>();
                foreach (ParseTreeNode hijo in actual.ChildNodes)
                {
                    paquetes.AddLast((LUP)auxiliar(hijo));
                }
                return paquetes;
            }
            else if (EstoyAca(actual, "paquete"))
            {
                return auxiliar(actual.ChildNodes[0]);
            }
            else if (EstoyAca(actual, "login"))
            {
                return new LUP(getData(actual, 2), "login", getData(actual, 5)); ;
            }
            else if (EstoyAca(actual, "logout"))
            {
                return new LUP(getData(actual, 2), "logout"); ;
            }
            else if (EstoyAca(actual, "query"))
            {
                String data = getData(actual, 4);
                data = data.Substring(7);
                data = data.Substring(0, data.Length - 7);
                return new LUP(getData(actual, 2), "query", data); ;
            }
            else if (EstoyAca(actual, "bases"))
            {
                return new LUP(getData(actual, 2), "struct"); ;
            }
            return null;
        }

        static bool comparar(string a, string b)
        {
            return (a.Equals(b, System.StringComparison.InvariantCultureIgnoreCase));
        }

        static bool EstoyAca(ParseTreeNode nodo, string nombre)
        {
            return nodo.Term.Name.Equals(nombre, System.StringComparison.InvariantCultureIgnoreCase);
        }

        static string getData(ParseTreeNode nodo, int num)
        {
            return nodo.ChildNodes[num].Token.Text;
        }

    }
}

