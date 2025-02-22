using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Padel.Domain.Entities;

[Table("User")]
public class User
{
    [Key]
    public int Id { get; set; }

    [MaxLength(50)]
    public required string Email { get; set; }

    [MaxLength(55)]
    public required string FirstName { get; set; }

    [MaxLength(50)]
    public required string LastName { get; set; }

    [MaxLength(50)]
    public required string Password { get; set; }

    public bool IsActive { get; set; }
    
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
}