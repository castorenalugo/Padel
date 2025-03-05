using Padel.Domain.Entities;
namespace Padel.Domain.Interfaces;

public interface IProductRepository
{
    Product Create(Product product);
    Product? GetById(int id);
    Product[] GetAll();
}