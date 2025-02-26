using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Padel.Domain.Entities;

[Table("Producto")]
public class Producto
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(50)]
    public required string Nombre { get; set; }
    
    public required double Precio { get; set; }
    
    public bool IsActive { get; set; }
    
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
}