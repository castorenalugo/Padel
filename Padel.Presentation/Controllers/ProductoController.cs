using Microsoft.AspNetCore.Mvc;
using Padel.Application.DTOs.Productos;
using Padel.Application.Interfaces;
namespace Padel.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{
    private readonly IProductoService _productoService;

    public ProductoController(IProductoService service)
    {
        _productoService = service;
    }

    [HttpPost]
    public ActionResult CreateProducto([FromBody] CreateProductoDto dto)
    {
        var result = _productoService.CreateProducto(dto);
        return Ok(result);
    }

    [HttpGet("{productoId}")]
    public ActionResult GetProductoById(int productoId)
    {
        var result = _productoService.GetProductoById(productoId);
        return Ok(result);
    }

    [HttpGet ("Productos")]
    public IActionResult GetProductosActives()
    {
        var productos = _productoService.GetProductosActives();
        return Ok(productos);
    }
}