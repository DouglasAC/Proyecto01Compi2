using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Irony.Parsing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_CQL_T.CQL.AnalizadorCQL;
using Proyecto_CQL_T.CQL.Extras;
using Proyecto_CQL_T.LUP;
using Proyecto_CQL_T.LUP.Gramatica;
using Proyecto_CQL_T.Respuestas;

namespace Proyecto_CQL_T.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaquetesLUPController : ControllerBase
    {

        public ActionResult Post([FromBody] PaquetesLUP paquete)
        {
            Console.WriteLine(paquete.paquete);
            AnalizadorLUP analizador = new AnalizadorLUP();
            
            String respuesta = "";
            respuesta = analizador.analizar(paquete.paquete); ;
           

            return Ok(new PaquetesLUP(respuesta));
        }
    }
}