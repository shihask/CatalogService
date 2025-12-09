using CatalogService.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CatalogService.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetByIdAsync(int id);
    }


}
