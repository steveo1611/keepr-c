using Microsoft.AspNetCore.Mvc;
using Keepr.Repositories;
using Keepr.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Keepr.Controllers
{
    [Route("api/[controller]")]
    public class VKController : Controller
    {
        private readonly VaultKeepRepository _db;
        public VKController(VaultKeepRepository repo)
        {
            _db = repo;
        }
        // GET api/vk
        // using to get all keeps to view as unauthenicated etc.
        // [HttpGet]
        // public IEnumerable<VaultKeeps> GetAll()
        // {
        //     if (ModelState.IsValid)
        //     {
        //         return _db.GetAll();
        //     }
        //     return null;
        // }

        // GET api/Keep/5
        [HttpGet("{id}")]
        [Authorize]
        public IEnumerable<Keep> GetByVaultId(string id)
        {
            if (ModelState.IsValid)
            {
                return _db.GetByVaultId(id);
            }
            return null;
        }

        // POST api/vk
        [HttpPost]
        [Authorize]
        public VaultKeeps AddVK([FromBody]VaultKeeps newVK)
        {
            if (ModelState.IsValid)
            {
                var user = HttpContext.User;
                return _db.AddVK(newVK);
            }
            return null;
        }


        // DELETE api/VK/5
        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(int id)
        {
        }
    }


}