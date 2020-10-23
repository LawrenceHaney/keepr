using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    //defines DB
    private readonly IDbConnection _db;
    //Insures program integrity by ofuscating db
    public KeepsRepository(IDbConnection db)
    {
      _db= db;
    }
    //SQL string to populate profile
    private readonly string populateCreator = @"
    SELECT
    keep.*,
    profile.*
    FROM keeps keep
    JOIN profiles profile on keep.creatorEmail = profile.email
    ";
    //SQL call to create new table item
    internal int Create(Keep newKeep)
    {
      string sql =@"
      INSERT INTO Keeps
      (creatorId, name, description, img)
      VALUES
      (@CreatorId, @Name, @Description, @Img);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newKeep);
    }
    //SQL Call to GetAll keeps and populate profile info from populateCreator
    internal IEnumerable<Keep> GetAll()
    {
      string sql = populateCreator;
      return _db.Query<Keep, Profile, Keep>(
        sql, (keep, profile)=> 
        {keep.Creator = profile; return keep;}, 
        splitOn: "id");
    }

    //SQL call that returns a keep by id and populates the creator profile
    //TODO adress if the fuction  is needed for scope
    internal Keep GetById(int id)
    {
      string sql = populateCreator + "WHERE keep.id = @id";
      return _db.Query<Keep, Profile, Keep>(
        sql, (keep, profile)=> 
        {keep.Creator = profile; return keep;}, 
        splitOn: "id").FirstOrDefault();
    }

    //SQL call to remove a keep from the keep table
    //TODO adress if cascade delete needs to hit the VAULTKEEP object
        internal void DeleteKeep(int id)
    {
      string sql = "DELETE FROM Keeps WHERE id = @id";
      _db.Execute(sql, new {id});
    }
  }
}