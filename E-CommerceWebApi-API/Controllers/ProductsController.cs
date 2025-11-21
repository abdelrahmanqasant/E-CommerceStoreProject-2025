using E_CommerceWebApi_Core.Entities;
using E_CommerceWebApi_Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceWebApi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _dbcontext;

        public ProductsController(StoreContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _dbcontext.Products.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _dbcontext.Products.FindAsync(id);
            if(product == null) return NotFound();

            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct (Product product)
        {
            await _dbcontext.Products.AddAsync(product);
            await _dbcontext.SaveChangesAsync();
            return product;
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id , Product product)
        {
          if  (product.Id != id || !ProductExists(id))
                return BadRequest("Cannot Update This Product");

          _dbcontext.Entry(product).State = EntityState.Modified;

            await _dbcontext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _dbcontext.Products.FindAsync(id);
            if(product == null) return NotFound();
             _dbcontext.Remove(product);
            await _dbcontext.SaveChangesAsync();
            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _dbcontext.Products.Any(p => p.Id == id);
        }
    }
}
