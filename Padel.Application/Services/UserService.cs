using Padel.Application.DTOs;
using Padel.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Padel.Domain.Entities;
using Padel.Domain.Interfaces;
namespace Padel.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public UserResponse CreateUser(CreateUserDto dto)
    {
        var existingUser = _userRepository.GetByEmail(dto.Email);
        
        if(existingUser != null)
            throw new Exception($"User with email {dto.Email} already exists");

        var newUser = new User()
        {
            Email = dto.Email,
            Password = dto.Password,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            IsActive = true,
            FechaCreacion = DateTime.Now
        };
        
        var user = _userRepository.Create(newUser);

        var response = new UserResponse()
        {
            Id = user.Id,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
        };
        
        return response;
    }
    
    public UserResponse GetUserById(int userId)
    {
        // Aqui se Consulta al repositorio por ID
        var user = _userRepository.GetById(userId);
        //Si no existe o el IsActive es null retorna el false
        if (user == null || user.IsActive == false)
        {
            return null;
        }
        
        var response = new UserResponse()
        {
            Id = user.Id,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            FechaCreacion = user.FechaCreacion
        };
        return response;
    }

    public bool DeleteUser(int userId)
    {
        var user = _userRepository.GetById(userId);
        if (user == null || user.IsActive == false)
        {
            return false;
        }
        
        //AQUI ACUTALIZO EL ESTADO A FALSE
        user.IsActive = false;
        _userRepository.Update(user);
        return true;
    }
    
    public bool UpdateUser(int userId, UpdateUserDto dto)
    {
        var user = _userRepository.GetById(userId);
        if (user == null || user.IsActive == false)
        {
            return false;
        }

        //AQUI ACTUALIZO LOS CAMPOS
        user.Email = dto.Email;
        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        //GUARDO CAMBIOS EN EL REPOSITORIO
        _userRepository.Update(user);
        return true;
    }
}