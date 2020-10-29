using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {
    //defines DB
    private readonly IDbConnection _db;
    //Insures program integrity by ofuscating db
    public VaultKeepsRepository(IDbConnection db)
    {
      _db= db;
    }

    internal int Create(VaultKeep newVaultKeep)
    {
      string sql= @"
      INSERT INTO vaultkeeps
      (creatorId, vaultId, keepId)
      VALUES
      (@creatorId, @vaultId, @keepId)
      ";
      return _db.Execute(sql, newVaultKeep);
    }

    internal VaultKeep GetById(int id)
    {
      string sql = @"
      SELECT
      vaultkeep.*,
      From vaultkeeps vaultkeep
      WHERE vaultkeep.id = @id
      ";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new {id});
    }

    internal void DeleteVaultKeep(int id)
    {
      string sql = "DELETE FROM vaultkeeps WHERE id = @id";
      _db.Execute(sql, new {id});
    }

  }
}