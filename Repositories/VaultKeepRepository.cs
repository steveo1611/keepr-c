using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;
using Keepr.Repositories;
using Keepr.Controllers;

namespace Keepr.Repositories
{
    public class VaultKeepRepository : DbContext
    {
        public  VaultKeepRepository(IDbConnection db) : base(db)
        {

        }
        // Create vaultkeep
        public VaultKeeps CreateVK(VaultKeeps newvk)
        {
            int id = _db.ExecuteScalar<int>(@"
                INSERT INTO vaultkeeps (vaultId, keepId, userId)
                VALUES (@vaultId, @keepId, @UserId);
                SELECT LAST_INSERT_ID();
            ", newvk);
            newvk.Id = id;
            return newvk;
        }
        // GetAll vaultkeeps
        public IEnumerable<VaultKeeps> GetAll()
        {
            return _db.Query<VaultKeeps>("SELECT * FROM keeps WHERE IsPublic = 1;");
        }
        // GetbyUser
        public IEnumerable<VaultKeeps> GetByUserId(string id)
        {
            return _db.Query<VaultKeeps>("SELECT *  FROM keeps WHERE userId = @id;", new { id });
        }

        // Delete
        public bool DeleteVK(int id)
        {
            var i = _db.Execute(@"
      DELETE FROM vaultkeeps
      WHERE id = @id
      LIMIT 1;
      ", new { id });
            if (i > 0)
            {
                return true;
            }
            return false;
        }
    }
}