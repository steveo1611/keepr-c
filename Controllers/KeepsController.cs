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
        public KeepsController(KeepRepository repo)
        {
            _db = repo;
        }
        // GET api/Keep
        // using to get all keeps to view as unauthenicated etc.
        [HttpGet]
        public IEnumerable<Keep> GetAll()
        {
            if (ModelState.IsValid)
            {
                return _db.GetAll();
            }
            return null;
        }

        // GET api/Keep/5
        [HttpGet("{id}")]
        [Authorize]
        public IEnumerable<Keep> GetByUserId(string id)
        {
            if (ModelState.IsValid)
            {
                return _db.GetByUserId(id);
            }
            return null;
        }

        // POST api/Keep
        [HttpPost]
        [Authorize]
        public Keep CreateKeep([FromBody]Keep newKeep)
        {
            if (ModelState.IsValid)
            {
                var user = HttpContext.User;
                newKeep.UserId = user.Identity.Name;
                return _db.CreateKeep(newKeep);
            }
            return null;
        }

        //PUT api/Keep/5
        [HttpPut("{id}")]
        public Keep EditKeep(Keep keepId)
        {
            if (ModelState.IsValid)
            {
                return _db.UpdateViewCount(keepId);
            }
            return null;
        }

        // DELETE api/Keep/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }


}