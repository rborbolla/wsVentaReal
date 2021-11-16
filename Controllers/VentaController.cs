using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wsVentaReal.Models;
using wsVentaReal.Models.Request;
using wsVentaReal.Models.Response;
using wsVentaReal.Services;

namespace wsVentaReal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VentaController : ControllerBase
    {
        private VentaService _venta;

        public VentaController(VentaService venta)
        {
            this._venta = venta;
        }

        [HttpPost]
        public IActionResult Add(VentaRequest model)
        {
            Respuesta respuesta = new Respuesta();

            try
            {
                _venta.Add(model);
                respuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.ToString();
                Console.WriteLine(ex.ToString());
            }

            return Ok(respuesta);
        }
    }
}
