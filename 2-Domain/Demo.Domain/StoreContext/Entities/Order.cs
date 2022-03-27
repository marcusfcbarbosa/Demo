using Demo.Shared.Entities;
using System;

namespace Demo.Domain.StoreContext.Entities
{
    public class Order : Entity
    {
        public Order(User user, Product product,
            int quantity, string deliveryAddress)
        {
            ///Fazer uma validação anterior

            Id = Guid.NewGuid();
            CreateAt = DateTime.Now;
            User = user;

            //Na hora de criar o pedido validar se existe a quantidade desse produto 
            //cadastrada
            Product = product;
            Quantity = quantity;

            DeliveryAddress = deliveryAddress;
        }

        public User User { get; private set; }
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public string DeliveryAddress { get; private set; }

        public decimal CalculatePrice()
        {
            return Product.Price * Quantity;
        }

    }
}
