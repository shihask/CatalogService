using CatalogService.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CatalogService.Application.Interfaces
{
    public interface IProductService
    {
        Task<IReadOnlyList<ProductDto>> GetPublishedAsync();
        Task<ProductDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateProductDto dto);
        Task PublishAsync(int productId);
    }
}
