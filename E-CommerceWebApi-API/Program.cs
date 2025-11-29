
using E_CommerceWebApi_Core.Repositories;
using E_CommerceWebApi_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace E_CommerceWebApi_API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<StoreContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnectionString"));
            });
            builder.Services.AddScoped<IProductRepository, ProductRepository>();    
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));    

            var app = builder.Build();


            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            //try
            //{
            //    using var scope = app.Services.CreateScope();
            //    var services = scope.ServiceProvider;
            //    var context = services.GetRequiredService<StoreContext>();
            //    await context.Database.MigrateAsync();
            //    await StoreContextSeed.SeedAsync(context);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //    throw;
            //}


            app.Run();
        }
    }
}
