using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Padel.Application.DTOs.Productos;

namespace Padel.Application.Interfaces;

public interface IProductoService
{
    CreateProductoResponse CreateProducto (CreateProductoDto dto);
    GetProductoResponse GetProductoById (int productoId);
    List<GetProductoResponse> GetProductosActives();
}