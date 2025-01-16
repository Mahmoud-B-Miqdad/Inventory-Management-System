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
            Console.WriteLine("Added successfully.\r\nPress enter key to Back.");
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
            Console.WriteLine("Press enter key to Back. \r\n");
            Console.ReadKey();
        }

        public void EditProduct(string name)
        {
            var product = products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (product == null)
            {
                Console.WriteLine("Product not found!");
                Console.WriteLine("Press enter key to Back. \r\n");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter new name (or press Enter to keep the current name): ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newName)) product.Name = newName;

            Console.Write("Enter new price value (or press Enter to keep the current price): ");
            string priceInput = Console.ReadLine();
            if (double.TryParse(priceInput, out double newPrice))
            {
                while (true)
                {
                    Console.Write("Enter currency (Dollar, Euro, Pound): ");
                    if (Enum.TryParse(Console.ReadLine(), true, out Currency currency))
                    {
                        product.Price = new Price { ItemPrice = newPrice, Currency = currency };
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid currency. Please enter one of the following: Dollar, Euro, Pound.");
                    }
                }
            }

            Console.Write("Enter new quantity (or press Enter to keep the current quantity): ");
            string quantityInput = Console.ReadLine();
            if (int.TryParse(quantityInput, out int newQuantity)) product.Quantity = newQuantity;

            Console.WriteLine("Product updated successfully!\r\n");
            Console.WriteLine("Press enter key to Back. \r\n");
            Console.ReadKey();
        }


        public void DeleteProduct(string name)
        {
            var product = products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (product == null)
            {
                Console.WriteLine("Product not found!");
                Console.WriteLine("Press enter key to Back. \r\n");
                Console.ReadKey();
                return;
            }

            products.Remove(product);
            Console.WriteLine("Product deleted successfully!");
            Console.WriteLine("Press enter key to Back. \r\n");
            Console.ReadKey();
        }
    }
}
