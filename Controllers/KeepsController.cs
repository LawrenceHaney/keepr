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
  //defines controller as an api entry point and the route for the api
  [ApiController]
  [Route("api/[controller]")]

  //instantiates the controller as an extension of the base controller
  public class KeepsController : ControllerBase
  {
    //creates a readonly service that can accept commands from the controller
    private readonly KeepsService _serv;

    public KeepsController(KeepsService serv)
    {
      _serv=serv;
    }
    //on api "/keeps" get get all keeps
    [HttpGet]
    public ActionResult<Keep> Get()
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

    //on api "/keeps/:id" get keep with keep.id
    [HttpGet("{id}")]
    public ActionResult<Keep> Get(int id)
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

    //on api "/keeps" post takes in a keep to add to the SQL database
    [HttpPost]
    // [Authorize]
    public async Task<ActionResult<Keep>> Create([FromBody] Keep newKeep)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newKeep.CreatorId = userInfo.Id;
        newKeep.Creator = userInfo;
        newKeep.Views = 0;
        newKeep.Shares = 0;
        newKeep.Keeps = 0;
        return Ok(_serv.Create(newKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    //on api "/keeps" delete takes in an id to be deleted
    [HttpDelete("{id}")]
    [Authorize]

    public async Task<ActionResult<Keep>> Delete(int id)
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