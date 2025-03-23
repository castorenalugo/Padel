using System.ComponentModel.DataAnnotations;

namespace Padel.Application.DTOs;

public record CreateUserDto
{
    [MaxLength(50)]
    public required string Email { get; set; }
    [MaxLength(50)]
    public required string FirstName { get; set; }
    [MaxLength(50)]
    public required string LastName { get; set; }
    [MaxLength(50)]
    public required string Password { get; set; }
}
