﻿namespace Padel.Application.DTOs;

public record UserResponse
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime FechaCreacion { get; set; }
}