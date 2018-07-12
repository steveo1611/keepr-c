using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;
using Keepr.Repositories;
using Keepr.Controllers;

namespace Keepr.Repositories
{
  public class KeepRepository : DbContext
  {
        public KeepRepository(IDbConnection db) : base(db)
    {

    }
    // Create Keep
    public Keep CreateKeep(Keep newKeep)
    {
      int id = _db.ExecuteScalar<int>(@"
                INSERT INTO keeps (name, description, contentURL, userId)
                VALUES (@Name, @Description, @ContentURL, @UserId);
                SELECT LAST_INSERT_ID();
            ", newKeep);
      newKeep.Id = id;
      return newKeep;
    }
   // GetAll keeps
    public IEnumerable<Keep> GetAll()
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE IsPublic = 1;");
    }
    // GetbyUser
    public IEnumerable<Keep> GetByUserId(string id)
    {
      return _db.Query<Keep>("SELECT *  FROM keeps WHERE userId = @id;", new { id });
    }
    // // GetbyId
    // public Keep GetbyKeepId(int id)
    // {
    //   return _db.QueryFirstOrDefault<Keep>("SELECT * FROM keeps WHERE id = @id;", new { id });
    // }
    // // Edit
    // public Keep EditKeep(int id, Keep keep)
    // {
    //   keep.Id = id;
    //   var i = _db.Execute(@"
    //             UPDATE keeps SET
    //                 name = @Name,
    //                 description = @Description,
    //                 contentURL = @ContentURL,
    //             WHERE id = @Id
    //         ", keep);
    //   if (i > 0)
    //   {
    //     return keep;
    //   }
    //   return null;
    // }
    // Delete
    public bool DeleteKeep(int id)
    {
      var i = _db.Execute(@"
      DELETE FROM keeps
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
