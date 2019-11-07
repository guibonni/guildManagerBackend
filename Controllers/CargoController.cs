using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GCGuildManager.Models;

namespace GCGuildManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CargoController : ControllerBase
    {
        private readonly ILogger<CargoController> _logger;

        public CargoController(ILogger<CargoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        //public IEnumerable<Cargo> Get()
        public string Get()
        {
            /*var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Cargo
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();*/
            return "Api de cargos";
        }
    }
}
