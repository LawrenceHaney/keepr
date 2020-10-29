using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]

  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _serv;
    private readonly KeepsService _kServ;
    private readonly VaultsService _vserv;

    public VaultKeepsController(VaultKeepsService serv, KeepsService kServ, VaultsService vServ)
    {
      _serv = serv;
      _kServ = kServ;
      _vserv = vServ;
    }

    [HttpPost]
    [Authorize]

    public async Task<ActionResult<VaultKeep>> Create([FromBody] VaultKeep newVaultKeep)
    {
      try
      {
        Profile userinfo = await HttpContext.GetUserInfoAsync<Profile>();
        Vault vault = _vserv.GetById(newVaultKeep.VaultId, userinfo.Id);
        newVaultKeep.CreatorId = userinfo.Id;
        return Ok(_serv.Create(newVaultKeep, vault.CreatorId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpDelete("{id}")]
    [Authorize]

    public async Task<ActionResult<VaultKeep>> Delete(int id)
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