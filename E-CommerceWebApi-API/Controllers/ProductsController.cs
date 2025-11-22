using E_CommerceWebApi_Core.Entities;
using E_CommerceWebApi_Core.Repositories;
using E_CommerceWebApi_Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceWebApi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductRepository productRepo) : ControllerBase
    {
       
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts(string? brand, string? type, string? sort)
        {
          var products = await productRepo.GetProductsAsync(brand, type,sort);
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await productRepo.GetProductByIdAsync(id);
            if(product == null) return NotFound();

            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct (Product product)
        {
            productRepo.AddProduct(product);
            if(await productRepo.SaveChangesAsync())
            {
                return CreatedAtAction("GetProduct", new { id = product.Id }, product);
            }
            return BadRequest("Problem Occured While Creating Product");
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id , Product product)
        {
          if  (product.Id != id || !ProductExists(id))
                return BadRequest("Cannot Update This Product");

         productRepo.UpdateProduct(product);
            if(await productRepo.SaveChangesAsync())
            {
                return NoContent();
            }

            return BadRequest("Cannot Update This Product");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await productRepo.GetProductByIdAsync (id);
            if(product == null) return NotFound();
             productRepo.DeleteProduct(product);
            if (await productRepo.SaveChangesAsync())
                return NoContent();
            return BadRequest("Cannot Delete This Product");
        }
        [HttpGet("Brands")]
        public async Task <ActionResult<IReadOnlyList<string>>> GetBrands()
        {
            var brands = await productRepo.GetBrandsAsync();
            return Ok(brands);
        }
        [HttpGet("Types")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetTypes()
        {
            var brands = await productRepo.GetTypesAsync();
            return Ok(brands);
        }
        private bool ProductExists(int id)
        {
            return productRepo.ProductExists(id);
        }
    }
}
