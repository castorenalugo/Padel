using Padel.Domain.Entities;
namespace Padel.Domain.Interfaces;

public interface IProductoRepository
{
    Producto Create(Producto producto);
    Producto? GetById(int id);
    Producto[] GetAll();
}