using DemoCRUD.Application.ProductDTOs;
using DemoCRUD.Application.UseCaseInterface;
using Microsoft.AspNetCore.Mvc;

namespace DemoCRUD.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(IProductService _productService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productService.GetAllProductsAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product is null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] CreateProductDto productDto)
    {
        await _productService.AddProductAsync(productDto);
        return CreatedAtAction(nameof(GetById), new { id = productDto.Name }, productDto);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDto productDto)
    {
        if (id != productDto.Id)
        {
            return BadRequest();
        }

        await _productService.UpdateProduct(productDto);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await _productService.DeleteProductAsync(id);
        return NoContent();
    }
    
}