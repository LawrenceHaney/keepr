using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;
    private readonly KeepsRepository _krepo;
    
    public VaultKeepsService(VaultKeepsRepository repo, KeepsRepository krepo)
    {
      _repo = repo;
      _krepo = krepo;
    }

    internal VaultKeep Create(VaultKeep newVaultKeep, string id)
    {
      if (newVaultKeep.CreatorId != id)
      {
        throw new System.Exception("can't add keeps to other peoples vaults");
      }
      _repo.Create(newVaultKeep);
      _krepo.KeepInc(newVaultKeep.KeepId);
      return newVaultKeep; 
      
    }

    internal VaultKeep GetById(int id)
    {
      var res = _repo.GetById(id);
      if (res == null)
      {
        throw new System.Exception("Bad id, please check your input and try again");
      }
      return res;
    }

    internal string Delete(int id, string userId)
    {
      var res = GetById(id);
      if (res.CreatorId != userId)
      {
        throw new System.Exception("Credential mismatch, please confirm you have permission to do this");
      }
      _repo.DeleteVaultKeep(id);
      return "deleted";
    }
    
  }
}