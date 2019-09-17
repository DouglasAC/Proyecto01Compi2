using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Parsing;

namespace Proyecto_CQL_T.LUP.Gramatica
{
    public class Gramatica : Grammar
    {

        public Gramatica() : base(caseSensitive: false)
        {


            var ALOGIN = ToTerm("[+LOGIN]");
            var CLOGIN = ToTerm("[-LOGIN]");
            var AUSER = ToTerm("[+USER]");
            var CUSER = ToTerm("[-USER]");
            var APASS = ToTerm("[+PASS]");
            var CPASS = ToTerm("[-PASS]");
            var ALOGOUT = ToTerm("[+LOGOUT]");
            var CLOGOUT = ToTerm("[-LOGOUT]");
            var AQUERY = ToTerm("[+QUERY]");
            var CQUERY = ToTerm("[-QUERY]");
            var ASTRUCT = ToTerm("[+STRUCT]");
            var CSTRUCT = ToTerm("[-STRUCT]");

            RegexBasedTerminal DATA = new RegexBasedTerminal("DATA", "\\[\\+DATA\\](.|\\n|\\r)+\\[-DATA\\]");
            RegexBasedTerminal IDENTIFICADOR = new RegexBasedTerminal("IDENTIFICADOR", "([a-zA-Z_])[a-zA-Z0-9_]*");
            RegexBasedTerminal CLAVE = new RegexBasedTerminal("CLAVE", "[a-zA-Z0-9]*");

            NonTerminal init = new NonTerminal("init");
            NonTerminal paquetes = new NonTerminal("paquetes");
            NonTerminal paquete = new NonTerminal("paquete");
            NonTerminal login = new NonTerminal("login");
            NonTerminal logout = new NonTerminal("logout");
            NonTerminal query = new NonTerminal("query");
            NonTerminal bases = new NonTerminal("bases");


            init.Rule = paquetes
                ;

            paquetes.Rule = MakePlusRule(paquetes, paquete)
                ;

            paquete.Rule = login
                | logout
                | query
                | bases
                ;

            login.Rule = ALOGIN + AUSER + IDENTIFICADOR + CUSER + APASS + CLAVE + CPASS + CLOGIN
                ;

            logout.Rule = ALOGOUT + AUSER + IDENTIFICADOR + CUSER + CLOGOUT
                ;

            query.Rule = AQUERY + AUSER + IDENTIFICADOR + CUSER + DATA + CQUERY
                ;

            bases.Rule = ASTRUCT + AUSER + IDENTIFICADOR + CUSER + CSTRUCT
                ;

            this.Root = init;

        }
    }
}
