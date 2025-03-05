using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Padel.Domain.Entities;

[Table("Product")]
public class Product
{
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public required string Name { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public required decimal Price { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime DateCreation { get; set; } = DateTime.Now;
}