using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DatiingApp.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AstrologyForecastController : ControllerBase
    {
        private static readonly string[] Signs = new[]
        {
            "Gemini: You're gonna die", "Libra: You're gonna die, twice"
        };

        [HttpGet]

        public IEnumerable<AstrologyForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1,2).Select(index => new AstrologyForecast
            {
                Date = DateTime.Now,
                Message = Signs[rng.Next(Signs.Length)]
            }).ToArray();
        }

    }

}