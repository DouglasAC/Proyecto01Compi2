//------ Gramatica LUP para la respuesta del servidor


%{
    // Nodo con respuesta 
    function Nodo(tipo, data)
    {
        this.tipo = tipo;
        this.data = data;
    }
    /*
        tipos           | data
        LOG             | true or false
        LOGOUT          | true or false
        DATA            | codigo html
        MESSAGE         | string 
        ERROR           | error
        BASES           | array de arrays
    */

    function NodoError(linea, columna, tipo, descripion)
    {
        this.linea = linea;
        this.columna = columna;
        this.tipo = tipo;
        this.descripion = descripion;
    }

%}

%lex

%options case-insensitive 



%%

"[+DATA]"[^\[]*"[-DATA]"            { yytext = yytext.substring(7,yyleng-7); return "DATA";}
"[+MESSAGE]"[^\[]*"[-MESSAGE]"      { yytext = yytext.substring(10,yyleng-10); return 'MESSAGE'; };
"[+DESC]"[^\[]*"[-DESC]"            { yytext = yytext.substring(7,yyleng-7); return 'DESC'; };


"[+LOGIN]"          return 'ALOG';
"[-LOGIN]"          return 'CLOG';
"[+LOGOUT]"         return 'ALOGOUT';
"[-LOGOUT]"         return 'CLOGOUT';
"SUCCESS"           return 'CORRECTO';
"FAIL"              return 'INCORRECTO';
"[+ERROR]"          return 'AERROR'
"[-ERROR]"          return 'CERROR'
"[+DATABASES]"      return 'ADATABASES'
"[-DATABASES]"      return 'CDATABASES'
"[+DATABASE]"       return 'ADATABASE'
"[-DATABASE]"       return 'CDATABASE'
"[+TABLES]"         return 'ATABLES'
"[-TABLES]"         return 'CTABLES'
"[+TABLE]"          return 'ATABLE'
"[-TABLE]"          return 'CTABLE'
"[+TYPES]"          return 'ATYPES'
"[-TYPES]"          return 'CTYPES'
"[+COLUMNS]"        return 'ACOLUMNS'
"[-COLUMNS]"        return 'CCOLUMNS'
"[+COLUMN]"         return 'ACOLUMN'
"[-COLUMN]"         return 'CCOLUMN'
"[+TYPEUS]"         return 'ATYPEUS'
"[-TYPEUS]"         return 'CTYPEUS'
"[+ATRIBUTES]"      return 'AATRIBUTES'
"[-ATRIBUTES]"      return 'CATRIBUTES'
"[+ATRIBUTE]"       return 'AATRIBUTE'
"[-ATRIBUTE]"       return 'CATRIBUTE'
"[+PROCEDURES]"     return 'APROCEDURES'
"[-PROCEDURES]"     return 'CPROCEDURES'
"[+PROCEDURE]"      return 'APROCEDURE'
"[-PROCEDURE]"      return 'CPROCEDURE'
"[+PARAMETERS]"     return 'APARAMETERS'
"[-PARAMETERS]"     return 'CPARAMETERS'
"[+PARAMETER]"      return 'APARAMETER'
"[-PARAMETER]"      return 'CPARAMETER'
"[+NAME]"           return 'ANAME'
"[-NAME]"           return 'CNAME'
"[+TIPO]"           return 'ATIPO'
"[-TIPO]"           return 'CTIPO'
"[+PK]"             return 'APK'
"[-PK]"             return 'CPK'
"[+AS]"             return 'AAS'
"[-AS]"             return 'CAS'
"[+LINE]"           return 'ALINE'
"[-LINE]"           return 'CLINE'
"[+TYPE]"           return 'ATYPE'
"[-TYPE]"           return 'CTYPE'


[0-9]+\b			return 'ENTERO';
([a-zA-Z_])[a-zA-Z0-9_]*	return 'IDENTIFICADOR';
/* Espacios en blanco */
[ \r\t]+            {}
\n                  {}
<<EOF>>                 return 'EOF';

[^\[\]]*			{  return 'TEXTO'; }

.                       { console.error('Este es un error léxico: ' + yytext + ', en la linea: ' + yylloc.first_line + ', en la columna: ' + yylloc.first_column); }
/lex

%start init 

%%

init:
    paquetes EOF    { console.log($1.length); return $1; }
;

paquetes:
    paquetes paquete        { $$ = $1; $$.push($2); }
    | paquete               { $$ = []; $$.push($1); }
;

paquete:
    loging      { $$ = $1; }
    | logout    { $$ = $1; }
    | data      { $$ = $1; }
    | message   { $$ = $1; }
    | meserror  { $$ = $1; }
    | bases     { $$ = new Nodo("BASES",[$1]); }
;

loging:
    ALOG CORRECTO CLOG           { $$ = new Nodo("LOG", true); }
    | ALOG  INCORRECTO CLOG       { $$ = new Nodo("LOG", false); }
;

logout:
    ALOGOUT  CORRECTO CLOGOUT           { $$ = new Nodo("LOGOUT", true); }
    | ALOGOUT  INCORRECTO CLOGOUT       { $$ = new Nodo("LOGOUT", false); }
;

data:
    DATA  { $$ = new Nodo("DATA", $1); }
;

message:
    MESSAGE { $$ = new Nodo("MESSAGE", $1); }
;

meserror:
    AERROR ALINE ENTERO CLINE ACOLUMN ENTERO CCOLUMN ATYPE IDENTIFICADOR CTYPE DESC CERROR { $$ = new Nodo("ERROR", new NodoError($3, $6, $9, $11)); }
;

bases:
    ADATABASES basesdedatos CDATABASES {  items = $2; $$ = {text: "Bases", items: $2}; }
    | ADATABASES CDATABASES{ $$ = {text: "Bases"}; }
;

basesdedatos:
    basesdedatos basededatos    { $$ = $1; $$.push($2); }
    | basededatos               { $$ = []; $$.push($1); }
;

basededatos:
    ADATABASE ANAME IDENTIFICADOR CNAME partestabla CDATABASE  { $$ = { text: $3, items: $5 }; }
    | ADATABASE ANAME IDENTIFICADOR CNAME CDATABASE            { $$ = { text: $3 }; }
;

partestabla:
    partestabla partetabla      { $$ = $1; $$.push($2); }
    | partetabla                { $$ = []; $$.push($1); }
;

partetabla: 
    ATABLES tablas CTABLES                    { $$ = { text: "Tablas", items:$2 };  }
    | ATYPES typesuser CTYPES                   { $$ = { text: "Types User", items:$2 };  }
    | APROCEDURES procedimientos CPROCEDURES    { $$ = { text: "Procedimientos", items:$2 };  }
;

tablas:
    tablas tabla    { $$ = $1; $$.push($2); }
    | tabla         { $$ = []; $$.push($1); }
;

tabla:
    ATABLE ANAME IDENTIFICADOR CNAME ACOLUMNS columnas CCOLUMNS CTABLE  { $$ = { text: $3, items: $6};  }
    | ATABLE ANAME IDENTIFICADOR CNAME CTABLE {  $$ = { text: $3};  }
;

columnas:
    columnas columna    { $$ = $1; $$.push($2); }
    | columna           { $$ = []; $$.push($1); }
;

columna:
    ACOLUMN ANAME IDENTIFICADOR CNAME ATIPO IDENTIFICADOR CTIPO APK IDENTIFICADOR CPK CCOLUMN  {  $$ = { text: $3, items: [{text: "Tipo: " + $6}, {text: "PK: " + $9}]};  }
;

typesuser:
    typesuser typeuser      { $$ = $1; $$.push($2); }
    | typeuser              { $$ = []; $$.push($1); }
;

typeuser:
    ATYPEUS ANAME IDENTIFICADOR CNAME AATRIBUTES atributos CATRIBUTES CTYPEUS   { $$ = { text: $3, items:  $6}; }
;

atributos:
    atributos atributo      { $$ = $1; $$.push($2); }
    | atributo              { $$ = []; $$.push($1); }
;

atributo:
    AATRIBUTE ANAME IDENTIFICADOR CNAME ATIPO IDENTIFICADOR CTIPO CATRIBUTE { $$ = { text: $3, items: [{ text: "Tipo: " + $6}]}; }
;

procedimientos:
    procedimientos procedimiento        { $$ = $1; $$.push($2); }
    | procedimiento                     { $$ = []; $$.push($1); }
;

procedimiento:
    APROCEDURE ANAME IDENTIFICADOR CNAME APARAMETERS parametros CPARAMETERS CPROCEDURE { $$ = { text: $3, items: $6}; }
;

parametros:
    parametros parametro        { $$ = $1; $$.push($2); }
    | parametro                 { $$ = []; $$.push($1); }
;

parametro:
    APARAMETER ANAME IDENTIFICADOR CNAME ATIPO IDENTIFICADOR CTIPO AAS IDENTIFICADOR CAS CPARAMETER    { $$ = { text: $3, items: [{ text:"Tipo: " + $6 },{ text:"AS: " + $9 }]}; }
;