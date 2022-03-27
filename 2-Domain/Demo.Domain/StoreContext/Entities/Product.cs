using Demo.Shared.Entities;
using System;

namespace Demo.Domain.StoreContext.Entities
{
    public class Product : Entity
    {
        private Product() { }
        public Product(string name, int quantity, string description, decimal price)
            : this()
        {
            Id = Guid.NewGuid();
            CreateAt = DateTime.Now;
            Name = name;
            Quantity = quantity;
            Description = description;
            Price = price;
        }
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
    }
}
