using CatalogService.Application.Interfaces;
using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogDbContext _db;

        public ProductRepository(CatalogDbContext db)
        {
            _db = db;
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _db.Set<Product>()
                            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetPublishedAsync()
        {
            return await _db.Set<Product>()
                            .Where(p => p.Published)
                            .AsNoTracking()
                            .ToListAsync();
        }

        public async Task AddAsync(Product product)
        {
            await _db.Set<Product>().AddAsync(product);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
