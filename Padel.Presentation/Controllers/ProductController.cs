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

    [HttpGet()]
    public ActionResult Get(int id)
    {
        var result = _productService.Get(id);
        return Ok(result);
    }

    [HttpGet ("Productos")]
    public IActionResult GetAll()
    {
        var products = _productService.GetAll();
        return Ok(products);
    }
}