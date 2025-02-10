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
            LastName = user.LastName,
        };
        
        return response;
    }
}