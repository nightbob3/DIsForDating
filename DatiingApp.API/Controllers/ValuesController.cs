using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using DatiingApp.API.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DatiingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {

        private readonly DataContext _context;

        public ValuesController(DataContext context)
        {       
            
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> GetValues()
        {
            var values = await _context.Values.ToListAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetValue(int id) 
        {
            var value = await _context.Values.FirstOrDefaultAsync(t => t.Id == id);

            return Ok(value);
        }

        [HttpPost]

        public void Post([FromBody] string value)
        {

        }

        [HttpPut("{id}")]

        public void Put([FromBody] string value)
        {

        }

        [HttpDelete("{id}")]

        public void Delete(int id)
        {

        }


    }
}