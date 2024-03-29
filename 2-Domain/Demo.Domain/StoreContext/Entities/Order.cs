﻿using Demo.Domain.StoreContext.Entities.Enums;
using Demo.Shared.Entities;
using System;

namespace Demo.Domain.StoreContext.Entities
{
    public class Order : Entity
    {
        private Order() { }
        public Order(User user, Product product, OrderStatus status, 
            int quantity, string deliveryAddress) :this()
        {
            Id = Guid.NewGuid();
            CreateAt = DateTime.Now;
            User = user;
            Product = product;
            this.status = status;
            Quantity = quantity;
            DeliveryAddress = deliveryAddress;
        }
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public Guid ProductId { get; private set; }
        public Product Product { get; private set; }
        public OrderStatus status { get; private set; }
        public int Quantity { get; private set; }
        public string DeliveryAddress { get; private set; }

        public decimal CalculatePrice()
        {
            return Product.Price * Quantity;
        }

    }
}
