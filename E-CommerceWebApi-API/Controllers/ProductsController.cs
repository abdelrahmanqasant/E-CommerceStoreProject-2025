using E_CommerceWebApi_Core.Entities;
using E_CommerceWebApi_Core.Repositories;
using E_CommerceWebApi_Core.Specifications;
using E_CommerceWebApi_Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceWebApi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IGenericRepository<Product> repo) : BaseApiController
    {
       
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts([FromQuery] ProductSpecParams specParams)
        {
            var specs = new ProductSpecification(specParams);

            return await CreatePagedResult(repo , specs , specParams.PageIndex , specParams.PageSize );
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await repo.GetByIdAsync(id);
            if(product == null) return NotFound();

            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct (Product product)
        {
            repo.Add(product);
            if(await repo.SaveAllAsync())
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

         repo.Update(product);
            if(await repo.SaveAllAsync())
            {
                return NoContent();
            }

            return BadRequest("Cannot Update This Product");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await repo.GetByIdAsync (id);
            if(product == null) return NotFound();
             repo.Remove(product);
            if (await repo.SaveAllAsync())
                return NoContent();
            return BadRequest("Cannot Delete This Product");
        }
        [HttpGet("Brands")]
        public async Task <ActionResult<IReadOnlyList<string>>> GetBrands()
        {
            var spec = new BrandListSpecification();
            var brands = await repo.ListAsync(spec);
            return Ok(brands);
        }
        [HttpGet("Types")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetTypes()
        {
            var spec = new TypeListSpecification();
            var types = await repo.ListAsync(spec);
            return Ok(types);
        }
        private bool ProductExists(int id)
        {
            return repo.Exists(id);
        }
    }
}
