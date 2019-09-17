using Proyecto_CQL_T.CQL.AnalizadorCQL;
using Proyecto_CQL_T.CQL.Extras;
using Proyecto_CQL_T.CQL.InterpreteCQL.AltaAbstraccion;
using Proyecto_CQL_T.CQL.InterpreteCQL.Colecciones;
using Proyecto_CQL_T.CQL.InterpreteCQL.Entorno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.ValorImplicito
{
    class Operacion : Expresion
    {
        public enum Operador
        {
            SUMA,
            RESTA,
            MULTIPLICACION,
            DIVISION,
            MODULO,
            MENOS_UNITARIO,
            POTENCIA,
            MAYOR,
            MENOR,
            IGUAL_IGUAL,
            MAYOR_IGUAL,
            MENOR_IGUAL,
            DIFERENTE,
            OR,
            AND,
            XOR,
            NOT,
            DESCONOCIDO
        }

        public static Operador getOperador(String op)
        {
            switch (op)
            {
                case "+":
                    return Operador.SUMA;
                case "-":
                    return Operador.RESTA;
                case "*":
                    return Operador.MULTIPLICACION;
                case "/":
                    return Operador.DIVISION;
                case "%":
                    return Operador.MODULO;
                case "**":
                    return Operador.POTENCIA;
                case ">":
                    return Operador.MAYOR;
                case "<":
                    return Operador.MENOR;
                case "==":
                    return Operador.IGUAL_IGUAL;
                case "!=":
                    return Operador.DIFERENTE;
                case "!":
                    return Operador.NOT;
                case "||":
                    return Operador.OR;
                case "&&":
                    return Operador.AND;
                case "^":
                    return Operador.XOR;
                case ">=":
                    return Operador.MAYOR_IGUAL;
                case "<=":
                    return Operador.MENOR_IGUAL;
                default:
                    return Operador.DESCONOCIDO;
            }
        }

        private Expresion operando1;
        private Expresion operando2;
        private Expresion operandoU;
        private Operador operador;
        private int fila;
        private int columna;

        public Operacion(Expresion operando1, Expresion operando2, Operador operador, int fila, int columna)
        {
            this.operando1 = operando1;
            this.operando2 = operando2;
            this.operador = operador;
            this.fila = fila;
            this.columna = columna;
        }

        public Operacion(Expresion operandoU, Operador operador, int fila, int columna)
        {
            this.operandoU = operandoU;
            this.operador = operador;
            this.fila = fila;
            this.columna = columna;
        }

        public Tipo getTipo(Entorno.Entorno ent)
        {
            Object valor = this.getValor(ent);
            if (valor is Boolean)
            {
                return new Tipo("bool");
            }
            else if (valor is String)
            {
                return new Tipo("string");
            }
            else if (valor is int)
            {
                return new Tipo("int");
            }
            else if (valor is double)
            {
                return new Tipo("double");
            }
            else if (valor is Date)
            {
                return new Tipo("date");
            }
            else if (valor is Tiempo)
            {
                return new Tipo("time");
            }
            else if (valor is Lista)
            {
                return new Tipo("list");
            }
            else if (valor is Map)
            {
                return new Tipo("map");
            }
            else if (valor is Set)
            {
                return new Tipo("set");
            }
            else if (valor is Objeto)
            {
                Objeto obj = (Objeto)valor;
                return obj.tipo;
            }
            else
            {
                return new Tipo("null");
            }
        }

        public object getValor(Entorno.Entorno ent)
        {
            Object op1 = new Object(), op2 = new Object(), opU = new Object();
            try
            {
                if (operandoU == null)
                {
                    op1 = operando1.getValor(ent);
                    op2 = operando2.getValor(ent);
                }
                else
                {
                    opU = operandoU.getValor(ent);
                }
                switch (this.operador)
                {
                    case Operador.SUMA:
                        return Sumar(op1, op2);
                    case Operador.RESTA:
                        return Restar(op1, op2);
                    case Operador.MULTIPLICACION:
                        return Multiplicar(op1, op2);
                    case Operador.POTENCIA:
                        return Potencia(op1, op2);
                    case Operador.MODULO:
                        return Modulo(op1, op2);
                    case Operador.DIVISION:
                        return Division(op1, op2);
                    case Operador.MAYOR:
                        return Mayor(op1, op2);
                    case Operador.MENOR:
                        return Menor(op1, op2);
                    case Operador.MAYOR_IGUAL:
                        return Mayor_Igual(op1, op2);
                    case Operador.MENOR_IGUAL:
                        return Menor_Igual(op1, op2);
                    case Operador.IGUAL_IGUAL:
                        return Igual_Igual(op1, op2);
                    case Operador.DIFERENTE:
                        return Diferente(op1, op2);
                    case Operador.OR:
                        return Or(op1, op2);
                    case Operador.AND:
                        return And(op1, op2);
                    case Operador.XOR:
                        return Xor(op1, op2);
                    case Operador.NOT:
                        return Not(opU);
                    case Operador.MENOS_UNITARIO:
                        return Menos_Unitario(opU);
                }
            }
            catch (Exception e)
            {
                Estatico.errores.Add(new ErrorCQL("Ejecucion", "Error al momento de operar", this.fila, this.columna));
            }
            return null;
        }

        private Object Sumar(Object op1, Object op2)
        {
            if (op1 is double && op2 is double)
            {
                double res = (double)op1 + (double)op2;
                return res;
            }
            else if (op1 is double && op2 is int)
            {
                double res = (double)op1 + (int)op2;
                return res;
            }
            else if (op1 is int && op2 is double)
            {
                double res = (int)op1 + (double)op2;
                return res;
            }
            else if (op1 is int && op2 is int)
            {
                int res = (int)op1 + (int)op2;
                return res;
            }
            else if (op1 is String && op2 is int)
            {
                String res = (String)op1 + (int)op2;
                return res;
            }
            else if (op1 is String && op2 is String)
            {
                String res = (String)op1 + (String)op2;
                return res;
            }
            else if (op1 is int && op2 is String)
            {
                String res = (int)op1 + (String)op2;
                return res;
            }
            else if (op1 is double && op2 is String)
            {
                String res = (double)op1 + (String)op2;
                return res;
            }
            else if (op1 is Boolean && op2 is String)
            {
                String bol = ((Boolean)op1) ? "True" : "False";
                String res = bol + (String)op2;
                return res;
            }
            else if (op1 is String && op2 is Boolean)
            {
                String bol = ((Boolean)op2) ? "True" : "False";
                String res = (String)op1 + bol;
                return res;
            }
            else if (op1 is String || op2 is String)
            {
                String res = op1.ToString() + op2.ToString();
                return res;
            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Semantico", "Error de tipos en la suma", this.fila, this.columna));
            }
            return null;
        }

        private Object Restar(Object op1, Object op2)
        {
            if (op1 is int && op2 is int)
            {
                int res = (int)op1 - (int)op2;
                return res;
            }
            else if (op1 is double && op2 is int)
            {
                double res = (double)op1 - (int)op2;
                return res;
            }
            else if (op1 is int && op2 is double)
            {
                double res = (int)op1 - (double)op2;
                return res;
            }
            else if (op1 is double && op2 is double)
            {
                double res = (double)op1 - (double)op2;
                return res;
            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Semantico", "Error de tipos en la resta", this.fila, this.columna));
            }
            return null;
        }

        private Object Multiplicar(Object op1, Object op2)
        {
            if (op1 is int && op2 is int)
            {
                int res = (int)op1 * (int)op2;
                return res;
            }
            else if (op1 is double && op2 is int)
            {
                double res = (double)op1 * (int)op2;
                return res;
            }
            else if (op1 is int && op2 is double)
            {
                double res = (int)op1 * (double)op2;
                return res;
            }
            else if (op1 is double && op2 is double)
            {
                double res = (double)op1 * (double)op2;
                return res;
            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Semantico", "Error de tipos en la multiplicacion", this.fila, this.columna));
            }
            return null;
        }

        private Object Potencia(Object op1, Object op2)
        {
            if (op1 is int && op2 is int)
            {
                double res = Math.Pow((int)op1, (int)op2);
                return res;
            }
            else if (op1 is double && op2 is int)
            {
                double res = Math.Pow((double)op1, (int)op2);
                return res;
            }
            else if (op1 is int && op2 is double)
            {
                double res = Math.Pow((int)op1, (double)op2);
                return res;
            }
            else if (op1 is double && op2 is double)
            {
                double res = Math.Pow((double)op1, (double)op2);
                return res;
            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Semantico", "Error de tipos en la potencia", this.fila, this.columna));
            }
            return null;
        }

        private Object Modulo(Object op1, Object op2)
        {
            Boolean divisor = true;
            if (op1 is int && op2 is int)
            {
                if ((int)op2 != 0)
                {
                    double val = (int)op1 % (int)op2;
                    int res = (int)Math.Truncate(val);
                    return res;
                }
                else
                {
                    divisor = false;
                }
            }
            else if (op1 is double && op2 is int)
            {
                if ((int)op2 != 0)
                {
                    double res = (double)op1 % (int)op2;
                    return res;
                }
                else
                {
                    divisor = false;
                }
            }
            else if (op1 is int && op2 is double)
            {
                if ((double)op2 != 0.0)
                {
                    double res = (int)op1 % (double)op2;
                    return res;
                }
                else
                {
                    divisor = false;
                }
            }
            else if (op1 is double && op2 is double)
            {
                if ((double)op2 != 0.0)
                {
                    double res = (double)op1 % (double)op2;
                    return res;
                }
                else
                {
                    divisor = false;
                }
            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Semantico", "Error de tipos en modulo", this.fila, this.columna));
            }
            if (!divisor)
            {
                Estatico.errores.Add(new ErrorCQL("Semantico", "Error en modulo divisor es cero", this.fila, this.columna));
            }
            return null;
        }

        private Object Division(Object op1, Object op2)
        {
            Boolean divisor = true;
            if (op1 is int && op2 is int)
            {
                if ((int)op2 != 0)
                {
                    double val = (int)op1 / (int)op2;
                    int res = (int)Math.Truncate(val);
                    return res;
                }
                else
                {
                    divisor = false;
                }
            }
            else if (op1 is double && op2 is int)
            {
                if ((int)op2 != 0)
                {
                    double res = (double)op1 / (int)op2;
                    return res;
                }
                else
                {
                    divisor = false;
                }
            }
            else if (op1 is int && op2 is double)
            {
                if ((double)op2 != 0.0)
                {
                    double res = (int)op1 / (double)op2;
                    return res;
                }
                else
                {
                    divisor = false;
                }
            }
            else if (op1 is double && op2 is double)
            {
                if ((double)op2 != 0.0)
                {
                    double res = (double)op1 / (double)op2;
                    return res;
                }
                else
                {
                    divisor = false;
                }
            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Semantico", "Error de tipos en division", this.fila, this.columna));
            }
            if (!divisor)
            {
                Estatico.errores.Add(new ErrorCQL("Semantico", "Error en division, divisor es cero", this.fila, this.columna));
            }
            return null;
        }
        // --------------------------------------falta date y time
        private Object Mayor(Object op1, Object op2)
        {
            if (op1 is int && op2 is int)
            {
                Boolean res = (int)op1 > (int)op2;
                return res;
            }
            else if (op1 is double && op2 is int)
            {
                Boolean res = (double)op1 > (int)op2;
                return res;
            }
            else if (op1 is int && op2 is double)
            {
                Boolean res = (int)op1 > (double)op2;
                return res;
            }
            else if (op1 is double && op2 is double)
            {
                Boolean res = (double)op1 > (double)op2;
                return res;
            }
            else if (op1 is Date && op2 is Date)
            {
                Date uno = (Date)op1;
                Date dos = (Date)op2;
                if (uno.year > dos.year)
                {
                    return true;
                }
                else if (uno.year == dos.year)
                {
                    if (uno.mes > dos.mes)
                    {
                        return true;
                    }
                    else if (uno.mes == dos.mes)
                    {
                        if (uno.dia > dos.dia)
                        {
                            return true;
                        }
                        return false;
                    }
                    return false;
                }
                return false;
            }
            else if (op1 is Tiempo && op2 is Tiempo)
            {
                Tiempo uno = (Tiempo)op1;
                Tiempo dos = (Tiempo)op2;
                if (uno.hora > dos.hora)
                {
                    return true;
                }
                else if (uno.hora == dos.hora)
                {
                    if (uno.minutos > dos.minutos)
                    {
                        return true;
                    }
                    else if (uno.minutos == dos.minutos)
                    {
                        if (uno.segundos > dos.segundos)
                        {
                            return true;
                        }
                        return false;
                    }
                    return false;
                }
                return false;
            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Semantico", "Error de tipos en la mayor ", this.fila, this.columna));
            }
            return null;
        }

        private Object Menor(Object op1, Object op2)
        {
            if (op1 is int && op2 is int)
            {
                Boolean res = (int)op1 < (int)op2;
                return res;
            }
            else if (op1 is double && op2 is int)
            {
                Boolean res = (double)op1 < (int)op2;
                return res;
            }
            else if (op1 is int && op2 is double)
            {
                Boolean res = (int)op1 < (double)op2;
                return res;
            }
            else if (op1 is double && op2 is double)
            {
                Boolean res = (double)op1 < (double)op2;
                return res;
            }
            else if (op1 is Date && op2 is Date)
            {
                Date uno = (Date)op1;
                Date dos = (Date)op2;
                if (uno.year < dos.year)
                {
                    return true;
                }
                else if (uno.year == dos.year)
                {
                    if (uno.mes < dos.mes)
                    {
                        return true;
                    }
                    else if (uno.mes == dos.mes)
                    {
                        if (uno.dia < dos.dia)
                        {
                            return true;
                        }
                        return false;
                    }
                    return false;
                }
                return false;
            }
            else if (op1 is Tiempo && op2 is Tiempo)
            {
                Tiempo uno = (Tiempo)op1;
                Tiempo dos = (Tiempo)op2;
                if (uno.hora < dos.hora)
                {
                    return true;
                }
                else if (uno.hora == dos.hora)
                {
                    if (uno.minutos < dos.minutos)
                    {
                        return true;
                    }
                    else if (uno.minutos == dos.minutos)
                    {
                        if (uno.segundos < dos.segundos)
                        {
                            return true;
                        }
                        return false;
                    }
                    return false;
                }
                return false;
            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Semantico", "Error de tipos en la menor ", this.fila, this.columna));
            }
            return null;
        }

        private Object Mayor_Igual(Object op1, Object op2)
        {
            if (op1 is int && op2 is int)
            {
                Boolean res = (int)op1 >= (int)op2;
                return res;
            }
            else if (op1 is double && op2 is int)
            {
                Boolean res = (double)op1 >= (int)op2;
                return res;
            }
            else if (op1 is int && op2 is double)
            {
                Boolean res = (int)op1 >= (double)op2;
                return res;
            }
            else if (op1 is double && op2 is double)
            {
                Boolean res = (double)op1 >= (double)op2;
                return res;
            }
            else if (op1 is Date && op2 is Date)
            {
                Date uno = (Date)op1;
                Date dos = (Date)op2;
                if (uno.year > dos.year)
                {
                    return true;
                }
                else if (uno.year == dos.year)
                {
                    if (uno.mes > dos.mes)
                    {
                        return true;
                    }
                    else if (uno.mes == dos.mes)
                    {
                        if (uno.dia > dos.dia)
                        {
                            return true;
                        }
                        else if (uno.dia == dos.dia)
                        {
                            return true;
                        }
                        return false;
                    }
                    return false;
                }
                return false;
            }
            else if (op1 is Tiempo && op2 is Tiempo)
            {
                Tiempo uno = (Tiempo)op1;
                Tiempo dos = (Tiempo)op2;
                if (uno.hora > dos.hora)
                {
                    return true;
                }
                else if (uno.hora == dos.hora)
                {
                    if (uno.minutos > dos.minutos)
                    {
                        return true;
                    }
                    else if (uno.minutos == dos.minutos)
                    {
                        if (uno.segundos > dos.segundos)
                        {
                            return true;
                        }
                        else if (uno.segundos == dos.segundos)
                        {
                            return true;
                        }
                        return false;
                    }
                    return false;
                }
                return false;
            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Semantico", "Error de tipos en la mayor igual", this.fila, this.columna));
            }
            return null;
        }

        private Object Menor_Igual(Object op1, Object op2)
        {
            if (op1 is int && op2 is int)
            {
                Boolean res = (int)op1 <= (int)op2;
                return res;
            }
            else if (op1 is double && op2 is int)
            {
                Boolean res = (double)op1 <= (int)op2;
                return res;
            }
            else if (op1 is int && op2 is double)
            {
                Boolean res = (int)op1 <= (double)op2;
                return res;
            }
            else if (op1 is double && op2 is double)
            {
                Boolean res = (double)op1 <= (double)op2;
                return res;
            }
            else if (op1 is Date && op2 is Date)
            {
                Date uno = (Date)op1;
                Date dos = (Date)op2;
                if (uno.year < dos.year)
                {
                    return true;
                }
                else if (uno.year == dos.year)
                {
                    if (uno.mes < dos.mes)
                    {
                        return true;
                    }
                    else if (uno.mes == dos.mes)
                    {
                        if (uno.dia < dos.dia)
                        {
                            return true;
                        }
                        else if (uno.dia == dos.dia)
                        {
                            return true;
                        }
                        return false;
                    }
                    return false;
                }
                return false;
            }
            else if (op1 is Tiempo && op2 is Tiempo)
            {
                Tiempo uno = (Tiempo)op1;
                Tiempo dos = (Tiempo)op2;
                if (uno.hora < dos.hora)
                {
                    return true;
                }
                else if (uno.hora == dos.hora)
                {
                    if (uno.minutos < dos.minutos)
                    {
                        return true;
                    }
                    else if (uno.minutos == dos.minutos)
                    {
                        if (uno.segundos < dos.segundos)
                        {
                            return true;
                        }
                        else if (uno.segundos == dos.segundos)
                        {
                            return true;
                        }
                        return false;
                    }
                    return false;
                }
                return false;
            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Semantico", "Error de tipos en la menor igual", this.fila, this.columna));
            }
            return null;
        }

        private Object Igual_Igual(Object op1, Object op2)
        {
            if (op1 is int && op2 is int)
            {
                Boolean res = (int)op1 == (int)op2;
                return res;
            }
            else if (op1 is double && op2 is int)
            {
                Boolean res = (double)op1 == (int)op2;
                return res;
            }
            else if (op1 is int && op2 is double)
            {
                Boolean res = (int)op1 == (double)op2;
                return res;
            }
            else if (op1 is double && op2 is double)
            {
                Boolean res = (double)op1 == (double)op2;
                return res;
            }
            else if (op1 is String && op2 is String)
            {
                Boolean res = ((String)op1).Equals((String)op2);
                return res;
            }
            else if (op1 is Date && op2 is Date)
            {
                Date uno = (Date)op1;
                Date dos = (Date)op2;
                if (uno.ToString().Equals(dos.ToString()))
                {
                    return true;
                }
                return false;
            }
            else if (op1 is Tiempo && op2 is Tiempo)
            {
                Tiempo uno = (Tiempo)op1;
                Tiempo dos = (Tiempo)op2;
                if (uno.ToString().Equals(dos.ToString()))
                {
                    return true;
                }
                return false;
            }
            else if (op1 is Nulo && op2 is Nulo)
            {
                return true;
            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Semantico", "Error de tipos en la igual igual", this.fila, this.columna));
            }
            return null;
        }

        private Object Diferente(Object op1, Object op2)
        {
            if (op1 is int && op2 is int)
            {
                Boolean res = (int)op1 != (int)op2;
                return res;
            }
            else if (op1 is double && op2 is int)
            {
                Boolean res = (double)op1 != (int)op2;
                return res;
            }
            else if (op1 is int && op2 is double)
            {
                Boolean res = (int)op1 != (double)op2;
                return res;
            }
            else if (op1 is double && op2 is double)
            {
                Boolean res = (double)op1 != (double)op2;
                return res;
            }
            else if (op1 is String && op2 is String)
            {
                Boolean res = ((String)op1).Equals((String)op2);
                return !res;
            }
            else if (op1 is Date && op2 is Date)
            {
                Date uno = (Date)op1;
                Date dos = (Date)op2;
                if (!(uno.ToString().Equals(dos.ToString())))
                {
                    return true;
                }
                return false;
            }
            else if (op1 is Tiempo && op2 is Tiempo)
            {
                Tiempo uno = (Tiempo)op1;
                Tiempo dos = (Tiempo)op2;
                if (!(uno.ToString().Equals(dos.ToString())))
                {
                    return true;
                }
                return false;
            }
            else if (op1 is Nulo && !(op2 is Nulo))
            {
                return true;
            }
            else if (!(op1 is Nulo) && op2 is Nulo)
            {
                return true;
            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Semantico", "Error de tipos en la diferente ", this.fila, this.columna));
            }
            return null;
        }

        private Object Or(Object op1, Object op2)
        {
            if (op1 is Boolean && op2 is Boolean)
            {
                Boolean res = (Boolean)op1 || (Boolean)op2;
                return res;
            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Semantico", "Error de tipos en or ", this.fila, this.columna));
            }
            return null;
        }
        private Object And(Object op1, Object op2)
        {
            if (op1 is Boolean && op2 is Boolean)
            {
                Boolean res = (Boolean)op1 && (Boolean)op2;
                return res;
            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Semantico", "Error de tipos en and ", this.fila, this.columna));
            }
            return null;
        }
        private Object Xor(Object op1, Object op2)
        {
            if (op1 is Boolean && op2 is Boolean)
            {
                Boolean res = (Boolean)op1 ^ (Boolean)op2;
                return res;
            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Semantico", "Error de tipos en xor ", this.fila, this.columna));
            }
            return null;
        }

        private Object Not(Object op1)
        {
            if (op1 is Boolean)
            {
                Boolean res = !((Boolean)op1);
                return res;
            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Semantico", "Error de tipos en not ", this.fila, this.columna));
            }
            return null;
        }

        private Object Menos_Unitario(Object op1)
        {
            if (op1 is double)
            {
                double res = 0.0 - (double)op1;
                return res;
            }
            else if (op1 is int)
            {
                int res = 0 - (int)op1;
                return res;
            }
            else
            {
                Estatico.errores.Add(new ErrorCQL("Semantico", "Error de tipos en menos unitario ", this.fila, this.columna));
            }
            return null;
        }
    }
}
