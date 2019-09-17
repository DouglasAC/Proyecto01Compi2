using Irony.Parsing;
using Proyecto_CQL_T.CQL.Base;
using Proyecto_CQL_T.CQL.Extras;
using Proyecto_CQL_T.CQL.Gramatica;
using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using Proyecto_CQL_T.CQL.InterpreteCQL.Entorno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.AnalizadorCQL
{
    class AnalizadorCQL
    {
        public void Analizar(String entrada)
        {
            GramaticaCQL gramatica = new GramaticaCQL();
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(entrada);
            ParseTreeNode raiz = arbol.Root;
            Estatico.errores = new List<ErrorCQL>();
            Estatico.mensajes = new List<String>();
            Estatico.servidor = new Servidor();
            obteErroes(arbol);


            if (raiz != null)
            {
                Graficador.Graficador grafo = new Graficador.Graficador();
                grafo.graficar(raiz);
                ConstruirAST constructor = new ConstruirAST(raiz);
                AST arbolAst = constructor.generarAst();
                Entorno ent = new Entorno(null);

                //-------- Prueba;
                BaseDatos prueba = new BaseDatos("prueba");
                Estatico.servidor.nuevaBase("prueba", prueba);
                Usuario admin = new Usuario("admin", "admin");
                Estatico.actualUsuario = admin;

                foreach (NodoAST sentencia in arbolAst.arbol)
                {
                    if (sentencia is Instruccion)
                    {
                        if (sentencia is Funcion)
                        {
                            Funcion fun = (Funcion)sentencia;

                            ent.agregar(fun.identificador, fun);
                        }

                    }
                    else if (sentencia is Expresion)
                    {

                    }
                }

                foreach (NodoAST sentencia in arbolAst.arbol)
                {
                    if (sentencia is Instruccion)
                    {
                        if (!(sentencia is Funcion))
                        {
                            Instruccion ins = (Instruccion)sentencia;
                            object valor = ins.ejecutar(ent);
                        }
                    }
                    else if (sentencia is Expresion)
                    {
                        Expresion exp = (Expresion)sentencia;
                        object valor = exp.getValor(ent);
                    }
                }

                //por el momento modificar al final
                

                ReporteErrores reporte = new ReporteErrores(Estatico.errores);
                reporte.writeReport();
            }
            else
            {
                Estatico.agregarMensaje("[+MESSAGE]raiz nula[-MESSAGE]");
                //MessageBox.Show("raiznula");

            }
        }

        private void obteErroes(ParseTree raiz)
        {
            for (int x = 0; x < raiz.ParserMessages.Count(); x++)
            {

                String mensajeEsperados = "";
                for (int y = 0; y < raiz.ParserMessages.ElementAt(x).ParserState.ExpectedTerminals.Count(); y++)
                {
                    mensajeEsperados += "| Simbolo: \"" + (String)raiz.ParserMessages.ElementAt(x).ParserState.ExpectedTerminals.ElementAt(y).ErrorAlias + "\"\n";
                }
                ErrorCQL error = new ErrorCQL("Sintatico", "Error Sintactico | Se esperaba: \n" + mensajeEsperados, raiz.ParserMessages.ElementAt(x).Location.Line, raiz.ParserMessages.ElementAt(x).Location.Column);
                Estatico.errores.Add(error);
            }
        }
    }
}
