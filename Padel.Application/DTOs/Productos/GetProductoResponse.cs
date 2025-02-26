namespace Padel.Application.DTOs.Productos;

public class GetProductoResponse
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public DateTime FechaCreacion { get; set; }
}