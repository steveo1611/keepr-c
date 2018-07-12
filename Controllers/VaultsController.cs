using Microsoft.AspNetCore.Mvc;
using Keepr.Repositories;
using Keepr.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Keepr.Controllers
{
    [Route("api/[controller]")]
    public class VaultsController : Controller
    {
        private readonly VaultRepository _db;
        public VaultsController(VaultRepository repo)
        {
            _db = repo;
        }

        // GET api/vault/id
        [HttpGet("{id}")]
        [Authorize]
        public IEnumerable<Vault> GetByUserId(string id)
        {
            if (ModelState.IsValid)
            {
                return _db.GetByUserId(id);
            }
            return null;
        }

        // POST api/Vault
        [HttpPost]
        [Authorize]
        public Vault CreateVault([FromBody]Vault newVault)
        {
            if (ModelState.IsValid)
            {
                var user = HttpContext.User;
                newVault.UserId = user.Identity.Name;
                return _db.CreateVault(newVault);
            }
            return null;
        }
        // PUT api/Vault/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }

        // DELETE api/Vault/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }


}