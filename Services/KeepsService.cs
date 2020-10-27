using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService
  {
    //defines a read only Repository that service can hand off to
    private readonly KeepsRepository _repo;
    
    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }

    //takes in user data from the controller and passes the object on to the repository
    internal Keep Create(Keep newKeep)
    {
      newKeep.Id = _repo.Create(newKeep);
      return newKeep;
    }
    //passes get all request to the repository
    internal IEnumerable<Keep> GetAll()
    {
      return _repo.GetAll();
    }
    //passses an id to repo to return a single keep
    internal Keep GetById(int id)
    {
      var res = _repo.GetById(id);
      if (res == null)
      {
        throw new System.Exception("Bad id, please check your input and try again");
      }
      return res;
    }
    //Passes an id to get a collection of keeps
    internal IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int id)
    {
      return _repo.GetKeepsByVaultId(id);
    }
    
    //Passes an id to the repository to delete
    internal string Delete(int id, string userId)
    {
      var res = GetById(id);
      if (res.CreatorId != userId)
      {
        throw new System.Exception("Credential mismatch, please confirm you have permission to do this");
      }
      _repo.DeleteKeep(id);
      return "Keep @res.name has been deleted";
    }
  }
}