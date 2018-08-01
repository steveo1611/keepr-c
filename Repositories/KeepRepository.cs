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
                INSERT INTO keeps (name, description, contentURL, userId, isPublic)
                VALUES (@Name, @Description, @ContentURL, @UserId, @IsPublic);
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

        public Keep UpdateViewCount(Keep keepId)
        {
            int id = _db.ExecuteScalar<int>(@"
            UPDATE keeps SET viewed = viewed +1 
            WHERE Id = @Id;
            SELECT LAST_INSERT_ID();
            ", keepId);
           keepId.Id = id;
           return keepId;
        }

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
// need to still add votes for added to vaults and for views
// 