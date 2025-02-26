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
            Precio = producto.Precio
        };
        return response;
    }

    public GetProductoResponse GetProductoById(int productoId)
    {
        var producto = _productoRepository.GetById(productoId);
        if (producto == null)
        {
            return null;
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

    public List<GetProductoResponse> GetProductosActives()
    {
        //AQUI SE CONSULTA TODOS LOS USUARIOS EN EL REPOSITORIO
        var productos = _productoRepository.GetAll().Where(u => u.IsActive).ToList();
        //DONDE DESPUES AQUI SE MAPEA LA LISTA DE LOS USUARIOS ACTIVOS
        var response = productos.Select(producto => new GetProductoResponse()
        {
            Id = producto.Id,
            Nombre = producto.Nombre,
            Precio = producto.Precio,
            FechaCreacion = producto.FechaCreacion
        }).ToList();
        return response;
    }
}