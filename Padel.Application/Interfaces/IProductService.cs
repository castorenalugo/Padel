using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Padel.Application.DTOs.Productos;
using Padel.Domain.Entities;

namespace Padel.Application.Interfaces;

public interface IProductService
{
    ProductResponse CreateProduct (CreateProductDto dto);
    ProductResponse GetProductById (int productId);
    Product[] GetProductsActives();
}