using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wsVentaReal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            List<WeatherForecast> list = new List<WeatherForecast>();

            list.Add(new WeatherForecast() { Id = 5, Nombre = "Roberto Borbolla" });
            list.Add(new WeatherForecast() { Id = 2, Nombre = "Alejandra Trejo" });

            return list;
        }
    }
}
