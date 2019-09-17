using Irony.Parsing;
using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using Proyecto_CQL_T.CQL.InterpreteCQL.CambioFlujo;
using Proyecto_CQL_T.CQL.InterpreteCQL.Ciclos;
using Proyecto_CQL_T.CQL.InterpreteCQL.Colecciones;
using Proyecto_CQL_T.CQL.InterpreteCQL.ColeccionesFunciones;
using Proyecto_CQL_T.CQL.InterpreteCQL.ControldeFlujo;
using Proyecto_CQL_T.CQL.InterpreteCQL.Entorno;
using Proyecto_CQL_T.CQL.InterpreteCQL.FuncionesPrimitivas;
using Proyecto_CQL_T.CQL.InterpreteCQL.FuncionNativa;
using Proyecto_CQL_T.CQL.InterpreteCQL.SentenciasDBS;
using Proyecto_CQL_T.CQL.InterpreteCQL.ValorImplicito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.Gramatica
{
    class ConstruirAST
    {

        ParseTreeNode raiz;
        public ConstruirAST(ParseTreeNode raiz)
        {
            this.raiz = raiz;
        }

        public AST generarAst()
        {
            return (AST)recorrer(this.raiz);
        }

        public Object recorrer(ParseTreeNode actual)
        {
            if (EstoyAca(actual, "INIT"))
            {
                return recorrer(actual.ChildNodes[0]);
            }
            else if (EstoyAca(actual, "CAMPOS"))
            {
                LinkedList<NodoAST> instrucciones = new LinkedList<NodoAST>();
                foreach (ParseTreeNode hijo in actual.ChildNodes)
                {
                    instrucciones.AddLast((NodoAST)recorrer(hijo));
                }
                return new AST(instrucciones);
            }
            else if (EstoyAca(actual, "CAMPO"))
            {
                return recorrer(actual.ChildNodes[0]);
            }
            else if (EstoyAca(actual, "SENTENCIA"))
            {
                return recorrer(actual.ChildNodes[0]);
            }
            else if (EstoyAca(actual, "SENTENCIAS"))
            {
                LinkedList<NodoAST> sentencias = new LinkedList<NodoAST>();
                foreach (ParseTreeNode hijo in actual.ChildNodes)
                {
                    sentencias.AddLast((NodoAST)recorrer(hijo));
                }
                return sentencias;
            }
            else if (EstoyAca(actual, "DECLARACION_VARIABLE"))
            {
                if (actual.ChildNodes.Count == 2)
                {
                    if (EstoyAca(actual.ChildNodes[0], "TIPO"))
                    {
                        int fila = actual.ChildNodes.ElementAt(0).ChildNodes[0].Token.Location.Line;
                        int columna = actual.ChildNodes.ElementAt(0).ChildNodes[0].Token.Location.Column;
                        return new Declaracion((Tipo)recorrer(actual.ChildNodes[0]), (LinkedList<Simbolo>)recorrer(actual.ChildNodes[1]), fila, columna);
                    }
                    else
                    {
                        //*DECLARACION OBJETO
                    }
                }
                else
                {
                    if (EstoyAca(actual.ChildNodes[0], "TIPO"))
                    {
                        int fila = actual.ChildNodes.ElementAt(0).ChildNodes[0].Token.Location.Line;
                        int columna = actual.ChildNodes.ElementAt(0).ChildNodes[0].Token.Location.Column;
                        return new Declaracion((Tipo)recorrer(actual.ChildNodes[0]), (LinkedList<Simbolo>)recorrer(actual.ChildNodes[1]), (Expresion)recorrer(actual.ChildNodes[3]), fila, columna);
                    }
                    else
                    {
                        //*DECLARACION OBJETO
                    }
                }

                return recorrer(actual.ChildNodes[0]);
            }
            else if (EstoyAca(actual, "LISTA_VARIABLES"))
            {
                LinkedList<Simbolo> simbolos = new LinkedList<Simbolo>();
                foreach (ParseTreeNode hijo in actual.ChildNodes)
                {
                    simbolos.AddLast(new Simbolo(hijo.Token.Text));
                }
                return simbolos;
            }
            else if (EstoyAca(actual, "ASIGNACION_VARIABLE"))
            {
                int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                if (actual.ChildNodes.Count == 3)
                {
                    return new Asignacion(getLexema(actual, 0).ToLower(), (Expresion)recorrer(actual.ChildNodes[2]), fila, columna);
                }
                else
                {
                    return new Asignacion(getLexema(actual, 0).ToLower(), (LinkedList<Expresion>)recorrer(actual.ChildNodes[2]), (Expresion)recorrer(actual.ChildNodes[4]), fila, columna);
                }
            }
            else if (EstoyAca(actual, "TIPO"))
            {
                if (EstoyAca(actual.ChildNodes[0], "STRING"))
                {
                    return new Tipo("string");
                }
                else if (EstoyAca(actual.ChildNodes[0], "BOOLEAN"))
                {
                    return new Tipo("bool");
                }
                else if (EstoyAca(actual.ChildNodes[0], "INT"))
                {
                    return new Tipo("int");
                }
                else if (EstoyAca(actual.ChildNodes[0], "DOUBLE"))
                {
                    return new Tipo("double");
                }
                else if (EstoyAca(actual.ChildNodes[0], "DATE"))
                {
                    return new Tipo("date");
                }
                else if (EstoyAca(actual.ChildNodes[0], "TIME"))
                {
                    return new Tipo("time");
                }
                else if (EstoyAca(actual.ChildNodes[0], "MAP"))
                {
                    if (actual.ChildNodes.Count == 1)
                    {
                        return new Tipo("map");
                    }
                    Tipo tipo_primitivo = (Tipo)recorrer(actual.ChildNodes[2]);
                    Tipo tipo_interno = (Tipo)recorrer(actual.ChildNodes[4]);
                    return new Tipo("map", tipo_primitivo, tipo_interno);
                }
                else if (EstoyAca(actual.ChildNodes[0], "LIST"))
                {
                    if (actual.ChildNodes.Count == 1)
                    {
                        return new Tipo("list");
                    }
                    Tipo tipo_interno = (Tipo)recorrer(actual.ChildNodes[2]);
                    return new Tipo("list", tipo_interno);
                }
                else if (EstoyAca(actual.ChildNodes[0], "SET"))
                {
                    if (actual.ChildNodes.Count == 1)
                    {
                        return new Tipo("set");
                    }
                    Tipo tipo_interno = (Tipo)recorrer(actual.ChildNodes[2]);
                    return new Tipo("set", tipo_interno);
                }
                else if (EstoyAca(actual.ChildNodes[0], "COUNTER"))
                {
                    return new Tipo("counter");
                }
                else if (EstoyAca(actual.ChildNodes[0], "IDENTIFICADOR"))
                {
                    return new Tipo(getLexema(actual, 0).ToLower());
                }
            }
            else if (EstoyAca(actual, "EXPRESION"))
            {
                return recorrer(actual.ChildNodes[0]);
            }
            else if (EstoyAca(actual, "EXPRESION_ARITMETICA"))
            {

                if (actual.ChildNodes.Count == 3)
                {
                    int fila = actual.ChildNodes.ElementAt(1).Token.Location.Line;
                    int columna = actual.ChildNodes.ElementAt(1).Token.Location.Column;
                    return new Operacion((Expresion)recorrer(actual.ChildNodes[0]), (Expresion)recorrer(actual.ChildNodes[2]), Operacion.getOperador(getLexema(actual, 1)), fila, columna);
                }
                else if (actual.ChildNodes.Count == 2)
                {
                    int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                    int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                    return new Operacion((Expresion)recorrer(actual.ChildNodes[1]), Operacion.Operador.MENOS_UNITARIO, fila, columna);
                }
            }
            else if (EstoyAca(actual, "EXPRESION_RELACIONAL"))
            {
                int fila = actual.ChildNodes.ElementAt(1).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(1).Token.Location.Column;
                return new Operacion((Expresion)recorrer(actual.ChildNodes[0]), (Expresion)recorrer(actual.ChildNodes[2]), Operacion.getOperador(getLexema(actual, 1)), fila, columna);
            }
            else if (EstoyAca(actual, "EXPRESION_LOGICAS"))
            {

                if (actual.ChildNodes.Count == 3)
                {
                    int fila = actual.ChildNodes.ElementAt(1).Token.Location.Line;
                    int columna = actual.ChildNodes.ElementAt(1).Token.Location.Column;
                    return new Operacion((Expresion)recorrer(actual.ChildNodes[0]), (Expresion)recorrer(actual.ChildNodes[2]), Operacion.getOperador(getLexema(actual, 1)), fila, columna);
                }
                else if (actual.ChildNodes.Count == 2)
                {
                    int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                    int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                    return new Operacion((Expresion)recorrer(actual.ChildNodes[1]), Operacion.Operador.NOT, fila, columna);
                }
            }
            else if (EstoyAca(actual, "PRIMITIVO"))
            {
                int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                if (EstoyAca(actual.ChildNodes[0], "VALENTERO"))
                {
                    int result = Convert.ToInt32(getLexema(actual, 0));
                    return new Primitivo(result, fila, columna);
                }
                else if (EstoyAca(actual.ChildNodes[0], "VALDECIMAL"))
                {
                    double result = Convert.ToDouble(getLexema(actual, 0));
                    return new Primitivo(result, fila, columna);
                }
                else if (EstoyAca(actual.ChildNodes[0], "VALCADENA"))
                {
                    String aux = getLexema(actual, 0).ToString();
                    aux = aux.Replace("\\n", "\n");
                    aux = aux.Replace("\\t", "\t");
                    aux = aux.Replace("\\r", "\r");
                    aux = aux.Substring(1, aux.Length - 2);
                    return new Primitivo(aux, fila, columna);
                }
                else if (EstoyAca(actual.ChildNodes[0], "TRUE"))
                {
                    return new Primitivo(true, fila, columna);
                }
                else if (EstoyAca(actual.ChildNodes[0], "FALSE"))
                {
                    return new Primitivo(false, fila, columna);
                }
                else if (EstoyAca(actual.ChildNodes[0], "VALTIME"))
                {
                    String aux = getLexema(actual, 0).ToString();
                    aux = aux.Substring(1, aux.Length - 2);
                    return new Primitivo(new Tiempo(aux), fila, columna);
                }
                else if (EstoyAca(actual.ChildNodes[0], "VALDATE"))
                {
                    String aux = getLexema(actual, 0).ToString();
                    aux = aux.Substring(1, aux.Length - 2);
                    return new Primitivo(new Date(aux), fila, columna);
                }
                else if (EstoyAca(actual.ChildNodes[0], "VARIABLE"))
                {
                    return new Identificador(getLexema(actual, 0).ToLower(), fila, columna);
                }
                else if (EstoyAca(actual.ChildNodes[0], "IDENTIFICADOR"))
                {
                    return new Identificador(getLexema(actual, 0).ToLower(), fila, columna);
                }
                else if (EstoyAca(actual.ChildNodes[0], "NULL"))
                {
                    return new Primitivo(new Nulo(), fila, columna);
                }
            }
            else if (EstoyAca(actual, "SENTENCIA_LOG"))
            {
                int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                return new Log((Expresion)recorrer(actual.ChildNodes[2]), fila, columna);
            }
            else if (EstoyAca(actual, "SENTENCIA_IF"))
            {
                int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                if (actual.ChildNodes.Count == 7)
                {
                    return new Si((LinkedList<NodoAST>)recorrer(actual.ChildNodes[5]), (Expresion)recorrer(actual.ChildNodes[2]), null, fila, columna);
                }
                else
                {
                    return new Si((LinkedList<NodoAST>)recorrer(actual.ChildNodes[5]), (Expresion)recorrer(actual.ChildNodes[2]), (LinkedList<NodoAST>)recorrer(actual.ChildNodes[7]), fila, columna);
                }
            }
            else if (EstoyAca(actual, "SENTENCIA_ELSE"))
            {
                if (actual.ChildNodes.Count == 4)
                {
                    return (LinkedList<NodoAST>)recorrer(actual.ChildNodes[2]);
                }
                else
                {
                    LinkedList<NodoAST> sentencias = new LinkedList<NodoAST>();
                    sentencias.AddLast((NodoAST)recorrer(actual.ChildNodes[1]));
                    return sentencias;
                }
            }
            else if (EstoyAca(actual, "SENTENCIA_WHILE"))
            {
                int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                return new Mientras((Expresion)recorrer(actual.ChildNodes[2]), (LinkedList<NodoAST>)recorrer(actual.ChildNodes[5]), fila, columna);
            }
            else if (EstoyAca(actual, "SENTENCIA_DO_WHILE"))
            {
                int fila = actual.ChildNodes.ElementAt(4).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(4).Token.Location.Column;
                return new Do_While((Expresion)recorrer(actual.ChildNodes[6]), (LinkedList<NodoAST>)recorrer(actual.ChildNodes[2]), fila, columna);
            }
            else if (EstoyAca(actual, "SENTENCIA_FOR"))
            {
                int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                return new For((Instruccion)recorrer(actual.ChildNodes[2]), (Expresion)recorrer(actual.ChildNodes[4]), (NodoAST)recorrer(actual.ChildNodes[6]), (LinkedList<NodoAST>)recorrer(actual.ChildNodes[9]), fila, columna);
            }
            else if (EstoyAca(actual, "INICIALIZACION"))
            {
                return (Instruccion)recorrer(actual.ChildNodes[0]);
            }
            else if (EstoyAca(actual, "ACTUALIZACION"))
            {
                return (NodoAST)recorrer(actual.ChildNodes[0]);
            }
            else if (EstoyAca(actual, "EXPRESION_LIST"))
            {
                int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                if (actual.ChildNodes.Count == 5)
                {
                    return new ExpresionLista((Tipo)recorrer(actual.ChildNodes[3]), fila, columna);
                }
                else
                {
                    return new ExpresionLista((LinkedList<Expresion>)recorrer(actual.ChildNodes[1]), fila, columna);
                }
            }
            else if (EstoyAca(actual, "LISTA_EXPRESIONES"))
            {

                LinkedList<Expresion> expresiones = new LinkedList<Expresion>();
                foreach (ParseTreeNode hijo in actual.ChildNodes)
                {
                    expresiones.AddLast((Expresion)recorrer(hijo));
                }
                return expresiones;
            }
            else if (EstoyAca(actual, "ACCESOSO_USER_TYPE"))
            {
                int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                return new Acceso(getLexema(actual, 0).ToLower(), (LinkedList<Expresion>)recorrer(actual.ChildNodes[2]), fila, columna);
            }
            else if (EstoyAca(actual, "ACCESO_OBJETO"))
            {
                LinkedList<Expresion> expresiones = new LinkedList<Expresion>();
                foreach (ParseTreeNode hijo in actual.ChildNodes)
                {
                    expresiones.AddLast((Expresion)recorrer(hijo));
                }
                return expresiones;
            }
            else if (EstoyAca(actual, "ACCESO_OBJETO_OPCIONES"))
            {
                if (actual.ChildNodes.Count == 1 && EstoyAca(actual.ChildNodes[0], "IDENTIFICADOR"))
                {
                    int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                    int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                    return new Identificador(getLexema(actual, 0).ToLower(), fila, columna);
                }
                if (actual.ChildNodes.Count == 4)
                {
                    /*
                    falta askajsskdj    

                    */


                }
                if (actual.ChildNodes.Count == 1 && EstoyAca(actual.ChildNodes[0], "LLAMADA_FUNCIONES_PRIMITIVAS"))
                {
                    return recorrer(actual.ChildNodes[0]);
                }
            }
            else if (EstoyAca(actual, "LLAMADA_FUNCIONES_PRIMITIVAS"))
            {
                if (EstoyAca(actual.ChildNodes[0], "INSERT") && actual.ChildNodes.Count == 4)
                {
                    int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                    int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                    return new Insertar((Expresion)recorrer(actual.ChildNodes[2]), fila, columna);
                }
                else if (EstoyAca(actual.ChildNodes[0], "GET"))
                {
                    int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                    int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                    return new Obtener((Expresion)recorrer(actual.ChildNodes[2]), fila, columna);
                }
                else if (EstoyAca(actual.ChildNodes[0], "SET"))
                {
                    int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                    int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                    return new Poner((Expresion)recorrer(actual.ChildNodes[4]), (Expresion)recorrer(actual.ChildNodes[2]), fila, columna);
                }
                else if (EstoyAca(actual.ChildNodes[0], "REMOVE"))
                {
                    int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                    int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                    return new Remover((Expresion)recorrer(actual.ChildNodes[2]), fila, columna);
                }
                else if (EstoyAca(actual.ChildNodes[0], "SIZE"))
                {
                    int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                    int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                    return new Size(fila, columna);
                }
                else if (EstoyAca(actual.ChildNodes[0], "CLEAR"))
                {
                    int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                    int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                    return new Vaciar(fila, columna);

                }
                else if (EstoyAca(actual.ChildNodes[0], "CONTAINS"))
                {
                    int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                    int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                    return new Contiene((Expresion)recorrer(actual.ChildNodes[2]), fila, columna);
                }
                else if (EstoyAca(actual.ChildNodes[0], "INSERT") && actual.ChildNodes.Count == 6)
                {
                    int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                    int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                    Insertar ints = new Insertar((Expresion)recorrer(actual.ChildNodes[4]), (Expresion)recorrer(actual.ChildNodes[2]), fila, columna);
                    return ints;
                }
                else if (EstoyAca(actual.ChildNodes[0], "LENGTH"))
                {
                    int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                    int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                    return new length(fila, columna);
                }
                else if (EstoyAca(actual.ChildNodes[0], "TOUPPERCASE"))
                {
                    int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                    int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                    return new toUpper(fila, columna);
                }
                else if (EstoyAca(actual.ChildNodes[0], "TOLOWERCASE"))
                {
                    int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                    int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                    return new toLower(fila, columna);
                }
                else if (EstoyAca(actual.ChildNodes[0], "STARTSWITH"))
                {
                    int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                    int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                    return new startsWith((Expresion)recorrer(actual.ChildNodes[2]), fila, columna);
                }
                else if (EstoyAca(actual.ChildNodes[0], "ENDSWITH"))
                {
                    int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                    int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                    return new endWith((Expresion)recorrer(actual.ChildNodes[2]), fila, columna);
                }
                else if (EstoyAca(actual.ChildNodes[0], "SUBSTRING"))
                {
                    int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                    int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                    return new subString((Expresion)recorrer(actual.ChildNodes[2]), (Expresion)recorrer(actual.ChildNodes[4]), fila, columna);
                }
                else if (EstoyAca(actual.ChildNodes[0], "GETYEAR"))
                {
                    int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                    int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                    return new getYear(fila, columna);
                }
                else if (EstoyAca(actual.ChildNodes[0], "GETMONTH"))
                {
                    int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                    int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                    return new getMonth(fila, columna);
                }
                else if (EstoyAca(actual.ChildNodes[0], "GETDAY"))
                {
                    int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                    int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                    return new getDay(fila, columna);
                }
                else if (EstoyAca(actual.ChildNodes[0], "GETHOUR"))
                {
                    int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                    int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                    return new getHour(fila, columna);
                }
                else if (EstoyAca(actual.ChildNodes[0], "GETMINUTS"))
                {
                    int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                    int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                    return new getMinuts(fila, columna);
                }
                else if (EstoyAca(actual.ChildNodes[0], "GETSECONDS"))
                {
                    int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                    int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                    return new getSeconds(fila, columna);
                }

            }
            else if (EstoyAca(actual, "EXPRESION_MAP"))
            {
                int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                if (actual.ChildNodes.Count == 7)
                {
                    return new ExpresionMap((Tipo)recorrer(actual.ChildNodes[3]), (Tipo)recorrer(actual.ChildNodes[5]), fila, columna);
                }
                else
                {
                    return new ExpresionMap((LinkedList<NodoExpresionMapa>)recorrer(actual.ChildNodes[1]), fila, columna);
                }
            }
            else if (EstoyAca(actual, "LISTA_MAP"))
            {
                LinkedList<NodoExpresionMapa> expresiones = new LinkedList<NodoExpresionMapa>();
                foreach (ParseTreeNode hijo in actual.ChildNodes)
                {
                    expresiones.AddLast((NodoExpresionMapa)recorrer(hijo));
                }
                return expresiones;
            }
            else if (EstoyAca(actual, "ELEMENTO_MAP"))
            {
                return new NodoExpresionMapa((Expresion)recorrer(actual.ChildNodes[0]), (Expresion)recorrer(actual.ChildNodes[2]));
            }
            else if (EstoyAca(actual, "EXPRESION_SET"))
            {
                int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                if (actual.ChildNodes.Count == 5)
                {
                    return new ExpresionSet((Tipo)recorrer(actual.ChildNodes[3]), fila, columna);
                }
                else
                {
                    return new ExpresionSet((LinkedList<Expresion>)recorrer(actual.ChildNodes[1]), fila, columna);
                }
            }
            else if (EstoyAca(actual, "SENTENCIA_CONTINUE"))
            {
                return new Continue();
            }
            else if (EstoyAca(actual, "SENTENCIA_DETENER"))
            {
                return new Break();
            }
            else if (EstoyAca(actual, "SENTENCIA_SWITCH"))
            {
                int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                Expresion exp = (Expresion)recorrer(actual.ChildNodes[2]);
                LinkedList<Case> casos = (LinkedList<Case>)recorrer(actual.ChildNodes[5]);
                if (actual.ChildNodes.Count == 7)
                {
                    return new Switch(exp, casos, null, fila, columna);
                }
                else
                {
                    Case defecto = (Case)recorrer(actual.ChildNodes[6]);
                    return new Switch(exp, casos, defecto, fila, columna);
                }
            }
            else if (EstoyAca(actual, "SENTENCIA_CASOS"))
            {
                LinkedList<Case> casos = new LinkedList<Case>();
                foreach (ParseTreeNode hijo in actual.ChildNodes)
                {
                    casos.AddLast((Case)recorrer(hijo));
                }
                return casos;
            }
            else if (EstoyAca(actual, "SENTENCIA_CASO"))
            {
                int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                if (actual.ChildNodes.Count == 6)
                {
                    Expresion exp = (Expresion)recorrer(actual.ChildNodes[1]);
                    LinkedList<NodoAST> sentencias = (LinkedList<NodoAST>)recorrer(actual.ChildNodes[4]);
                    return new Case(exp, sentencias);
                }
                else
                {
                    Expresion exp = (Expresion)recorrer(actual.ChildNodes[1]);
                    LinkedList<NodoAST> sentencias = (LinkedList<NodoAST>)recorrer(actual.ChildNodes[4]);
                    sentencias.AddLast(new Break());
                    return new Case(exp, sentencias);
                }
            }
            else if (EstoyAca(actual, "SENTENCIA_DEFAULT"))
            {
                int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                if (actual.ChildNodes.Count == 5)
                {
                    LinkedList<NodoAST> sentencias = (LinkedList<NodoAST>)recorrer(actual.ChildNodes[3]);
                    return new Case(null, sentencias);
                }
                else
                {
                    LinkedList<NodoAST> sentencias = (LinkedList<NodoAST>)recorrer(actual.ChildNodes[3]);
                    sentencias.AddLast(new Break());
                    return new Case(null, sentencias);
                }
            }
            else if (EstoyAca(actual, "OPERADOR_TERNARIO"))
            {
                int fila = actual.ChildNodes.ElementAt(1).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(1).Token.Location.Column;
                Expresion condicion = (Expresion)recorrer(actual.ChildNodes[0]);
                Expresion verdadero = (Expresion)recorrer(actual.ChildNodes[2]);
                Expresion falso = (Expresion)recorrer(actual.ChildNodes[4]);
                return new OperadorTernario(condicion, verdadero, falso, fila, columna);
            }
            else if (EstoyAca(actual, "SENTENCIA_AUMENTO"))
            {
                int fila = actual.ChildNodes.ElementAt(1).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(1).Token.Location.Column;
                String val = getLexema(actual, 0);
                return new Aumento(val, fila, columna);
            }
            else if (EstoyAca(actual, "SENTENCIA_DECREMENTO"))
            {
                int fila = actual.ChildNodes.ElementAt(1).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(1).Token.Location.Column;
                String val = getLexema(actual, 0);
                return new Decremento(val, fila, columna);

            }
            else if (EstoyAca(actual, "DECLARACION_FUNCION"))
            {
                int fila = actual.ChildNodes.ElementAt(2).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(2).Token.Location.Column;
                if (actual.ChildNodes.Count == 8)
                {
                    return new Funcion((Tipo)recorrer(actual.ChildNodes[0]), getLexema(actual, 1).ToLower(), (LinkedList<Simbolo>)recorrer(actual.ChildNodes[3]), (LinkedList<NodoAST>)recorrer(actual.ChildNodes[6]), fila, columna);
                }
                else
                {
                    return new Funcion((Tipo)recorrer(actual.ChildNodes[0]), getLexema(actual, 1).ToLower(), new LinkedList<Simbolo>(), (LinkedList<NodoAST>)recorrer(actual.ChildNodes[5]), fila, columna);
                }
            }
            else if (EstoyAca(actual, "LISTA_ATRIBUTOS"))
            {
                LinkedList<Simbolo> simbolos = new LinkedList<Simbolo>();
                foreach (ParseTreeNode hijo in actual.ChildNodes)
                {
                    simbolos.AddLast((Simbolo)recorrer(hijo));
                }
                return simbolos;
            }
            else if (EstoyAca(actual, "ATRIBUTO"))
            {
                return new Simbolo(getLexema(actual, 1).ToLower(), (Tipo)recorrer(actual.ChildNodes[0]));
            }
            else if (EstoyAca(actual, "SENTENCIA_LLAMADA"))
            {
                int fila = actual.ChildNodes.ElementAt(1).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(1).Token.Location.Column;
                if (actual.ChildNodes.Count == 4)
                {
                    return new Llamada(getLexema(actual, 0).ToLower(), (LinkedList<Expresion>)recorrer(actual.ChildNodes[2]), fila, columna);
                }
                else
                {
                    return new Llamada(getLexema(actual, 0).ToLower(), fila, columna);
                }
            }
            else if (EstoyAca(actual, "SENTENCIA_RETURN"))
            {
                if (actual.ChildNodes.Count == 1)
                {
                    return new Return();
                }
                else
                {
                    if (EstoyAca(actual.ChildNodes[1], "EXPRESION"))
                    {
                        Expresion exp = (Expresion)recorrer(actual.ChildNodes[1]);
                        return new Return(exp);
                    }
                    else
                    {
                        LinkedList<Expresion> exps = (LinkedList<Expresion>)recorrer(actual.ChildNodes[1]);
                        return new Return(exps);
                    }
                }

            }
            else if (EstoyAca(actual, "EXPRESION_TODAY"))
            {
                return new Today();
            }
            else if (EstoyAca(actual, "EXPRESION_NOW"))
            {
                return new Now();
            }
            else if (EstoyAca(actual, "CASTEO_EXPLICITO"))
            {
                int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                return new Castero((Tipo)recorrer(actual.ChildNodes[1]), (Expresion)recorrer(actual.ChildNodes[3]), fila, columna);
            }
            else if (EstoyAca(actual, "USE_DATABESE"))
            {
                int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                return new Use(getLexema(actual, 1), fila, columna);
            }
            else if (EstoyAca(actual, "CREAR_TYPE"))
            {
                int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                if (actual.ChildNodes.Count == 6)
                {
                    return new DefinirObjeto(getLexema(actual, 2).ToLower(), (LinkedList<Declaracion>)recorrer(actual.ChildNodes[4]), false, fila, columna);
                }
                else
                {
                    return new DefinirObjeto(getLexema(actual, 5).ToLower(), (LinkedList<Declaracion>)recorrer(actual.ChildNodes[7]), true, fila, columna);
                }
            }
            else if (EstoyAca(actual, "LISTA_ATRIBUTOS_TYPE"))
            {
                LinkedList<Declaracion> declaraciones = new LinkedList<Declaracion>();
                foreach (ParseTreeNode hijo in actual.ChildNodes)
                {
                    declaraciones.AddLast((Declaracion)recorrer(hijo));
                }
                return declaraciones;
            }
            else if (EstoyAca(actual, "ATRIBUTO_TYPE"))
            {
                int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                return new Declaracion((Tipo)recorrer(actual.ChildNodes[1]), new Simbolo(getLexema(actual, 0).ToLower()), fila, columna);
            }
            else if (EstoyAca(actual, "EXPRESION_TYPE"))
            {
                int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                if (actual.ChildNodes.Count == 5)
                {
                    Tipo tipo = new Tipo(getLexema(actual, 4).ToLower());
                    return new InstanciarObjeto(tipo, (LinkedList<Expresion>)recorrer(actual.ChildNodes[1]), fila, columna);
                }
                else
                {
                    Tipo tipo = new Tipo(getLexema(actual, 1).ToLower());
                    return new InstanciarObjeto(tipo, fila, columna);
                }
            }
            else if (EstoyAca(actual, "CREATE_DATABASE"))
            {
                int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                if (actual.ChildNodes.Count == 3)
                {
                    return new CrearDataBase(getLexema(actual, 2).ToLower(), false, fila, columna);
                }
                else
                {
                    return new CrearDataBase(getLexema(actual, 5).ToLower(), true, fila, columna);
                }
            }
            else if (EstoyAca(actual, "CREATE_TABLE"))
            {
                int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                if (actual.ChildNodes.Count == 9)
                {
                    return new CrearTabla(getLexema(actual, 5).ToLower(), true, (LinkedList<Columna>)recorrer(actual.ChildNodes[7]), new LinkedList<String>(), fila, columna);
                }
                else if (actual.ChildNodes.Count == 6)
                {
                    return new CrearTabla(getLexema(actual, 2).ToLower(), false, (LinkedList<Columna>)recorrer(actual.ChildNodes[4]), new LinkedList<String>(), fila, columna);
                }
                else if (actual.ChildNodes.Count == 10)
                {
                    return new CrearTabla(getLexema(actual, 5).ToLower(), true, (LinkedList<Columna>)recorrer(actual.ChildNodes[7]), (LinkedList<String>)recorrer(actual.ChildNodes[8]), fila, columna);
                }
                else if (actual.ChildNodes.Count == 7)
                {
                    return new CrearTabla(getLexema(actual, 2).ToLower(), false, (LinkedList<Columna>)recorrer(actual.ChildNodes[4]), (LinkedList<String>)recorrer(actual.ChildNodes[5]), fila, columna);
                }
            }
            else if (EstoyAca(actual, "LISTA_COLUMNAS"))
            {
                LinkedList<Columna> columnas = new LinkedList<Columna>();
                foreach (ParseTreeNode hijo in actual.ChildNodes)
                {
                    columnas.AddLast((Columna)recorrer(hijo));
                }
                return columnas;
            }
            else if (EstoyAca(actual, "CREATE_COLUM"))
            {
                if (actual.ChildNodes.Count == 4)
                {
                    return new Columna(getLexema(actual, 0).ToLower(), (Tipo)recorrer(actual.ChildNodes[1]), true);
                }
                else
                {
                    return new Columna(getLexema(actual, 0).ToLower(), (Tipo)recorrer(actual.ChildNodes[1]), false);
                }
            }
            else if (EstoyAca(actual, "LLAVE_COMPUESTA"))
            {
                return recorrer(actual.ChildNodes[4]);
            }
            else if (EstoyAca(actual, "LISTA_IDENTIFICADORES"))
            {
                LinkedList<String> llaves = new LinkedList<String>();
                foreach (ParseTreeNode hijo in actual.ChildNodes)
                {
                    llaves.AddLast(hijo.Token.Text.ToLower());
                }
                return llaves;
            }
            else if (EstoyAca(actual, "ALTER_TABLE"))
            {
                int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                if (EstoyAca(actual.ChildNodes[3], "ADD"))
                {
                    return new AlterTableAdd(getLexema(actual, 2).ToLower(), (LinkedList<Columna>)recorrer(actual.ChildNodes[4]), fila, columna);
                }
                else
                {
                    return new AlterTableDrop(getLexema(actual, 2).ToLower(), (LinkedList<String>)recorrer(actual.ChildNodes[4]), fila, columna);
                }
            }
            else if (EstoyAca(actual, "DROP_TABLE"))
            {
                int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                if (actual.ChildNodes.Count == 5)
                {
                    return new DropTable(getLexema(actual, 4), true, fila, columna);
                }
                else
                {
                    return new DropTable(getLexema(actual, 2), false, fila, columna);
                }
            }
            else if (EstoyAca(actual, "TRUNCATE_TABLE"))
            {
                int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                return new TruncateTable(getLexema(actual, 2).ToLower(), fila, columna);
            }
            else if (EstoyAca(actual, "SENTENCIA_CREAR_USUARIO"))
            {
                int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                String aux = getLexema(actual, 5);
                aux = aux.Replace("\\n", "\n");
                aux = aux.Replace("\\t", "\t");
                aux = aux.Replace("\\r", "\r");
                aux = aux.Substring(1, aux.Length - 2);

                return new CrearUsuario(getLexema(actual, 2).ToLower(), aux.ToLower(), fila, columna);
            }
            else if (EstoyAca(actual, "SENTENCIA_GRANT"))
            {
                int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                return new GrantUsuario(getLexema(actual, 1).ToLower(), getLexema(actual, 3).ToLower(), fila, columna);
            }
            else if (EstoyAca(actual, "SENTENCIA_REVOKE"))
            {
                int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                return new RevokeUsuario(getLexema(actual, 1).ToLower(), getLexema(actual, 3).ToLower(), fila, columna);
            }
            else if (EstoyAca(actual, "SENTENCIA_INSERT"))
            {
                int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                if (actual.ChildNodes.Count == 7)
                {
                    return new InsertTable(getLexema(actual, 2).ToLower(), (LinkedList<Expresion>)recorrer(actual.ChildNodes[5]), fila, columna);
                }
                else
                {
                    return new InsertTableEspecial(getLexema(actual, 2).ToLower(), (LinkedList<String>)recorrer(actual.ChildNodes[4]), (LinkedList<Expresion>)recorrer(actual.ChildNodes[8]), fila, columna);
                }
            }
            else if (EstoyAca(actual, "SENTENCIA_SELECT"))
            {
                int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                String nombre = getLexema(actual, 3).ToLower();
                if (actual.ChildNodes.Count == 11)
                {
                    Expresion where = (Expresion)recorrer(actual.ChildNodes[5]);
                    String order_by = (String)recorrer(actual.ChildNodes[8]);
                    Expresion limit = (Expresion)recorrer(actual.ChildNodes[10]);
                    if (EstoyAca(actual.ChildNodes[1].ChildNodes[0], "LISTA_EXPRESIONES"))
                    {
                        LinkedList<Expresion> campos = (LinkedList<Expresion>)recorrer(actual.ChildNodes[1].ChildNodes[0]);
                        return new Seleccionar(false, campos, nombre, where, order_by, limit, true, fila, columna);
                    }
                    else
                    {
                        return new Seleccionar(true, new LinkedList<Expresion>(), nombre, where, order_by, limit, true, fila, columna);
                    }
                }
                else if (actual.ChildNodes.Count == 9)
                {
                    if (EstoyAca(actual.ChildNodes[4], "WHERE"))
                    {
                        Expresion where = (Expresion)recorrer(actual.ChildNodes[5]);
                        String order_by = (String)recorrer(actual.ChildNodes[8]);
                        if (EstoyAca(actual.ChildNodes[1].ChildNodes[0], "LISTA_EXPRESIONES"))
                        {
                            LinkedList<Expresion> campos = (LinkedList<Expresion>)recorrer(actual.ChildNodes[1].ChildNodes[0]);
                            return new Seleccionar(false, campos, nombre, where, order_by, null, true, fila, columna);
                        }
                        else
                        {
                            return new Seleccionar(true, new LinkedList<Expresion>(), nombre, where, order_by, null, true, fila, columna);
                        }
                    }
                    else
                    {
                        Expresion limit = (Expresion)recorrer(actual.ChildNodes[8]);
                        String order_by = (String)recorrer(actual.ChildNodes[6]);
                        if (EstoyAca(actual.ChildNodes[1].ChildNodes[0], "LISTA_EXPRESIONES"))
                        {
                            LinkedList<Expresion> campos = (LinkedList<Expresion>)recorrer(actual.ChildNodes[1].ChildNodes[0]);
                            return new Seleccionar(false, campos, nombre, null, order_by, limit, true, fila, columna);
                        }
                        else
                        {
                            return new Seleccionar(true, new LinkedList<Expresion>(), nombre, null, order_by, limit, true, fila, columna);
                        }
                    }
                }
                else if (actual.ChildNodes.Count == 8)
                {
                    Expresion where = (Expresion)recorrer(actual.ChildNodes[5]);
                    Expresion limit = (Expresion)recorrer(actual.ChildNodes[7]);
                    if (EstoyAca(actual.ChildNodes[1].ChildNodes[0], "LISTA_EXPRESIONES"))
                    {
                        LinkedList<Expresion> campos = (LinkedList<Expresion>)recorrer(actual.ChildNodes[1].ChildNodes[0]);
                        return new Seleccionar(false, campos, nombre, where, null, limit, true, fila, columna);
                    }
                    else
                    {
                        return new Seleccionar(true, new LinkedList<Expresion>(), nombre, where, null, limit, true, fila, columna);
                    }
                }
                else if (actual.ChildNodes.Count == 7)
                {
                    String order_by = (String)recorrer(actual.ChildNodes[6]);
                    if (EstoyAca(actual.ChildNodes[1].ChildNodes[0], "LISTA_EXPRESIONES"))
                    {
                        LinkedList<Expresion> campos = (LinkedList<Expresion>)recorrer(actual.ChildNodes[1].ChildNodes[0]);
                        return new Seleccionar(false, campos, nombre, null, order_by, null, true, fila, columna);
                    }
                    else
                    {
                        return new Seleccionar(true, new LinkedList<Expresion>(), nombre, null, order_by, null, true, fila, columna);
                    }
                }
                else if (actual.ChildNodes.Count == 6)
                {
                    if (EstoyAca(actual.ChildNodes[4], "WHERE"))
                    {
                        Expresion where = (Expresion)recorrer(actual.ChildNodes[5]);
                        if (EstoyAca(actual.ChildNodes[1].ChildNodes[0], "LISTA_EXPRESIONES"))
                        {
                            LinkedList<Expresion> campos = (LinkedList<Expresion>)recorrer(actual.ChildNodes[1].ChildNodes[0]);
                            return new Seleccionar(false, campos, nombre, where, null, null, true, fila, columna);
                        }
                        else
                        {
                            return new Seleccionar(true, new LinkedList<Expresion>(), nombre, where, null, null, true, fila, columna);
                        }
                    }
                    else
                    {
                        Expresion limit = (Expresion)recorrer(actual.ChildNodes[5]);
                        if (EstoyAca(actual.ChildNodes[1].ChildNodes[0], "LISTA_EXPRESIONES"))
                        {
                            LinkedList<Expresion> campos = (LinkedList<Expresion>)recorrer(actual.ChildNodes[1].ChildNodes[0]);
                            return new Seleccionar(false, campos, nombre, null, null, limit, true, fila, columna);
                        }
                        else
                        {
                            return new Seleccionar(true, new LinkedList<Expresion>(), nombre, null, null, limit, true, fila, columna);
                        }
                    }
                }
                else
                {
                    if (EstoyAca(actual.ChildNodes[1].ChildNodes[0], "LISTA_EXPRESIONES"))
                    {
                        LinkedList<Expresion> campos = (LinkedList<Expresion>)recorrer(actual.ChildNodes[1].ChildNodes[0]);
                        return new Seleccionar(false, campos, nombre, null, null, null, true, fila, columna);
                    }
                    else
                    {
                        return new Seleccionar(true, new LinkedList<Expresion>(), nombre, null, null, null, true, fila, columna);
                    }
                }
            }
            else if (EstoyAca(actual, "LISTA_ORDER_BY"))
            {
                String order_by = "";
                bool primero = true;
                foreach (ParseTreeNode hijo in actual.ChildNodes)
                {
                    if (primero)
                    {
                        primero = false;
                        order_by += ((String)recorrer(hijo));
                    }
                    else
                    {
                        order_by += ", " + ((String)recorrer(hijo));
                    }

                }
                return order_by;
            }
            else if (EstoyAca(actual, "CAMPOR_ORDER"))
            {
                if (actual.ChildNodes.Count == 1)
                {
                    return getLexema(actual, 0).ToLower() + " asc";
                }
                else
                {
                    if (EstoyAca(actual.ChildNodes[1], "DESC"))
                    {
                        return getLexema(actual, 0).ToLower() + " desc";
                    }
                    else
                    {
                        return getLexema(actual, 0).ToLower() + " asc";
                    }
                }
            }
            else if (EstoyAca(actual, "ACCESO_CAMPO_TABLA"))
            {
                int fila = actual.ChildNodes.ElementAt(0).Token.Location.Line;
                int columna = actual.ChildNodes.ElementAt(0).Token.Location.Column;
                if (actual.ChildNodes.Count == 3)
                {
                    return new Acceso(getLexema(actual, 0).ToLower(), (LinkedList<Expresion>)recorrer(actual.ChildNodes[2]), fila, columna);
                }
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


        static String getLexema(ParseTreeNode nodo, int num)
        {
            return nodo.ChildNodes[num].Token.Text;
        }
    }
}
