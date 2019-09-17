using Proyecto_CQL_T.CQL.InterpreteCQL.Entorno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.SentenciasDBS
{
    class Columna
    {
        public string nombre;
        public Tipo tipo;
        public bool primaria;

        public Columna(string nombre, Tipo tipo, bool primaria)
        {
            this.nombre = nombre.ToLower();
            this.tipo = tipo;
            this.primaria = primaria;
        }
    }
}
