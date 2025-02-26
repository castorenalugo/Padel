namespace Padel.Application.DTOs.Productos;

public class GetProductoResponse
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public DateTime FechaCreacion { get; set; }
}