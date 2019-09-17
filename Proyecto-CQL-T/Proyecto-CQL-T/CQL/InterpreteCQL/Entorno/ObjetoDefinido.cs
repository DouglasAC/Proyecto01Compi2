using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.InterpreteCQL.Entorno
{
    class ObjetoDefinido
    {
        public LinkedList<Declaracion> declaraciones;

        public string identificador;

        public ObjetoDefinido(LinkedList<Declaracion> declaraciones, string identificador)
        {
            this.declaraciones = declaraciones;
            this.identificador = identificador;
        }
    }
}
