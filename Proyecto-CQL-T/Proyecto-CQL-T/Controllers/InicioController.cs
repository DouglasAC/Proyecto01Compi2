using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using Proyecto_CQL_T.Respuestas;

namespace Proyecto_CQL_T.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InicioController : ControllerBase
    {

        public ActionResult Post([FromBody] LoginUs loging)
        {
            
            return Ok(new LoginUs("[+LOGIN]FAIL[-LOGIN]"));
        }
    }
}