using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ContosoPets.Api.Data;
using ContosoPets.Api.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ContosoPets.Api.Controllers
{
  // [ApiController] adds behaviors that make it easier to build web APIs.
  // Some behaviors include parameter source inference, attribute routing as a requirement, and 
  // model validation error handling enhancements.

  [ApiController]
  [Route("api/[controller]")]
  public class ProductsController : ControllerBase
  {
    private readonly ContosoPetsContext _context;

    public ProductsController(ContosoPetsContext context)
    {
      _context = context;
    }

    [HttpGet]
    public ActionResult<List<Product>> GetAll() =>
        _context.Products.ToList();

    // GET by ID action
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(long id)
    {
      var product = await _context.Products.FindAsync(id);

      if (product == null)
      {
        return NotFound();
      }

      return product;
    }

    // POST action
    [HttpPost]
    public async Task<ActionResult<Product>> Create(Product product)
    {
      _context.Products.Add(product);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    // PUT action
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, Product product)
    {
      if (id != product.Id)
      {
        return BadRequest();
      }

      _context.Entry(product).State = EntityState.Modified;
      await _context.SaveChangesAsync();

      return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
      var product = await _context.Products.FindAsync(id);

      if (product == null)
      {
        return NotFound();
      }

      _context.Products.Remove(product);
      await _context.SaveChangesAsync();

      return NoContent();
    }
  }
}