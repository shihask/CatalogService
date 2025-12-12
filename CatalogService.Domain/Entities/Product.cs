using CatalogService.Domain.Common;
using System;

namespace CatalogService.Domain.Entities
{
    public class Product : BaseEntity
    {
        // EF-friendly public setters and default ctor        
        public string Name { get; set; } = null!;
        public string? ShortDescription { get; set; }
        public decimal Price { get; set; }
        public bool Published { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
        public string? ImageUrl { get; set; }

        // Parameterless ctor required by EF (or used for easy creation)
        public Product() { }

        // Optional convenience ctor for your code usage
        public Product(int id, string name, decimal price, string? imageUrl = null)
        {
            Id = id;
            Name = name;
            Price = price;
            ImageUrl = imageUrl;
            Published = true;
            CreatedOnUtc = DateTime.UtcNow;
            UpdatedOnUtc = DateTime.UtcNow;
        }
    }
}
