using System.Collections.Generic;
using System.Linq;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class VaultsService
    {
    //defines a read only Repository that service can hand off to
    private readonly VaultsRepository _repo;
    
    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }

//takes in user data from the controller and passes the object on to the repository
    internal Vault Create(Vault newVault)
    {
      newVault.Id = _repo.Create(newVault);
      return newVault;
    }

//passes get all request to the repository
    internal IEnumerable<Vault> GetAll()
    {
      return _repo.GetAll();
    }

    internal Vault GetById(int id)
    {
      var res = _repo.GetById(id);
      if (res == null)
      {
        throw new System.Exception("Bad id, please check your input and try again");
      }
      return res;
    }
    //TODO un comment .tolist
    internal IEnumerable<Vault> GetByUser(string id, Profile userInfo)
    {
      var res = _repo.GetByUser(id);
      if (res == null)
      {
        throw new System.Exception("Bad id, please check your input and try again");
      }
      return res;
      // .ToList().FindAll(Vault => Vault.CreatorId == userInfo.Id || !Vault.IsPrivate);
    }
//Passes an id to the repository to delete
    internal string Delete(int id, string userId)
    {
      var res = GetById(id);
      if (res.CreatorId != userId)
      {
        throw new System.Exception("Credential mismatch, please confirm you have permission to do this");
      }
      _repo.DeleteVault(id);
      return "Vault @res.name has been deleted";
    }
    }
}