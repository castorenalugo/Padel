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
    public ActionResult GetUserById(int userId)
    {
        var result = _userService.GetUserById(userId);
        if (result == null)
        {
            return NotFound("USUARIO NO EXISTE");
        }
        return Ok(userId);
    }
    
    [HttpDelete("{userId}")]
    public ActionResult DeleteUser(int userId)
    {
        var result = _userService.DeleteUser(userId);
        if (!result)
        {
            return NotFound("USUARIO NO EXISTE O INACTIVO");
        }
        return Ok("USUARIO ELIMINADO");
    }
    
    [HttpPut("{userId}")]
    public ActionResult UpdateUser(int userId, [FromBody] UpdateUserDto dto)
    {
        var isUpdated = _userService.UpdateUser(userId, dto);

        if (!isUpdated)
        {
            return NotFound("USUARIO NO EXISTE O INACTIVO");
        }

        return Ok("USUARIO ACTUALIZADO");
    }
}