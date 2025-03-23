using Padel.Application.DTOs;
using Padel.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Padel.Application.DTOs.Productos;
using Padel.Domain.Entities;
using Padel.Domain.Interfaces;
namespace Padel.Application.Services;

public class ProductService: IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public ProductResponse CreateProduct(CreateProductDto dto)
    {
        var newProduct = new Product()
        {
            Name = dto.Name,
            Price = dto.Price
        };
        
        var product = _productRepository.Create(newProduct);
        
        return new ProductResponse(
            product.Id,
            product.Name,
            product.Price,
            product.DateCreation
        );
    }

    public ProductResponse Get(int id)
    {
        var product = _productRepository.GetById(id);
        
        if (product == null)
            throw new Exception("PRODUCT DOES NOT EXIST");
        
        return new ProductResponse(
            product.Id,
            product.Name,
            product.Price,
            product.DateCreation
        );
    }

    public Product[] GetAll()
    {
        var products = _productRepository.GetAll().Where(u => u.IsActive == true).ToArray();
        return products;
    }
}