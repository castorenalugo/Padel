using System.ComponentModel.DataAnnotations;
namespace Padel.Application.DTOs.Productos;

public class CreateProductoResponse
{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public required decimal Precio { get; set; }
    public DateTime FechaCreacion { get; set; }
}