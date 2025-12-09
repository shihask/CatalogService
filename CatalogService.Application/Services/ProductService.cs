using CatalogService.Application.Dtos;
using CatalogService.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMonolithCatalogAdapter _adapter;

        public ProductService(IMonolithCatalogAdapter adapter)
        {
            _adapter = adapter;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            return await _adapter.GetAllProductsAsync();
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            return await _adapter.GetProductByIdAsync(id);
        }
    }


}
