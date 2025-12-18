using CatalogService.Domain.Common;
using System;

namespace CatalogService.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; } = null!;
        public decimal Price { get; private set; }
        public bool Published { get; private set; }
        public string? ImageUrl { get; private set; }

        // EF Core requirement
        protected Product() { }

        public Product(string name, decimal price, string? imageUrl = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required");

            if (price <= 0)
                throw new ArgumentException("Price must be greater than zero");

            Name = name;
            Price = price;
            ImageUrl = imageUrl;
            Published = false;
        }

        // ---- Domain behavior ----

        public void Publish()
        {
            if (Published)
                throw new InvalidOperationException("Product already published");

            Published = true;
        }

        public void ChangePrice(decimal newPrice)
        {
            if (newPrice <= 0)
                throw new ArgumentException("Invalid price");

            Price = newPrice;
        }

        public void ChangeName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Name is required");

            Name = newName;
        }
    }
}
