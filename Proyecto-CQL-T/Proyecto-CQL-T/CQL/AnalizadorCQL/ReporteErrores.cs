using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CQL_T.CQL.AnalizadorCQL
{
    class ReporteErrores
    {

        List<ErrorCQL> errores;
        public ReporteErrores(List<ErrorCQL> errores)
        {
            this.errores = errores;
        }

        public Boolean writeReport()
        {
            try
            {
                StreamWriter sw = new StreamWriter(@"Reporte.html");
                writeHeader(sw);
                writeTable(sw, errores);
                writeFooter(sw);
                sw.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void openReport()
        {
            try
            {

                System.Diagnostics.Process.Start(@"Reporte.html");
            }
            catch
            {
                return;
            }
        }

        private void writeHeader(StreamWriter sw)
        {
            try
            {
                sw.WriteLine("<!doctype html>");
                sw.WriteLine("<html lang=\"en\">");
                sw.WriteLine("<head>");
                sw.WriteLine("<meta charset=\"utf - 8\">");
                sw.WriteLine("<meta name=\"viewport\" content=\"width = device - width, initial - scale = 1, shrink - to - fit = no\">");
                sw.WriteLine("<link rel=\"stylesheet\" href=\"https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css\" integrity=\"sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO\" crossorigin=\"anonymous\">");
                sw.WriteLine("<title>Reporte de Errores</title>");
                sw.WriteLine("</head>");
                sw.WriteLine("<body>");
                sw.WriteLine("<div class=\"container\">");
                sw.WriteLine("<div class=\"jumbotron\">");
                sw.WriteLine("<h1 class=\"display - 4\">Reporte de Errores</h1>");
                sw.WriteLine("<p class=\"lead\"> 201503935 | Douglas Daniel Aguilar Cuque</p>");
                DateTime localDate = DateTime.Now;
                sw.WriteLine("<p class=\"lead\">" + localDate + "</p>");
                sw.WriteLine("</div>");
                sw.WriteLine("<br>");

            }
            catch
            {
                return;
            }
        }

        private void writeTable(StreamWriter sw, List<ErrorCQL> errores)
        {
            try
            {
                sw.WriteLine("<h1> Errores Encontrados: </h1>");
                sw.WriteLine("<br>");
                sw.WriteLine("<table class=\"table table-bordered\" >");
                sw.WriteLine("<thead class=\"thead-dark\">");
                sw.WriteLine("<tr>");
                sw.WriteLine("<th scope=\"col\">#</th>");
                sw.WriteLine("<th scope=\"col\">Tipo</th>");
                sw.WriteLine("<th scope=\"col\">Mensaje</th>");
                sw.WriteLine("<th scope=\"col\">Linea</th>");
                sw.WriteLine("<th scope=\"col\">Columna</th>");
                sw.WriteLine("</tr>");
                sw.WriteLine("</thead>");
                sw.WriteLine("<tbody>");
                int x = 1;
                foreach (ErrorCQL e in errores)
                {
                    sw.WriteLine("<tr class=\"bg-danger text-white\">");
                    sw.WriteLine("<th scope=\"row\">" + x + "</td>");
                    sw.WriteLine("<td>" + e.Tipo + "</td>");
                    sw.WriteLine("<td>" + e.Mensaje + "</td>");
                    sw.WriteLine("<td>" + e.Linea + "</td>");
                    sw.WriteLine("<td>" + e.Columna + "</td>");
                    sw.WriteLine("</tr>");
                    x++;
                }
                sw.WriteLine("</tbody>");
                sw.WriteLine("</table>");
                sw.WriteLine("<br>");
            }
            catch
            {
                return;
            }
        }

        private void writeFooter(StreamWriter sw)
        {
            try
            {
                sw.WriteLine("</div>");
                sw.WriteLine("<script src=\"https://code.jquery.com/jquery-3.3.1.slim.min.js\" integrity=\"sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo\" crossorigin=\"anonymous\"></script>");
                sw.WriteLine("<script src=\"https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js\" integrity=\"sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49\" crossorigin=\"anonymous\"></script>");
                sw.WriteLine("<script src=\"https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js\" integrity=\"sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy\" crossorigin=\"anonymous\"></script>");
                sw.WriteLine("</body>");
                sw.WriteLine("</html>");
            }
            catch
            {
                return;
            }
        }

    }
}
