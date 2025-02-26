using System.ComponentModel.DataAnnotations;
namespace Padel.Application.DTOs.Productos;

public class CreateProductoResponse
{
    public int Id { get; set; }
    
    public required string Nombre { get; set; }
    
    public required double Precio { get; set; }
}