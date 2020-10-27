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
      SELECT LAST_INSERT_ID();
      ";
      return _db.ExecuteScalar<int>(sql, newVaultKeep);
    }

    internal void DeleteVaultKeep(int id)
    {
      string sql = "DELETE FROM vaultkeeps WHERE id = @id";
      _db.Execute(sql, new {id});
    }

  }
}