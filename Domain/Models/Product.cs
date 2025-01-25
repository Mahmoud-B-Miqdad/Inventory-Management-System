using InventoryManagementSystem.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagementSystem.Domain.Models
{
    public class Product
    {
        public string Name { get; set; }
        public Price Price { get; set; }
        public int Quantity { get; set; }

        public Product(string name, Price price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
}
