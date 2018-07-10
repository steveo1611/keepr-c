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
    // public Keep CreatePost(Keep newKeep)
    // {
    //   int id = _db.ExecuteScalar<int>(@"
    //             INSERT INTO posts (title, body, authorId)
    //             VALUES (@Title, @Body, @AuthorId);
    //             SELECT LAST_INSERT_ID();
    //         ", newKeep);
    //   newKeep.Id = id;
    //   return newKeep;
    // }
    // GetAll Post
    public IEnumerable<Keep> GetAll()
    {
      return _db.Query<Keep>("SELECT * FROM Keeps;"); // TODO: need to make  only return public keeps
    }
    // // GetbyAuthor
    // public IEnumerable<Post> GetbyAuthorId(int id)
    // {
    //   return _db.Query<Post>("SELECT * FROM posts WHERE authorId = @id;", new { id });
    // }
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
