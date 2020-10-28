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
    JOIN profiles profile on keep.creatorId = profile.id
    ";
    //SQL call to create new table item
    internal int Create(Keep newKeep)
    {
      string sql =@"
      INSERT INTO keeps
      (creatorId, name, description, img, views, shares, keeps)
      VALUES
      (@CreatorId, @Name, @Description, @Img, @Views, @Shares, @Keeps);
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
    internal Keep GetById(int id)
    {
      string sql = populateCreator + "WHERE keep.id = @id";
      return _db.Query<Keep, Profile, Keep>(
        sql, (keep, profile)=> 
        {keep.Creator = profile; return keep;}, new { id },
        splitOn: "id").FirstOrDefault();
    }

    //SQL call that edits a keep given a new keep and an id
    internal Keep Edit(Keep payload)
    {
      string sql = @"
      UPDATE keeps
      SET
      name = @Name, description = @Description, img = @Img, views = @Views, shares = @Shares, keeps = @Keeps
      WHERE id = @Id;";
      _db.Execute(sql, payload);
      return payload;
    }

    //SQL call that gets all keeps in a vault
    internal IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int id)
    {
      string sql =@"
      SELECT k.*, vk.id AS VaultKeepId
      FROM vaultkeeps vk
      JOIN keeps k ON k.id = vk.keepId
      WHERE vaultId = @id
      ";
      return _db.Query<VaultKeepViewModel>(sql, new {id});
    }

    //SQL call to get all user keeps
    internal IEnumerable<Keep> GetByUser(string CreatorId)
    {
      string sql = populateCreator + "WHERE creatorId - @CreatorId";
      return _db.Query<Keep, Profile, Keep>(
        sql, (keep, profile)=> 
        {keep.Creator = profile; return keep;}, new { CreatorId },
        splitOn: "id");
    }
    internal IEnumerable<Keep> View(int Id)
    {
      string sql = @"
      UPDATE keeps
      SET views = views + 1
      WHERE id = @Id;";
      return _db.Query<Keep>(sql);
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