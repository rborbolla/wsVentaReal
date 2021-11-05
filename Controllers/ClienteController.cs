using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wsVentaReal.Models;

namespace wsVentaReal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using (VentaRealContext db = new VentaRealContext())
            {
                var list = db.Clientes.ToList();
                return Ok(list);
            }
            
        }
    }
}
