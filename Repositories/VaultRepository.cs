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
//    // GetAll Post
//     public IEnumerable<Vault> GetAll()
//     {
//       return _db.Query<Vault>("SELECT * FROM Vaults;"); // TODO: need to make  only return public keeps
//     }
    // GetbyUser
    public IEnumerable<Vault> GetByUserId(string id)
    {
      return _db.Query<Vault>("SELECT * FROM vaults WHERE userId = @id;", new { id });
    }
    // // GetbyId
    // public Post GetbyPostId(int id)
    // {
    //   return _db.QueryFirstOrDefault<Post>("SELECT * FROM posts WHERE id = @id;", new { id });
    // }
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
    // // Delete
    // public bool DeletePost(int id)
    // {
    //   var i = _db.Execute(@"
    //   DELETE FROM posts
    //   WHERE id = @id
    //   LIMIT 1;
    //   ", new { id });
    //   if (i > 0)
    //   {
    //     return true;
    //   }
    //   return false;
    // }

    // Add get user favs to user
  }





}
