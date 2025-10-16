using abi_market.Models;
using Microsoft.EntityFrameworkCore;

namespace abi_market
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<MarketContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("MarketContext"))
                );

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
