using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
    public class VaultsRepository
    {
      //defines db
      private readonly IDbConnection _db;
      //ofuscates db
      public VaultsRepository(IDbConnection db)
      {
        _db = db;
      }
      //SQL string to populate profile
      private readonly string populateCreator = @"
    SELECT
    vault.*,
    profile.*
    FROM vaults vault
    JOIN profiles profile on vault.creatorEmail = profile.email
    ";

    //SQL call to create new Vault
    internal int Create(Vault newVault)
    {
      string sql =@"
      INSERT INTO vaults
      (creatorId, name, description)
      VALUES
      (@CreatorId, @Name, @Description);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newVault);
    }
    //SQL Call to GetAll Vaults and populate profile info from populateCreator
    internal IEnumerable<Vault> GetAll()
    {
      string sql = populateCreator;
      return _db.Query<Vault, Profile, Vault>(
        sql, (vault, profile)=> 
        {vault.Creator = profile; return vault;}, 
        splitOn: "id");
    }

    //SQL call that returns a vault by id and populates the creator profile
    internal Vault GetById(int id)
    {
      string sql = populateCreator + "WHERE vault.id = @id";
      return _db.Query<Vault, Profile, Vault>(
        sql, (vault, profile)=> 
        {vault.Creator = profile; return vault;}, 
        splitOn: "id").FirstOrDefault();
    }

    //SQL call to remove a vault from the vault table
    //TODO adress if cascade delete needs to hit the VAULTKEEP object
    internal void DeleteVault(int id)
    {
      string sql = "DELETE FROM vaults WHERE id = @id";
      _db.Execute(sql, new {id});
    }

    }
}