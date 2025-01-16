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

        public void ViewProducts()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("No products in the inventory.");
                return;
            }

            Console.WriteLine("\nList of Products:\n********************************");
            foreach (var product in products)
            {
                Console.WriteLine($"Name: {product.Name}\nPrice: {product.Price:C}\nQuantity: {product.Quantity}" +
                    $"\n********************************");
            }
        }
    }
}
