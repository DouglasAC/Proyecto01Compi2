using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.AnalizadorCQL
{
    class ErrorCQL
    {
        public String Tipo { get; }
        public String Mensaje { get; }
        public int Linea { get; }
        public int Columna { get; }

        public List<String> esperados { get; }

        public ErrorCQL(String tipo, String mensaje, int linea, int columna)
        {
            this.Tipo = tipo;
            this.Mensaje = mensaje;
            this.Linea = linea;
            this.Columna = columna;
            this.esperados = new List<string>();
        }

        public void AddEsperado(String esperado)
        {
            this.esperados.Add(esperado);
        }

    }
}
