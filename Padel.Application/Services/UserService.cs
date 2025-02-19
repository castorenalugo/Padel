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

    public CreateUserResponse CreateUser(CreateUserDto dto)
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
            IsActive = true
        };
        
        var user = _userRepository.Create(newUser);

        var response = new CreateUserResponse()
        {
            Id = user.Id,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName
        };
        
        return response;
    }

    public GetUserResponse GetUserById(int userId)
    {
        //Este es para consukltar el repositorio por id
        var user = _userRepository.GetById(userId);
        
        //Aqui en caso de que no existe que me retorne un null
        if (user == null || user.IsActive == false)
        {
            return null;
        }
        
        //Aqui coinstruyo el cuerpo del JSOn del metodo get como respuesta
        var response = new GetUserResponse()
        {
            Id = user.Id,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            FechaCreacion = user.CreatedAt

        };
        return response;


    }

    public bool DeleteUser(int userId)
    {
        //Primero consultamos a la BD por id
        var user = _userRepository.GetById(userId);
        
        //Aqui verifico si el usuario ya esta inactivo
        if (user == null || user.IsActive == false)
        {
            return false;
        }
        
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
        
        //AQUI ACTUALIZAMOS LOS CAMPOS
        user.Email = dto.Email;
        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        
        //DESPUES GUARDO LOS CAMBIOS EN EL REPOSITORIO
        _userRepository.Update(user);
        
        return true;
        
    }
    
}