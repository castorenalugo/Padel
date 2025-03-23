using Padel.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Padel.Application.Interfaces;

public interface IUserService
{
    UserResponse CreateUser(CreateUserDto dto);
    UserResponse GetUserById(int userId);
    bool DeleteUser(int userId);
    bool UpdateUser(int userId, UpdateUserDto dto);
}
