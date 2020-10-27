using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
//defines controller as an api entry point and the route for the api
  [ApiController]
  [Route("api/[controller]")]

//instantiates the controller as an extension of the base controller
  public class VaultsController : ControllerBase
  {
//creates a readonly service that can accept commands from the controller
    private readonly VaultsService _serv;

    public VaultsController(VaultsService serv)
    {
      _serv=serv;
    }
//on api "/vaults" get get all vaults
    [HttpGet]
    public ActionResult<Vault> Get()
    {
      try
      {
        return Ok(_serv.GetAll());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

//on api "vaults/:id" get vault with vault.id
    [HttpGet("{id}")]
    public ActionResult<Vault> Get(int id)
    {
      try
      {
        return Ok(_serv.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

// on api "/vaults/:userId/user" gets all vaults created by user and returns private vaults only if userid matches creator id
    [HttpGet("{id}/user")]

    public async ActionResult<Vault> GetByUser(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_serv.GetByUser(id, userInfo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

//on api "/vaults" post takes in a vault to add to the SQL database
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Vault>> Create([FromBody] Vault newVault)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newVault.CreatorId = userInfo.Id;
        newVault.Creator = userInfo;
        return Ok(_serv.Create(newVault));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

//on api "/vaults" delete takes in an id to be deleted
    [HttpDelete("{id}")]
    [Authorize]

    public async Task<ActionResult<Vault>> Delete(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_serv.Delete(id, userInfo.Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}