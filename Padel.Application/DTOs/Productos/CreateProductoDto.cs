using System.ComponentModel.DataAnnotations;

namespace Padel.Application.DTOs.Productos;

public class CreateProductoDto
{
    [MaxLength(50)]
    public required string Nombre { get; set; }
    public required double Precio { get; set; }
}