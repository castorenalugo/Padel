namespace Padel.Application.DTOs;
using System.ComponentModel.DataAnnotations;

public class UpdateUserDto
{
    [MaxLength(50)]
    public required string Email { get; set; }

    [MaxLength(50)]
    public required string FirstName { get; set; }

    [MaxLength(50)]
    public required string LastName { get; set; }
}