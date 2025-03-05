using Padel.Domain.Entities;
using Padel.Domain.Interfaces;
using Padel.Infrastructure.Database;
namespace Padel.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly PadelContext _context;

    public ProductRepository(PadelContext context)
    {
        _context = context;
    }

    public Product Create(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
        return product;
    }

    public Product? GetById(int productId)
    {
        return _context.Products.FirstOrDefault(p => p.Id == productId);
    }

    public Product[] GetAll()
    {
        return _context.Products.ToArray();
    }
}