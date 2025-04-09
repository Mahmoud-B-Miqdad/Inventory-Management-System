using InventoryManagementSystem.Domain.General;
using InventoryManagementSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagementSystem.Domain.Services
{
    public class Inventory
    {
        private List<Product> _products = new List<Product>();


        public void PrintProduct(Product product)
        {
            Console.WriteLine($"\n********************************\nName: {product.Name}\nPrice: {product.Price:C}\nQuantity: {product.Quantity}" +
                    $"\n********************************");
        }

        public Product FindProductByName(string name)
        {
            return _products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void AddProduct(string name, Price price, int quantity)
        {
            _products.Add(new Product(name, price, quantity));
        }

        public List<Product> ViewProducts()
        {
            if (_products.Count == 0)
            {
                return null;
            }

            return _products;
        }

        public void EditProduct(string name, string newName, Price newPrice, int newQuantity)
        {
            var product = _products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (product == null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(newName)) product.Name = newName;
            product.Price = newPrice;
            product.Quantity = newQuantity;
        }

        public void DeleteProduct(string name)
        {
            var product = _products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (product != null)
            {
                _products.Remove(product);
            }
        }

        public Product SearchProduct(string name)
        {
            return _products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
