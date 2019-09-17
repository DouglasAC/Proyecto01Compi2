using Irony.Parsing;
using Proyecto_CQL_T.LUP.Gramatica;
using Proyecto_CQL_T.Graficador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto_CQL_T.CQL.AnalizadorCQL;
using Proyecto_CQL_T.CQL.Extras;

namespace Proyecto_CQL_T.LUP
{
    public class AnalizadorLUP
    {

        public String analizar(String entrada)
        {
            Gramatica.Gramatica gramatica = new Gramatica.Gramatica();
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(entrada);
            ParseTreeNode raiz = arbol.Root;
            string respuesta = "";
            if (raiz != null)
            {
                Graficador.Graficador grafo = new Graficador.Graficador();
                grafo.graficar(raiz);
                AST_LUP ast = new AST_LUP();
                LinkedList<LUP> lista = ast.Construr(raiz);
                
                foreach (LUP lup in lista)
                {
                    if (lup.tipo.Equals("query"))
                    {
                        AnalizadorCQL cql = new AnalizadorCQL();
                        cql.Analizar(lup.data);
                        foreach (String men in Estatico.mensajes)
                        {
                            respuesta += men;
                        }
                    }
                    else if (lup.tipo.Equals("login"))
                    {
                        respuesta = "[+LOGIN]SUCCESS[-LOGIN]";
                    }
                    else if (lup.tipo.Equals("logout"))
                    {
                        respuesta = "[+LOGOUT]SUCCESS[-LOGOUT]";
                    }
                    else if (lup.tipo.Equals("bases"))
                    {
                        respuesta = "[+message]SE PIDIO BASES[-message]";
                    }
                }

            }
            else
            {
                respuesta = "[+message]SE PIDIO BASES[-message]";
            }
            return respuesta;
        }
    }
}
