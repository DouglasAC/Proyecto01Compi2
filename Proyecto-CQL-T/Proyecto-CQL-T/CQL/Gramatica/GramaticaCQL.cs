using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.Gramatica
{
    public class GramaticaCQL : Grammar
    {

        public GramaticaCQL() : base(caseSensitive: false)
        {

            #region ER Y COMENTARIOS
            var VALDATE = new RegexBasedTerminal("VALDATE", "\\'[0-9][0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9]\\'");
            var VALTIME = new RegexBasedTerminal("VALTIME", "\\'[0-9][0-9]:[0-9][0-9]:[0-9][0-9]\\'");
            StringLiteral VALCADENA = new StringLiteral("VALCADENA", "\"");
            var VALENTERO = new RegexBasedTerminal("VALENTERO", "[0-9]+");
            var VALDECIMAL = new RegexBasedTerminal("VALDECIMAL", "[0-9]+\\.[0-9]+");

            IdentifierTerminal IDENTIFICADOR = new IdentifierTerminal("IDENTIFICADOR");
            RegexBasedTerminal VARIABLE = new RegexBasedTerminal("VARIABLE", "@([a-zA-Z_])[a-zA-Z0-9_]*");

            CommentTerminal comentarioLinea = new CommentTerminal("comentarioLinea", "//", "\n", "\r\n");
            CommentTerminal comentarioBloque = new CommentTerminal("comentarioBloque", "/*", "*/");
            base.NonGrammarTerminals.Add(comentarioLinea);
            base.NonGrammarTerminals.Add(comentarioBloque);
            #endregion

            #region  TERMINALES

            var AND = ToTerm("&&");
            var OR = ToTerm("||");
            var NOT = ToTerm("!");
            var XOR = ToTerm("^");
            var IGUAL = ToTerm("=");
            var TERNARIO = ToTerm("?");
            var IGUALIGUAL = ToTerm("==");
            var DIFERENTE = ToTerm("!=");
            var MAYORIGUAL = ToTerm(">=");
            var MENORIGUAL = ToTerm("<=");
            var MAYOR = ToTerm(">");
            var MENOR = ToTerm("<");
            var DOBLEMAYOR = ToTerm(">>");
            var DOBLEMENOR = ToTerm("<<");
            var MAS = ToTerm("+");
            var MENOS = ToTerm("-");
            var MULT = ToTerm("*");
            var DIVI = ToTerm("/");
            var POTENCIA = ToTerm("**");
            var MODULOR = ToTerm("%");
            var MASMAS = ToTerm("++");
            var MENOSMENOS = ToTerm("--");
            var PARA = ToTerm("(");
            var PARC = ToTerm(")");
            var LLAVEA = ToTerm("{");
            var LLAVEC = ToTerm("}");
            var BRACKETA = ToTerm("[");
            var BRACKETC = ToTerm("]");
            var MASIGUAL = ToTerm("+=");
            var MENOSIGUAL = ToTerm("-=");
            var MULTIGUAL = ToTerm("*=");
            var DIVIRIGUAL = ToTerm("/=");
            var DOSPUNTOS = ToTerm(":");
            var PTCOMA = ToTerm(";");
            var COMA = ToTerm(",");
            var PUNTO = ToTerm(".");
            var NULL = ToTerm("null");
            var ARROBA = ToTerm("@");
            var TRUE = ToTerm("TRUE");
            var FALSE = ToTerm("FALSE");
            var ASTERISCO = ToTerm("*");

            #region TIPOS 
            var ENTERO = ToTerm("INT");
            var DOUBLE = ToTerm("DOUBLE");
            var CADENA = ToTerm("STRING");
            var BOOLEAN = ToTerm("BOOLEAN");
            var DATE = ToTerm("DATE");
            var TIME = ToTerm("TIME");
            var MAP = ToTerm("MAP");
            var LIST = ToTerm("LIST");
            var SET = ToTerm("SET");
            #endregion


            #region palabras reservadas
            var IF = ToTerm("IF");
            var ELSE = ToTerm("ELSE");
            var SWITCH = ToTerm("SWITCH");
            var CASE = ToTerm("CASE");
            var DEFAULT = ToTerm("DEFAULT");
            var BREAK = ToTerm("BREAK");
            var WHILE = ToTerm("WHILE");
            var DO = ToTerm("DO");
            var FOR = ToTerm("FOR");
            var NEW = ToTerm("NEW");
            var PROCEDURE = ToTerm("PROCEDURE");
            var CALL = ToTerm("CALL");
            var CONTINUE = ToTerm("CONTINUE");
            var RETURN = ToTerm("RETURN");
            var LOG = ToTerm("LOG");
            var THROW = ToTerm("THROW");
            var TRY = ToTerm("TRY");
            var CATCH = ToTerm("CATCH");

            var TYPEALREADYEXISTS = ToTerm("TYPEALREADYEXISTS");
            var TYPEDONTEXISTS = ToTerm("TYPEDONTEXISTS");
            var BDALREADYEXISTS = ToTerm("BDALREADYEXISTS");
            var BDDONTEXISTS = ToTerm("BDDONTEXISTS");
            var USEDBEXCEPTION = ToTerm("USEDBEXCEPTION");
            var TABLEALREADYEXISTS = ToTerm("TABLEALREADYEXISTS");
            var TABLEDONTEXISTS = ToTerm("TABLEDONTEXISTS");
            var COUNTERTYPEEXCEPTION = ToTerm("COUNTERTYPEEXCEPTION");
            var USERALREADYEXISTS = ToTerm("USERALREADYEXISTS");
            var USERDONTEXISTS = ToTerm("USERDONTEXISTS");
            var VALUEEXCEPTION = ToTerm("VALUEEXCEPTION");
            var COLUMNEXCEPTION = ToTerm("COLUMNEXCEPTION");
            var BATCHEXCEPTION = ToTerm("BATCHEXCEPTION");
            var INDEXOUTEXCEPTION = ToTerm("INDEXOUTEXCEPTION");
            var ARITHMETICEXCEPTION = ToTerm("ARITHMETICEXCEPTION");
            var NULLPOINTEREXCEPTION = ToTerm("NULLPOINTEREXCEPTION");
            var NUMBERRETURNSEXCEPTION = ToTerm("NUMBERRETURNSEXCEPTION");
            var FUNCTIONALREADYEXISTS = ToTerm("FUNCTIONALREADYEXISTS");
            var PROCEDUREALREADYEXISTS = ToTerm("PROCEDUREALREADYEXISTS");
            var OBJECTALREADYEXISTS = ToTerm("OBJECTALREADYEXISTS");

            var CREATE = ToTerm("CREATE");
            var TYPE = ToTerm("TYPE");
            var ALTER = ToTerm("ALTER");
            var DELETE = ToTerm("DELETE");
            var NOTP = ToTerm("NOT");
            var EXISTS = ToTerm("EXISTS");
            var AS = ToTerm("AS");
            var ADD = ToTerm("ADD");
            var DATABASE = ToTerm("DATABASE");
            var USE = ToTerm("USE");
            var DROP = ToTerm("DROP");
            var TABLE = ToTerm("TABLE");
            var PRIMARY = ToTerm("PRIMARY");
            var KEY = ToTerm("KEY");
            var UPDATE = ToTerm("UPDATE");
            var COUNTER = ToTerm("COUNTER");
            var TRUNCATE = ToTerm("TRUNCATE");
            var COMMIT = ToTerm("COMMIT");
            var ROLLBACK = ToTerm("ROLLBACK");
            var USER = ToTerm("USER");
            var GRANT = ToTerm("GRANT");
            var REVOKE = ToTerm("REVOKE");
            var ON = ToTerm("ON");
            var IN = ToTerm("IN");
            var WITH = ToTerm("WITH");
            var PASSWORD = ToTerm("PASSWORD");
            var INSERT = ToTerm("INSERT");
            var INTO = ToTerm("INTO");
            var VALUES = ToTerm("VALUES");
            var WHERE = ToTerm("WHERE");
            var FROM = ToTerm("FROM");
            var SELECT = ToTerm("SELECT");
            var ORDER = ToTerm("ORDER");
            var BY = ToTerm("BY");
            var LIMIT = ToTerm("LIMIT");
            var ASC = ToTerm("ASC");
            var DESC = ToTerm("DESC");
            var MIN = ToTerm("MIN");
            var MAX = ToTerm("MAX");
            var SUM = ToTerm("SUM");
            var AVG = ToTerm("AVG");
            var COUNT = ToTerm("COUNT");
            var BEGIN = ToTerm("BEGIN");
            var APPLY = ToTerm("APPLY");
            var BATCH = ToTerm("BATCH");
            var GET = ToTerm("GET");
            var SIZE = ToTerm("SIZE");
            var REMOVE = ToTerm("REMOVE");
            var CLEAR = ToTerm("CLEAR");
            var CONTAINS = ToTerm("CONTAINS");
            var LENGTH = ToTerm("LENGTH");
            var TOUPPERCASE = ToTerm("TOUPPERCASE");
            var TOLOWERCASE = ToTerm("TOLOWERCASE");
            var STARTSWITH = ToTerm("STARTSWITH");
            var ENDSWITH = ToTerm("ENDSWITH");
            var SUBSTRING = ToTerm("SUBSTRING");
            var GETYEAR = ToTerm("GETYEAR");
            var GETMONTH = ToTerm("GETMONTH");
            var GETDAY = ToTerm("GETDAY");
            var GETHOUR = ToTerm("GETHOUR");
            var GETMINUTS = ToTerm("GETMINUTS");
            var GETSECONDS = ToTerm("GETSECONDS");
            var TODAY = ToTerm("TODAY");
            var NOW = ToTerm("NOW");

            #endregion


            #endregion

            #region terminales

            NonTerminal INIT = new NonTerminal("INIT");
            NonTerminal CAMPOS = new NonTerminal("CAMPOS");
            NonTerminal CAMPO = new NonTerminal("CAMPO");
            NonTerminal SENTENCIA = new NonTerminal("SENTENCIA");
            NonTerminal SENTENCIAS = new NonTerminal("SENTENCIAS");
            NonTerminal DECLARACION_VARIABLE = new NonTerminal("DECLARACION_VARIABLE");
            NonTerminal TIPO = new NonTerminal("TIPO");
            NonTerminal LISTA_VARIABLES = new NonTerminal("LISTA_VARIABLES");
            NonTerminal EXPRESION = new NonTerminal("EXPRESION");
            NonTerminal ASIGNACION_VARIABLE = new NonTerminal("ASIGNACION_VARIABLE");
            NonTerminal EXPRESION_ARITMETICA = new NonTerminal("EXPRESION_ARITMETICA");
            NonTerminal SENTENCIA_AUMENTO = new NonTerminal("SENTENCIA_AUMENTO");
            NonTerminal SENTENCIA_DECREMENTO = new NonTerminal("SENTENCIA_DECREMENTO");
            NonTerminal ASIGNACION_OPERACION = new NonTerminal("ASIGNACION_OPERACION");
            NonTerminal OPERADOR_IGUAL = new NonTerminal("OPERADOR_IGUAL");
            NonTerminal EXPRESION_LOGICAS = new NonTerminal("EXPRESION_LOGICAS");
            NonTerminal OPERADOR_TERNARIO = new NonTerminal("OPERADOR_TERNARIO");
            NonTerminal SENTENCIA_IF = new NonTerminal("SENTENCIA_IF");
            NonTerminal SENTENCIA_ELSE = new NonTerminal("SENTENCIA_ELSE");
            NonTerminal SENTENCIA_SWITCH = new NonTerminal("SENTENCIA_SWITCH");
            NonTerminal SENTENCIA_CASOS = new NonTerminal("SENTENCIA_CASOS");
            NonTerminal SENTENCIA_CASO = new NonTerminal("SENTENCIA_CASO");
            NonTerminal SENTENCIA_DEFAULT = new NonTerminal("SENTENCIA_DEFAULT");
            NonTerminal SENTENCIA_DETENER = new NonTerminal("SENTENCIA_DETENER");
            NonTerminal SENTENCIA_WHILE = new NonTerminal("SENTENCIA_WHILE");
            NonTerminal SENTENCIA_DO_WHILE = new NonTerminal("SENTENCIA_DO_WHILE");
            NonTerminal SENTENCIA_FOR = new NonTerminal("SENTENCIA_FOR");
            NonTerminal EXPRESION_MAP = new NonTerminal("EXPRESION_MAP");
            NonTerminal EXPRESION_LIST = new NonTerminal("EXPRESION_LIST");
            NonTerminal EXPRESION_SET = new NonTerminal("EXPRESION_SET");
            NonTerminal LISTA_MAP = new NonTerminal("LISTA_MAP");
            NonTerminal EXPRESION_RELACIONAL = new NonTerminal("EXPRESION_RELACIONAL");
            NonTerminal DECLARACION_FUNCION = new NonTerminal("DECLARACION_FUNCION");
            NonTerminal LISTA_ATRIBUTOS = new NonTerminal("LISTA_ATRIBUTOS");
            NonTerminal SENTENCIA_LLAMADA = new NonTerminal("SENTENCIA_LLAMADA");
            NonTerminal DECLARACION_PROCEDIMIENTO = new NonTerminal("DECLARACION_PROCEDIMIENTO");
            NonTerminal SENTENCIA_LLAMADA_PROCEDIMIENTO = new NonTerminal("SENTENCIA_LLAMADA_PROCEDIMIENTO");
            NonTerminal SENTENCIA_CONTINUE = new NonTerminal("SENTENCIA_CONTINUE");
            NonTerminal SENTENCIA_RETURN = new NonTerminal("SENTENCIA_RETURN");
            NonTerminal SENTENCIA_LOG = new NonTerminal("SENTENCIA_LOG");
            NonTerminal SENTENCIA_THROW = new NonTerminal("SENTENCIA_THROW");
            NonTerminal SENTENCIA_TRY_CATHC = new NonTerminal("SENTENCIA_TRY_CATHC");
            NonTerminal TIPO_EXCEPCION = new NonTerminal("TIPO_EXCEPCION");
            NonTerminal EXCEPCION = new NonTerminal("EXCEPCION");
            NonTerminal PRIMITIVO = new NonTerminal("PRIMITIVO");
            NonTerminal INICIALIZACION = new NonTerminal("INICIALIZACION");
            NonTerminal ACTUALIZACION = new NonTerminal("ACTUALIZACION");
            NonTerminal LISTA_EXPRESIONES = new NonTerminal("LISTA_EXPRESIONES");

            NonTerminal CREAR_TYPE = new NonTerminal("CREAR_TYPE");
            NonTerminal ALTERAR_TYPE = new NonTerminal("ALTERAR_TYPE");
            NonTerminal DELETE_TYPE = new NonTerminal("DELETE_TYPE");
            NonTerminal LISTA_ATRIBUTOS_TYPE = new NonTerminal("LISTA_ATRIBUTOS_TYPE");
            NonTerminal ATRIBUTO_TYPE = new NonTerminal("ATRIBUTO_TYPE");
            NonTerminal EXPRESION_TYPE = new NonTerminal("EXPRESION_TYPE");
            NonTerminal LISTA_IDENTIFICADORES = new NonTerminal("LISTA_IDENTIFICADORES");
            NonTerminal CREATE_DATABASE = new NonTerminal("CREATE_DATABASE");
            NonTerminal USE_DATABESE = new NonTerminal("USE_DATABESE");
            NonTerminal DROP_DATABASE = new NonTerminal("DROP_DATABASE");
            NonTerminal CREATE_TABLE = new NonTerminal("CREATE_TABLE");
            NonTerminal CREATE_COLUM = new NonTerminal("CREATE_COLUM");
            NonTerminal LISTA_COLUMNAS = new NonTerminal("LISTA_COLUMNAS");
            NonTerminal LLAVE_COMPUESTA = new NonTerminal("LLAVE_COMPUESTA");
            NonTerminal ALTER_TABLE = new NonTerminal("ALTER_TABLE");
            NonTerminal DROP_TABLE = new NonTerminal("DROP_TABLE");
            NonTerminal TRUNCATE_TABLE = new NonTerminal("TRUNCATE_TABLE");
            NonTerminal SENTENCIA_COMMIT = new NonTerminal("SENTENCIA_COMMIT");
            NonTerminal SENTENCIA_ROLLBACK = new NonTerminal("SENTENCIA_ROLLBACK");
            NonTerminal SENTENCIA_CREAR_USUARIO = new NonTerminal("SENTENCIA_CREAR_USUARIO");
            NonTerminal SENTENCIA_GRANT = new NonTerminal("SENTENCIA_GRANT");
            NonTerminal SENTENCIA_REVOKE = new NonTerminal("SENTENCIA_REVOKE");
            NonTerminal SENTENCIA_INSERT = new NonTerminal("SENTENCIA_INSERT");
            NonTerminal SENTENCIA_UPDATE = new NonTerminal("SENTENCIA_UPDATE");
            NonTerminal SENTENCIA_DELETE = new NonTerminal("SENTENCIA_DELETE");
            NonTerminal ASIGNACIONES = new NonTerminal("ASIGNACIONES");
            NonTerminal ASIGNACION = new NonTerminal("ASIGNACION");
            NonTerminal SENTENCIA_SELECT = new NonTerminal("SENTENCIA_SELECT");
            NonTerminal LISTA_ORDER_BY = new NonTerminal("LISTA_ORDER_BY");
            NonTerminal CAMPOR_ORDER = new NonTerminal("CAMPOR_ORDER");
            NonTerminal CAMPOS_SELECT = new NonTerminal("CAMPOS_SELECT");
            NonTerminal EXPRESION_AGREGACION = new NonTerminal("EXPRESION_AGREGACION");
            NonTerminal TIPO_AGREGACION = new NonTerminal("TIPO_AGREGACION");
            NonTerminal SENTENCIA_BATCH = new NonTerminal("SENTENCIA_BATCH");
            NonTerminal SENTENCIAS_BATCH = new NonTerminal("SENTENCIAS_BATCH");
            NonTerminal SENTENCIA_DENTRO_BATCH = new NonTerminal("SENTENCIA_DENTRO_BATCH");
            NonTerminal EXPRESION_WHERE_IN = new NonTerminal("EXPRESION_WHERE_IN");
            NonTerminal ELEMENTO_MAP = new NonTerminal("ELEMENTO_MAP");
            NonTerminal ATRIBUTO = new NonTerminal("ATRIBUTO");

            NonTerminal LLAMADA_FUNCIONES_PRIMITIVAS = new NonTerminal("LLAMADA_FUNCIONES_PRIMITIVAS");
            NonTerminal ASIGNACION_CAMPO_TABLA = new NonTerminal("ASIGNACION_CAMPO_TABLA");

            NonTerminal EXPRESION_TODAY = new NonTerminal("EXPRESION_TODAY");
            NonTerminal EXPRESION_NOW = new NonTerminal("EXPRESION_NOW");
            NonTerminal ACCESOSO_USER_TYPE = new NonTerminal("ACCESOSO_USER_TYPE");
            NonTerminal ACCESO_CAMPO_TABLA = new NonTerminal("ACCESO_CAMPO_TABLA");
            NonTerminal ACCESO_OBJETO = new NonTerminal("ACCESO_OBJETO");
            NonTerminal ACCESO_OBJETO_OPCIONES = new NonTerminal("ACCESO_OBJETO_OPCIONES");
            NonTerminal CASTEO_EXPLICITO = new NonTerminal("CASTEO_EXPLICITO");
            #endregion

            INIT.Rule = CAMPOS
                ;

            CAMPOS.Rule = MakePlusRule(CAMPOS, CAMPO)
                ;

            CAMPO.Rule = SENTENCIA
                | DECLARACION_FUNCION
                | DECLARACION_PROCEDIMIENTO
                | CREAR_TYPE + PTCOMA
                ;

            CAMPO.ErrorRule = SyntaxError + LLAVEC;
            CAMPO.ErrorRule = SyntaxError + PTCOMA;

            SENTENCIAS.Rule = MakePlusRule(SENTENCIAS, SENTENCIA)
                ;
            SENTENCIAS.ErrorRule = SyntaxError + PTCOMA;
            SENTENCIAS.ErrorRule = SyntaxError + LLAVEC;

            SENTENCIA.Rule = DECLARACION_VARIABLE + PTCOMA
                | ASIGNACION_VARIABLE + PTCOMA
                | SENTENCIA_AUMENTO + PTCOMA
                | SENTENCIA_DECREMENTO + PTCOMA
                | SENTENCIA_IF
                | SENTENCIA_SWITCH
                | SENTENCIA_DETENER + PTCOMA
                | SENTENCIA_WHILE
                | SENTENCIA_DO_WHILE + PTCOMA
                | SENTENCIA_FOR
                | SENTENCIA_RETURN + PTCOMA
                | SENTENCIA_LOG + PTCOMA
                | SENTENCIA_LLAMADA + PTCOMA
                | SENTENCIA_LLAMADA_PROCEDIMIENTO + PTCOMA
                | SENTENCIA_CONTINUE + PTCOMA
                | SENTENCIA_THROW + PTCOMA
                | SENTENCIA_TRY_CATHC
                | ALTERAR_TYPE + PTCOMA
                | DELETE_TYPE + PTCOMA
                | CREATE_DATABASE + PTCOMA
                | USE_DATABESE + PTCOMA
                | DROP_DATABASE + PTCOMA
                | CREATE_TABLE + PTCOMA
                | ALTER_TABLE + PTCOMA
                | DROP_TABLE + PTCOMA
                | TRUNCATE_TABLE + PTCOMA
                | SENTENCIA_COMMIT + PTCOMA
                | SENTENCIA_ROLLBACK + PTCOMA
                | SENTENCIA_CREAR_USUARIO + PTCOMA
                | SENTENCIA_GRANT + PTCOMA
                | SENTENCIA_REVOKE + PTCOMA
                | SENTENCIA_INSERT + PTCOMA
                | SENTENCIA_UPDATE + PTCOMA
                | SENTENCIA_DELETE + PTCOMA
                | SENTENCIA_SELECT + PTCOMA
                | SENTENCIA_BATCH + PTCOMA
                | EXPRESION + PTCOMA
                ;

            SENTENCIA.ErrorRule = SyntaxError + PTCOMA;
            SENTENCIA.ErrorRule = SyntaxError + LLAVEC;

            DECLARACION_VARIABLE.Rule = TIPO + LISTA_VARIABLES + IGUAL + EXPRESION
                | TIPO + LISTA_VARIABLES
                ;

            ASIGNACION.Rule = ASIGNACION_VARIABLE
                | ASIGNACION_CAMPO_TABLA
                ;

            ASIGNACION_VARIABLE.Rule = VARIABLE + IGUAL + EXPRESION
                | VARIABLE + PUNTO + ACCESO_OBJETO + IGUAL + EXPRESION
                ;

            ASIGNACION_OPERACION.Rule = VARIABLE + OPERADOR_IGUAL + EXPRESION
                | VARIABLE + PUNTO + ACCESO_OBJETO + OPERADOR_IGUAL + EXPRESION
                ;

            OPERADOR_IGUAL.Rule = MASIGUAL
                | MENOSIGUAL
                | MULTIGUAL
                | DIVIRIGUAL
                ;

            ASIGNACION_CAMPO_TABLA.Rule = IDENTIFICADOR + IGUAL + EXPRESION
                | IDENTIFICADOR + BRACKETA + EXPRESION + BRACKETC + IGUAL + EXPRESION
                | IDENTIFICADOR + BRACKETA + EXPRESION + BRACKETC + PUNTO + ACCESO_OBJETO + IGUAL + EXPRESION
                | IDENTIFICADOR + PUNTO + ACCESO_OBJETO + IGUAL + EXPRESION
                ;

            LISTA_VARIABLES.Rule = MakePlusRule(LISTA_VARIABLES, COMA, VARIABLE)
                ;

            TIPO.Rule = ENTERO
                | DOUBLE
                | CADENA
                | BOOLEAN
                | DATE
                | TIME
                | MAP
                | LIST
                | SET
                | COUNTER
                | IDENTIFICADOR
                | MAP + MENOR + TIPO + COMA + TIPO + MAYOR
                | LIST + MENOR + TIPO + MAYOR
                | SET + MENOR + TIPO + MAYOR
                ;

            EXPRESION.Rule = EXPRESION_ARITMETICA
                | EXPRESION_RELACIONAL
                | EXPRESION_LOGICAS
                | SENTENCIA_AUMENTO
                | SENTENCIA_DECREMENTO
                | OPERADOR_TERNARIO
                | EXPRESION_MAP
                | EXPRESION_LIST
                | EXPRESION_SET
                | SENTENCIA_LLAMADA
                | PRIMITIVO
                | PARA + EXPRESION + PARC
                | SENTENCIA_LLAMADA_PROCEDIMIENTO
                | EXPRESION_TYPE
                | EXPRESION_AGREGACION
                | EXPRESION_WHERE_IN
                | EXPRESION_NOW
                | EXPRESION_TODAY
                | ACCESOSO_USER_TYPE
                | ACCESO_CAMPO_TABLA
                | IDENTIFICADOR + BRACKETA + EXPRESION + BRACKETC
                | CASTEO_EXPLICITO
                ;

            EXPRESION_ARITMETICA.Rule = MENOS + EXPRESION
                | EXPRESION + MAS + EXPRESION
                | EXPRESION + MENOS + EXPRESION
                | EXPRESION + MULT + EXPRESION
                | EXPRESION + DIVI + EXPRESION
                | EXPRESION + MODULOR + EXPRESION
                | EXPRESION + POTENCIA + EXPRESION
                ;

            EXPRESION_LOGICAS.Rule = EXPRESION + OR + EXPRESION
                | EXPRESION + AND + EXPRESION
                | EXPRESION + XOR + EXPRESION
                | NOT + EXPRESION
                ;

            EXPRESION_RELACIONAL.Rule = EXPRESION + MAYOR + EXPRESION
                | EXPRESION + MENOR + EXPRESION
                | EXPRESION + MAYORIGUAL + EXPRESION
                | EXPRESION + MENORIGUAL + EXPRESION
                | EXPRESION + IGUALIGUAL + EXPRESION
                | EXPRESION + DIFERENTE + EXPRESION
                ;

            OPERADOR_TERNARIO.Rule = EXPRESION + TERNARIO + EXPRESION + DOSPUNTOS + EXPRESION
                ;

            SENTENCIA_AUMENTO.Rule = VARIABLE + MASMAS
                ;

            SENTENCIA_DECREMENTO.Rule = VARIABLE + MENOSMENOS
                ;

            SENTENCIA_IF.Rule = IF + PARA + EXPRESION + PARC + LLAVEA + SENTENCIAS + LLAVEC
                | IF + PARA + EXPRESION + PARC + LLAVEA + SENTENCIAS + LLAVEC + SENTENCIA_ELSE
                ;

            SENTENCIA_ELSE.Rule = ELSE + LLAVEA + SENTENCIAS + LLAVEC
                | ELSE + SENTENCIA_IF
                ;

            SENTENCIA_SWITCH.Rule = SWITCH + PARA + EXPRESION + PARC + LLAVEA + SENTENCIA_CASOS + LLAVEC
                | SWITCH + PARA + EXPRESION + PARC + LLAVEA + SENTENCIA_CASOS + SENTENCIA_DEFAULT + LLAVEC
                ;

            SENTENCIA_CASOS.Rule = MakePlusRule(SENTENCIA_CASOS, SENTENCIA_CASO)
                ;

            SENTENCIA_CASO.Rule = CASE + EXPRESION + DOSPUNTOS + LLAVEA + SENTENCIAS + LLAVEC
                | CASE + EXPRESION + DOSPUNTOS + LLAVEA + SENTENCIAS + LLAVEC + SENTENCIA_DETENER + PTCOMA
                ;

            SENTENCIA_DEFAULT.Rule = DEFAULT + DOSPUNTOS + LLAVEA + SENTENCIAS + LLAVEC
                | DEFAULT + DOSPUNTOS + LLAVEA + SENTENCIAS + LLAVEC + SENTENCIA_DETENER + PTCOMA
                ;

            SENTENCIA_DETENER.Rule = BREAK
                ;

            SENTENCIA_WHILE.Rule = WHILE + PARA + EXPRESION + PARC + LLAVEA + SENTENCIAS + LLAVEC
                ;

            SENTENCIA_DO_WHILE.Rule = DO + LLAVEA + SENTENCIAS + LLAVEC + WHILE + PARA + EXPRESION + PARC
                ;

            SENTENCIA_FOR.Rule = FOR + PARA + INICIALIZACION + PTCOMA + EXPRESION + PTCOMA + ACTUALIZACION + PARC + LLAVEA + SENTENCIAS + LLAVEC
                ;

            INICIALIZACION.Rule = DECLARACION_VARIABLE
                | ASIGNACION_VARIABLE
                ;

            ACTUALIZACION.Rule = ASIGNACION_VARIABLE
                | EXPRESION
                ;

            EXPRESION_MAP.Rule = NEW + MAP + MENOR + TIPO + COMA + TIPO + MAYOR
                | BRACKETA + LISTA_MAP + BRACKETC
                ;

            LISTA_MAP.Rule = MakePlusRule(LISTA_MAP, COMA, ELEMENTO_MAP)
                ;

            ELEMENTO_MAP.Rule = EXPRESION + DOSPUNTOS + EXPRESION
                ;

            EXPRESION_LIST.Rule = NEW + LIST + MENOR + TIPO + MAYOR
                | BRACKETA + LISTA_EXPRESIONES + BRACKETC
                ;

            EXPRESION_SET.Rule = NEW + SET + MENOR + TIPO + MAYOR
                | LLAVEA + LISTA_EXPRESIONES + LLAVEC
                ;



            LISTA_EXPRESIONES.Rule = MakePlusRule(LISTA_EXPRESIONES, COMA, EXPRESION)
                ;

            DECLARACION_FUNCION.Rule = TIPO + IDENTIFICADOR + PARA + LISTA_ATRIBUTOS + PARC + LLAVEA + SENTENCIAS + LLAVEC
                | TIPO + IDENTIFICADOR + PARA + PARC + LLAVEA + SENTENCIAS + LLAVEC
                ;

            LISTA_ATRIBUTOS.Rule = MakePlusRule(LISTA_ATRIBUTOS, COMA, ATRIBUTO)
                ;

            ATRIBUTO.Rule = TIPO + VARIABLE
                ;

            SENTENCIA_LLAMADA.Rule = IDENTIFICADOR + PARA + LISTA_EXPRESIONES + PARC
                | IDENTIFICADOR + PARA + PARC
                ;

            DECLARACION_PROCEDIMIENTO.Rule = PROCEDURE + IDENTIFICADOR + PARA + LISTA_ATRIBUTOS + PARC + COMA + PARA + LISTA_ATRIBUTOS + PARC + LLAVEA + SENTENCIAS + LLAVEC
                | PROCEDURE + IDENTIFICADOR + PARA + PARC + COMA + PARA + LISTA_ATRIBUTOS + PARC + LLAVEA + SENTENCIAS + LLAVEC
                | PROCEDURE + IDENTIFICADOR + PARA + LISTA_ATRIBUTOS + PARC + COMA + PARA + PARC + LLAVEA + SENTENCIAS + LLAVEC
                | PROCEDURE + IDENTIFICADOR + PARA + PARC + COMA + PARA + PARC + LLAVEA + SENTENCIAS + LLAVEC
                ;

            SENTENCIA_LLAMADA_PROCEDIMIENTO.Rule = CALL + IDENTIFICADOR + PARA + LISTA_EXPRESIONES + PARC
                | CALL + IDENTIFICADOR + PARA + PARC
                ;

            SENTENCIA_CONTINUE.Rule = CONTINUE
                ;

            SENTENCIA_RETURN.Rule = RETURN + EXPRESION
                | RETURN + LISTA_EXPRESIONES
                | RETURN
                ;

            SENTENCIA_LOG.Rule = LOG + PARA + EXPRESION + PARC
                ;

            SENTENCIA_THROW.Rule = THROW + NEW + TIPO_EXCEPCION
                ;

            SENTENCIA_TRY_CATHC.Rule = TRY + LLAVEA + SENTENCIAS + LLAVEC + CATCH + PARA + TIPO_EXCEPCION + VARIABLE + PARC + LLAVEA + SENTENCIAS + LLAVEC
                ;

            TIPO_EXCEPCION.Rule = TYPEALREADYEXISTS
                | TYPEDONTEXISTS
                | BDALREADYEXISTS
                | BDDONTEXISTS
                | USEDBEXCEPTION
                | TABLEALREADYEXISTS
                | TABLEDONTEXISTS
                | COUNTERTYPEEXCEPTION
                | USERALREADYEXISTS
                | USERDONTEXISTS
                | VALUEEXCEPTION
                | COLUMNEXCEPTION
                | BATCHEXCEPTION
                | INDEXOUTEXCEPTION
                | ARITHMETICEXCEPTION
                | NULLPOINTEREXCEPTION
                | NUMBERRETURNSEXCEPTION
                | FUNCTIONALREADYEXISTS
                | PROCEDUREALREADYEXISTS
                | OBJECTALREADYEXISTS
                ;

            PRIMITIVO.Rule = VALENTERO
                | VALDECIMAL
                | VALCADENA
                | TRUE
                | FALSE
                | VALTIME
                | VALDATE
                | VARIABLE
                | IDENTIFICADOR
                | NULL
                ;

            CREAR_TYPE.Rule = CREATE + TYPE + IDENTIFICADOR + PARA + LISTA_ATRIBUTOS_TYPE + PARC
                | CREATE + TYPE + IF + NOTP + EXISTS + IDENTIFICADOR + PARA + LISTA_ATRIBUTOS_TYPE + PARC
                ;

            LISTA_ATRIBUTOS_TYPE.Rule = MakePlusRule(LISTA_ATRIBUTOS_TYPE, COMA, ATRIBUTO_TYPE)
                ;

            ATRIBUTO_TYPE.Rule = IDENTIFICADOR + TIPO
                ;

            /* EXPRESION_USER_TYPE.Rule = LLAVEA + LISTA_EXPRESIONES + LLAVEC + AS + IDENTIFICADOR
                 ;*/

            EXPRESION_TYPE.Rule = LLAVEA + LISTA_EXPRESIONES + LLAVEC + AS + IDENTIFICADOR
                | NEW + IDENTIFICADOR;
            ;

            ALTERAR_TYPE.Rule = ALTER + TYPE + IDENTIFICADOR + ADD + PARA + LISTA_ATRIBUTOS_TYPE + PARC
                | ALTER + TYPE + IDENTIFICADOR + DELETE + PARA + LISTA_IDENTIFICADORES + PARC
                ;

            LISTA_IDENTIFICADORES.Rule = MakePlusRule(LISTA_IDENTIFICADORES, COMA, IDENTIFICADOR)
                ;

            DELETE_TYPE.Rule = DELETE + TYPE + IDENTIFICADOR
                ;

            CREATE_DATABASE.Rule = CREATE + DATABASE + IDENTIFICADOR
                | CREATE + DATABASE + IF + NOTP + EXISTS + IDENTIFICADOR
                ;

            USE_DATABESE.Rule = USE + IDENTIFICADOR
                ;

            DROP_DATABASE.Rule = DROP + DATABASE + IDENTIFICADOR
                ;

            CREATE_TABLE.Rule = CREATE + TABLE + IF + NOTP + EXISTS + IDENTIFICADOR + PARA + LISTA_COLUMNAS + PARC
                | CREATE + TABLE + IDENTIFICADOR + PARA + LISTA_COLUMNAS + PARC
                | CREATE + TABLE + IF + NOTP + EXISTS + IDENTIFICADOR + PARA + LISTA_COLUMNAS + LLAVE_COMPUESTA + PARC
                | CREATE + TABLE + IDENTIFICADOR + PARA + LISTA_COLUMNAS + LLAVE_COMPUESTA + PARC
                ;

            LISTA_COLUMNAS.Rule = MakePlusRule(LISTA_COLUMNAS, COMA, CREATE_COLUM)
                ;

            CREATE_COLUM.Rule = IDENTIFICADOR + TIPO + PRIMARY + KEY
                | IDENTIFICADOR + TIPO
                ;

            LLAVE_COMPUESTA.Rule = COMA + PRIMARY + KEY + PARA + LISTA_IDENTIFICADORES + PARC
                ;

            ALTER_TABLE.Rule = ALTER + TABLE + IDENTIFICADOR + ADD + LISTA_COLUMNAS
                | ALTER + TABLE + IDENTIFICADOR + DROP + LISTA_IDENTIFICADORES
                ;

            DROP_TABLE.Rule = DROP + TABLE + IF + EXISTS + IDENTIFICADOR
                | DROP + TABLE + IDENTIFICADOR
                ;

            TRUNCATE_TABLE.Rule = TRUNCATE + TABLE + IDENTIFICADOR
                ;

            SENTENCIA_COMMIT.Rule = COMMIT
                ;

            SENTENCIA_ROLLBACK.Rule = ROLLBACK
                ;

            SENTENCIA_CREAR_USUARIO.Rule = CREATE + USER + IDENTIFICADOR + WITH + PASSWORD + VALCADENA
                ;

            SENTENCIA_GRANT.Rule = GRANT + IDENTIFICADOR + ON + IDENTIFICADOR
                ;

            SENTENCIA_REVOKE.Rule = REVOKE + IDENTIFICADOR + ON + IDENTIFICADOR
                ;

            SENTENCIA_INSERT.Rule = INSERT + INTO + IDENTIFICADOR + VALUES + PARA + LISTA_EXPRESIONES + PARC
                | INSERT + INTO + IDENTIFICADOR + PARA + LISTA_IDENTIFICADORES + PARC + VALUES + PARA + LISTA_EXPRESIONES + PARC
                ;

            SENTENCIA_UPDATE.Rule = UPDATE + IDENTIFICADOR + SET + ASIGNACIONES
                | UPDATE + IDENTIFICADOR + SET + ASIGNACIONES + WHERE + EXPRESION
                ;

            ASIGNACIONES.Rule = MakePlusRule(ASIGNACIONES, COMA, ASIGNACION)
                ;

            SENTENCIA_DELETE.Rule = DELETE + FROM + IDENTIFICADOR
                | DELETE + FROM + IDENTIFICADOR + WHERE + EXPRESION
                | DELETE + IDENTIFICADOR + BRACKETA + EXPRESION + BRACKETC + FROM + IDENTIFICADOR
                | DELETE + IDENTIFICADOR + BRACKETA + EXPRESION + BRACKETC + FROM + IDENTIFICADOR + WHERE + EXPRESION
                ;

            SENTENCIA_SELECT.Rule = SELECT + CAMPOS_SELECT + FROM + IDENTIFICADOR + WHERE + EXPRESION + ORDER + BY + LISTA_ORDER_BY + LIMIT + EXPRESION
                | SELECT + CAMPOS_SELECT + FROM + IDENTIFICADOR + WHERE + EXPRESION + ORDER + BY + LISTA_ORDER_BY
                | SELECT + CAMPOS_SELECT + FROM + IDENTIFICADOR + WHERE + EXPRESION + LIMIT + EXPRESION
                | SELECT + CAMPOS_SELECT + FROM + IDENTIFICADOR + WHERE + EXPRESION
                | SELECT + CAMPOS_SELECT + FROM + IDENTIFICADOR + ORDER + BY + LISTA_ORDER_BY + LIMIT + EXPRESION
                | SELECT + CAMPOS_SELECT + FROM + IDENTIFICADOR + ORDER + BY + LISTA_ORDER_BY
                | SELECT + CAMPOS_SELECT + FROM + IDENTIFICADOR + LIMIT + EXPRESION
                | SELECT + CAMPOS_SELECT + FROM + IDENTIFICADOR
                ;

            CAMPOS_SELECT.Rule = ASTERISCO
                | LISTA_EXPRESIONES
                ;

            LISTA_ORDER_BY.Rule = MakePlusRule(LISTA_ORDER_BY, COMA, CAMPOR_ORDER)
                ;

            CAMPOR_ORDER.Rule = IDENTIFICADOR
                | IDENTIFICADOR + ASC
                | IDENTIFICADOR + DESC
                ;

            EXPRESION_AGREGACION.Rule = TIPO_AGREGACION + PARA + DOBLEMENOR + SENTENCIA_SELECT + DOBLEMAYOR + PARC
                ;

            TIPO_AGREGACION.Rule = COUNT
                | MIN
                | MAX
                | SUM
                | AVG
                ;

            SENTENCIA_BATCH.Rule = BEGIN + BATCH + SENTENCIAS_BATCH + APPLY + BATCH
                ;

            SENTENCIAS_BATCH.Rule = MakePlusRule(SENTENCIAS_BATCH, SENTENCIA_DENTRO_BATCH)
                ;

            SENTENCIA_DENTRO_BATCH.Rule = SENTENCIA_SELECT + PTCOMA
                | SENTENCIA_UPDATE + PTCOMA
                | SENTENCIA_DELETE + PTCOMA
                ;
            EXPRESION_WHERE_IN.Rule = EXPRESION + IN + EXPRESION
                ;

            LLAMADA_FUNCIONES_PRIMITIVAS.Rule = INSERT + PARA + EXPRESION + COMA + EXPRESION + PARC
                | GET + PARA + EXPRESION + PARC
                | SET + PARA + EXPRESION + COMA + EXPRESION + PARC
                | REMOVE + PARA + EXPRESION + PARC
                | SIZE + PARA + PARC
                | CLEAR + PARA + PARC
                | CONTAINS + PARA + EXPRESION + PARC
                | INSERT + PARA + EXPRESION + PARC
                | LENGTH + PARA + PARC
                | TOUPPERCASE + PARA + PARC
                | TOLOWERCASE + PARA + PARC
                | STARTSWITH + PARA + EXPRESION + PARC
                | ENDSWITH + PARA + EXPRESION + PARC
                | SUBSTRING + PARA + EXPRESION + COMA + EXPRESION + PARC
                | GETYEAR + PARA + PARC
                | GETMONTH + PARA + PARC
                | GETDAY + PARA + PARC
                | GETHOUR + PARA + PARC
                | GETMINUTS + PARA + PARC
                | GETSECONDS + PARA + PARC
               ;

            EXPRESION_TODAY.Rule = TODAY + PARA + PARC
                ;

            EXPRESION_NOW.Rule = NOW + PARA + PARC
                ;

            ACCESOSO_USER_TYPE.Rule = VARIABLE + PUNTO + ACCESO_OBJETO
                ;

            ACCESO_OBJETO.Rule = MakePlusRule(ACCESO_OBJETO, PUNTO, ACCESO_OBJETO_OPCIONES)
               ;

            ACCESO_OBJETO_OPCIONES.Rule = LLAMADA_FUNCIONES_PRIMITIVAS
                | IDENTIFICADOR + BRACKETA + EXPRESION + BRACKETC
                | IDENTIFICADOR
                ;

            ACCESO_CAMPO_TABLA.Rule = IDENTIFICADOR + BRACKETA + EXPRESION + BRACKETC + PUNTO + ACCESO_OBJETO
                | IDENTIFICADOR + PUNTO + ACCESO_OBJETO
                ;

            CASTEO_EXPLICITO.Rule = PARA + TIPO + PARC + EXPRESION
                ;

            #region precedencia
            RegisterOperators(1, Associativity.Right, IGUAL);
            RegisterOperators(2, Associativity.Left, TERNARIO);
            RegisterOperators(3, Associativity.Left, OR);
            RegisterOperators(4, Associativity.Left, XOR);
            RegisterOperators(5, Associativity.Left, AND);
            RegisterOperators(6, Associativity.Left, IGUALIGUAL, DIFERENTE);
            RegisterOperators(7, Associativity.Left, MAYOR, MENOS, MAYORIGUAL, MENORIGUAL);
            RegisterOperators(8, Associativity.Left, MAS, MENOS);
            RegisterOperators(9, Associativity.Left, MULT, DIVI, MODULOR);
            RegisterOperators(10, Associativity.Right, POTENCIA);
            RegisterOperators(11, Associativity.Right, NOT);
            RegisterOperators(12, Associativity.Left, PUNTO);
            RegisterOperators(13, Associativity.Neutral, PARA, PARC);
            #endregion

            this.Root = INIT;
        }

    }
}
