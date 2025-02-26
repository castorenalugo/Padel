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

public class ProductoService: IProductoService
{
    private readonly IProductoRepository _productoRepository;

    public ProductoService(IProductoRepository productoRepository)
    {
        _productoRepository = productoRepository;
    }

    public CreateProductoResponse CreateProducto(CreateProductoDto dto)
    {
        var newProducto = new Producto()
        {
            Nombre = dto.Nombre,
            Precio = dto.Precio,
            IsActive = true,
            FechaCreacion = DateTime.Now
        };
        
        var producto = _productoRepository.Create(newProducto);

        var response = new CreateProductoResponse()
        {
            Id = producto.Id,
            Nombre = producto.Nombre,
            Precio = producto.Precio,
            FechaCreacion = producto.FechaCreacion
        };
        return response;
    }

    public GetProductoResponse GetProductoById(int productoId)
    {
        var producto = _productoRepository.GetById(productoId);
        if (producto == null)
        {
            throw new Exception("PRODUCTO NO EXISTE");
        }
        var response = new GetProductoResponse()
        {
            Id = producto.Id,
            Nombre = producto.Nombre,
            Precio = producto.Precio,
            FechaCreacion = producto.FechaCreacion
        };
        return response;
    }

    public Producto[] GetProductosActives()
    {
        var productos = _productoRepository.GetAll().Where(u => u.IsActive).ToArray();
        return productos;
    }
}