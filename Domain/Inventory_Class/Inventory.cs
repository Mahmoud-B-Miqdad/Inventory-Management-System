using InventoryManagementSystem.Domain.General;
using InventoryManagementSystem.Domain.Product_Class;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagementSystem.Domain.Inventory_Class
{
    public class Inventory
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(string name, Price price, int quantity)
        {
            products.Add(new Product(name, price, quantity));
            Console.WriteLine("Product added successfully!");
        }
    }
}
