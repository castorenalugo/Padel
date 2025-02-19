using System.ComponentModel.DataAnnotations;

namespace Padel.Application.DTOs;

public class UpdateUserDto
{
    [MaxLength(50)]
    public required string Email { get; set; }

    [MaxLength(50)]
    public required string FirstName { get; set; }

    [MaxLength(50)]
    public required string LastName { get; set; }
    
    
}