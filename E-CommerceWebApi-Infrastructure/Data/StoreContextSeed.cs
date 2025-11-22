using E_CommerceWebApi_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_CommerceWebApi_Infrastructure.Data
{
    public class StoreContextSeed 
    {
        public static async Task SeedAsync (StoreContext context)
        {
            if(! context.Products.Any())
            {
                var productsData = await File.ReadAllTextAsync("..\\E-CommerceWebApi-Infrastructure\\Data\\SeedData\\products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                if (products == null) return;
                context.Products.AddRange(products);
                await context.SaveChangesAsync();
            }
        }
    }
}
