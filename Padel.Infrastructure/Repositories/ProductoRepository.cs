using Padel.Domain.Entities;
using Padel.Domain.Interfaces;
using Padel.Infrastructure.Database;
namespace Padel.Infrastructure.Repositories;

public class ProductoRepository : IProductoRepository
{
    private readonly PadelContext _context;

    public ProductoRepository(PadelContext context)
    {
        _context = context;
    }

    public Producto Create(Producto producto)
    {
        _context.Productos.Add(producto);
        _context.SaveChanges();
        return producto;
    }

    public Producto? GetById(int productoId)
    {
        return _context.Productos.FirstOrDefault(p => p.Id == productoId);
    }

    public Producto[] GetAll()
    {
        return _context.Productos.ToArray();
    }
}