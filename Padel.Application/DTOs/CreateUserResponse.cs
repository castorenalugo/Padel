using System.ComponentModel.DataAnnotations;

namespace Padel.Application.DTOs;

public class CreateUserResponse
{
    public int Id { get; set; }

    public required string Email { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }
}
