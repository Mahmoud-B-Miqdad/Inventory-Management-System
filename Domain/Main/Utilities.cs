using InventoryManagementSystem.Domain.General;
using InventoryManagementSystem.Domain.Inventory_Class;
using InventoryManagementSystem.Domain.Product_Class;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace InventoryManagementSystem.Domain.Main
{
    internal class Utilities
    {
        private static List<Product> ProductInventory = new();
        private static Inventory inventory = new Inventory();

        private static void AddNewProduct()
        {
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();
            Console.Write("Enter product price: ");
            double itemPrice = double.Parse(Console.ReadLine());
            Console.Write("Enter currency (Dollar, Euro, Pound): ");
            Currency currency = (Currency)Enum.Parse(typeof(Currency), Console.ReadLine(), true);
            Console.Write("Enter product quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            inventory.AddProduct(name, new Price { ItemPrice = itemPrice, Currency = currency }, quantity);
        }
        internal static void InitializeStock()
        {
            Product p1 = new Product("Sugar", new Price() { ItemPrice = 10, Currency = Currency.Euro }, 100);
            Product p2 = new Product("Cake decorations", new Price() { ItemPrice = 8, Currency = Currency.Euro }, 20);
            Product p3 = new Product("Strawberry", new Price() { ItemPrice = 3, Currency = Currency.Euro }, 10);
            ProductInventory.Add(p1);
            ProductInventory.Add(p2);
            ProductInventory.Add(p3);
        }

        internal static void ShowMainMenu()
        {


            while (true)
            {
                Console.ResetColor();
                Console.Clear();
                Console.WriteLine("\n--- Inventory Management System ---");
                Console.WriteLine("********************");
                Console.WriteLine("* Select an action *");
                Console.WriteLine("********************");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View Products");
                Console.WriteLine("3. Edit Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Search Product");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddNewProduct();
                        Console.WriteLine("Added successfully.\r\nPress enter key to Back.");
                        Console.ReadKey();
                        break;

                    case "2":
                        break;

                    case "3":
                        break;

                    case "4":
                        break;

                    case "5":
                        break;

                    case "6":
                        Console.WriteLine("Exiting the program. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
