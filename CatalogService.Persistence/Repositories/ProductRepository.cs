using CatalogService.Domain.Entities;
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
        public ProductRepository(CatalogDbContext db) => _db = db;

        public async Task AddAsync(Product product)
        {
            await _db.Products.AddAsync(product);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _db.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _db.Products.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
