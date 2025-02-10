using Microsoft.AspNetCore.Mvc;
using Padel.Application.DTOs;
using Padel.Application.Interfaces;

namespace Padel.Presentation.Controllers;

[ApiController]
[Route("[Controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService service)
    {
        _userService = service;
    }

    [HttpPost]
    public ActionResult CreateUser([FromBody] CreateUserDto dto)
    {
        var result = _userService.CreateUser(dto);

        return Ok(result);
    }
    
    //https://localhost:5001/user/1
    [HttpGet("{userId}")]
    public ActionResult GetUser(int userId)
    {
        return Ok(userId);
    }
}