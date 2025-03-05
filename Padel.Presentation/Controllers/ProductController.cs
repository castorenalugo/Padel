using Microsoft.AspNetCore.Mvc;
using Padel.Application.DTOs.Productos;
using Padel.Application.Interfaces;
namespace Padel.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService service)
    {
        _productService = service;
    }

    [HttpPost]
    public ActionResult CreateProduct([FromBody] CreateProductDto dto)
    {
        var result = _productService.CreateProduct(dto);
        return Ok(result);
    }

    [HttpGet("{productId}")]
    public ActionResult GetProductoById(int productId)
    {
        var result = _productService.GetProductById(productId);
        return Ok(result);
    }

    [HttpGet ("Productos")]
    public IActionResult GetProductosActives()
    {
        var products = _productService.GetProductsActives();
        return Ok(products);
    }
}