using CatalogService.Application.Dtos;
using CatalogService.Application.Interfaces;
using CatalogService.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        // Use case: Get published products
        public async Task<IReadOnlyList<ProductDto>> GetPublishedAsync()
        {
            var products = await _repo.GetPublishedAsync();

            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                ImageUrl = p.ImageUrl
            }).ToList();
        }

        // Use case: Get product by id
        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var p = await _repo.GetByIdAsync(id);
            if (p == null) return null;

            return new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                ImageUrl = p.ImageUrl
            };
        }

        // Use case: Create product
        public async Task<int> CreateAsync(CreateProductDto dto)
        {
            var product = new Product(dto.Name, dto.Price, dto.ImageUrl);

            await _repo.AddAsync(product);
            await _repo.SaveChangesAsync();

            return product.Id;
        }

        // Use case: Publish product
        public async Task PublishAsync(int productId)
        {
            var product = await _repo.GetByIdAsync(productId)
                ?? throw new InvalidOperationException("Product not found");

            product.Publish(); // DOMAIN BEHAVIOR

            await _repo.SaveChangesAsync();
        }
    }
}
