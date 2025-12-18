
using CatalogService.Application.Interfaces;
using CatalogService.Application.Services;
using CatalogService.Infrastructure.Adapters;
using CatalogService.Persistence;
using CatalogService.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<CatalogDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("CatalogDatabase")));

            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            // Application + Infrastructure Dependencies
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddHttpClient<IMonolithCatalogAdapter, MonolithCatalogAdapter>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:59579"); // monolith URL
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
