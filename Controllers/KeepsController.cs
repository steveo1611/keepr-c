using Microsoft.AspNetCore.Mvc;
using Keepr.Repositories;
using Keepr.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Keepr.Controllers
{
    [Route("api/[controller]")]
    public class KeepsController : Controller
    {
        private readonly KeepRepository _db;
        // GET api/values
        [HttpGet]
        public IEnumerable<Keep> GetAll()
        {
             return _db.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [Authorize]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }


}