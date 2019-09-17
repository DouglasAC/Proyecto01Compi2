using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.Graficador
{
    public class Graficador
    {
        private int index;

        public void graficar(ParseTreeNode nodo)
        {
            StreamWriter archivo = new StreamWriter("ArbolSintactico.dot");
            string contenido = "graph G {";
            contenido += "node [shape=ellipse, style=filled, color=Gray95];\n edge[color=lightblue];";
            index = 0;
            definirNodos(nodo, ref contenido);
            index = 0;
            enlazarNodos(nodo, 0, ref contenido);
            contenido += "}";
            archivo.Write(contenido);
            archivo.Close();


            ProcessStartInfo startInfo = new ProcessStartInfo(@"cmd.exe ", @"C:\\Program Files (x86)\\Graphviz2.38\\bin\\dot.exe");
            startInfo.Arguments = "-Tpng ArbolSintactico.dot -o ArbolSintactico.png";
            Process.Start(startInfo);
            Thread.Sleep(2000);
            //startInfo.FileName = "ArbolSintactico.png";
            //Process.Start(startInfo);



        }

        public void definirNodos(ParseTreeNode nodo, ref string contenido)
        {
            if (nodo != null)
            {
                contenido += "node" + index.ToString() + "[label = \"" + nodo.ToString() + "\"];";
                index++;

                foreach (ParseTreeNode hijo in nodo.ChildNodes)
                {
                    definirNodos(hijo, ref contenido);
                }
            }
        }


        public void enlazarNodos(ParseTreeNode nodo, int actual, ref string contenido)
        {
            if (nodo != null)
            {
                foreach (ParseTreeNode hijo in nodo.ChildNodes)
                {
                    index++;
                    contenido += "\"node" + actual.ToString() + "\"--" + "\"node" + index.ToString() + "\"";
                    enlazarNodos(hijo, index, ref contenido);
                }
            }
        }

    }
}
