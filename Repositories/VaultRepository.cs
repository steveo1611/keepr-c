using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;
using Keepr.Repositories;
using Keepr.Controllers;

namespace Keepr.Repositories
{
  public class VaultRepository : DbContext
  {
        public VaultRepository(IDbConnection db) : base(db)
    {

    }
    // Create Vault
    public Vault CreateVault(Vault newVault)
    {
      int id = _db.ExecuteScalar<int>(@"
                INSERT INTO vaults (name, description, userId)
                VALUES (@Name, @Description, @UserId);
                SELECT LAST_INSERT_ID();
            ", newVault);
      newVault.Id = id;
      return newVault;
    }
    // Get ALL User vaults
    public IEnumerable<Vault> GetByUserId(string id)
    {
      return _db.Query<Vault>("SELECT * FROM vaults WHERE userId = @id;", new { id });
    }
    // // Get Vault by vault Id
    public Vault GetbyVaultId(int id)
    {
      return _db.QueryFirstOrDefault<Vault>("SELECT * FROM vaults WHERE id = @id;", new { id });
    }
    // // Edit
    // public Post EditPost(int id, Post post)
    // {
    //   post.Id = id;
    //   var i = _db.Execute(@"
    //             UPDATE posts SET
    //                 title = @Title,
    //                 body = @Body
    //             WHERE id = @Id
    //         ", post);
    //   if (i > 0)
    //   {
    //     return post;
    //   }
    //   return null;
    // }
    // Delete
    public bool DeleteVault(int id)
    {
      var i = _db.Execute(@"
      DELETE FROM vaults
      WHERE id = @id
      LIMIT 1;
      ", new { id });
      if (i > 0)
      {
        return true;
      }
      return false;
    }

    // Add get user favs to user
  }





}
