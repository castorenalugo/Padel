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
        var resultado = _userService.GetUserById(userId);

        if (resultado == null)
        {
            return NotFound("EL USUSARIO NO EXISTE");
        }

        return Ok(resultado);

    }

    [HttpDelete("{userId}")]
    public ActionResult DeleteUser(int userId)
    {
        var resultado = _userService.DeleteUser(userId);

        if (!resultado)
        {
            return NotFound("EL USUSARIO YA FUE ELIMINADO");
        }

        return Ok("USUARIO ELIMINADO");
        
    }

    [HttpPut("{userId}")]
    public ActionResult UpdateUser(int userId, [FromBody] UpdateUserDto dto)
    {
        var resultado = _userService.UpdateUser(userId, dto);

        if (!resultado)
        {
            return NotFound("USUARIO NO ENCONTRADO");
        }
        
        return Ok(resultado);
    }
    


}