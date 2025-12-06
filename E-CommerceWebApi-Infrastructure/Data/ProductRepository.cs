using E_CommerceWebApi_Core.Entities;
using E_CommerceWebApi_Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceWebApi_Infrastructure.Data
{
    public class ProductRepository(StoreContext context) : IProductRepository
    {
        public void AddProduct(Product product)
        {
            context.Products.Add(product);
        }
        public void DeleteProduct(Product product)
        {
            context.Products.Remove(product);
        }

        public async Task<IReadOnlyList<string>> GetBrandsAsync()
        {
            return await context.Products.AsNoTracking().Select(x => x.Brand).Distinct().ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<Product?>> GetProducts(string? brand, string? type, string? sort)
        {
            var query = context.Products.AsQueryable().AsNoTracking();
            if (!string.IsNullOrWhiteSpace(brand))
                query = query.Where(x => x.Brand.ToLower() == brand.ToLower());
            if (!string.IsNullOrWhiteSpace(type))
                query = query.Where(x => x.Type.ToLower() == type.ToLower());

            query = (sort?.ToLower()) switch
            {
                "priceasc" => query.OrderBy(x => x.Price),
                "pricedesc" => query.OrderByDescending(x => x.Price),
                _ => query.OrderBy(x => x.Name ?? ""),
            };

            return await query.ToListAsync();


        }

        public async Task<IReadOnlyList<string>> GetTypesAsync()
        {
            return await context.Products.AsNoTracking().Select(x => x.Type).Distinct().ToListAsync();
        }



        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void UpdateProduct(Product product)
        {
            context.Products.Update(product);
        }
        public Task<bool> ProductExists(int id)
        {
            return context.Products.AnyAsync(x => x.Id == id);
        }
    }
}
