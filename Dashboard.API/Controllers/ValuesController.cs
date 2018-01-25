using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dashboard.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly DataContext _context;

        public ValuesController(DataContext context)
        {
            _context = context;

        }
        // GET api/values
        [HttpGet]
        public async Task <IActionResult> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task <IActionResult> GetUser(int id)
        {
            var user =  await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(user);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
