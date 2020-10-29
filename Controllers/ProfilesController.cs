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
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _ps;
    private readonly KeepsService _kserv;

    private readonly VaultsService _vserv;
    public ProfilesController(ProfilesService ps, KeepsService kserv, VaultsService vserv)
    {
      _ps = ps;
      _kserv = kserv;
      _vserv = vserv;
    }


    [HttpGet]
    [Authorize]
    public async Task<ActionResult<Profile>> Get()
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_ps.GetOrCreateProfile(userInfo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
        // gets user profiles by id to populate user pages
    [HttpGet("{id}")]
    public ActionResult<Profile> GetProfile(string id)
    {
      
      try
      {
        return Ok(_ps.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    
    }

    [HttpGet("{userid}/keeps")]
    
    public async Task<ActionResult<IEnumerable<Keep>>> GetKeepsByUser(string userid)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_kserv.GetByUser(userid, userInfo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{userid}/vaults")]

    public async Task<ActionResult<IEnumerable<Vault>>> GetVaultsByUser(string userid)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_vserv.GetByUser(userid, userInfo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    
  }
}