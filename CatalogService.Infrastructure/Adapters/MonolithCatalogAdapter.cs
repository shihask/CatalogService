using CatalogService.Application.Dtos;
using CatalogService.Application.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Infrastructure.Adapters
{
    public class MonolithCatalogAdapter : IMonolithCatalogAdapter
    {
        private readonly HttpClient _client;

        public MonolithCatalogAdapter(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var response = await _client.GetAsync("/Product/List");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(json)!;
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var response = await _client.GetAsync($"/Product/Details/{id}");
            if (!response.IsSuccessStatusCode) return null;

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ProductDto>(json);
        }
    }


}
