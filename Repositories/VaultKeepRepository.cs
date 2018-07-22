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
        public VaultKeepRepository(IDbConnection db) : base(db)
        {

        }
        //AddKeep vaultkeep
        public VaultKeeps AddVK(VaultKeeps newvk)
        {
            int id = _db.ExecuteScalar<int>(@"
                INSERT INTO vaultkeeps (vaultId, keepId, userId)
                VALUES (@vaultId, @keepId, @userId);
                SELECT LAST_INSERT_ID();
            ", newvk);
            newvk.Id = id;
            return newvk;
        }
        // GetAll vaultkeeps
        // public IEnumerable<VaultKeeps> GetAll()
        // {
        //     return _db.Query<VaultKeeps>("SELECT * FROM keeps WHERE IsPublic = 1;");
        // }
        // GetbyUser
        public IEnumerable<Keep> GetByVaultId(string id)
        {
            return _db.Query<Keep>(@"
            SELECT * FROM vaultkeeps vk
            INNER JOIN keeps k on k.id = vk.keepId
            WHERE (vaultId = @id);
            ", new { id });
        }
        // USE THIS LINE FOR GET KEEPS BY VAULTID
        //-- SELECT* FROM vaultkeeps vk
        //-- INNER JOIN keeps k ON k.id = vk.keepId
        //-- WHERE (vaultId = 2)

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