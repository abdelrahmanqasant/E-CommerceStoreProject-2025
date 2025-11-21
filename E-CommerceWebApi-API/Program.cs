
using E_CommerceWebApi_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceWebApi_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<StoreContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnectionString"));
            });

            var app = builder.Build();


            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
