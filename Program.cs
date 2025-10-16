using abi_market.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace abi_market
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<MarketContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("MarketContext"))
                );
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "AbiMarket API", Version = "v1" });
            });

            var app = builder.Build();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.Run();
        }
    }
}
