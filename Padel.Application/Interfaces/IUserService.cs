﻿using Padel.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Padel.Application.Interfaces;

public interface IUserService
{
    CreateUserResponse CreateUser(CreateUserDto dto);
}
