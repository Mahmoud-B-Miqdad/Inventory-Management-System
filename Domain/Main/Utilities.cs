using InventoryManagementSystem.Domain.General;
using InventoryManagementSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace InventoryManagementSystem.Domain.Main
{
    internal class Utilities
    {
        private static Inventory inventory = new Inventory();

        private static void AddNewProduct()
        {
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();
            Console.Write("Enter product price: ");
            if (!double.TryParse(Console.ReadLine(), out double itemPrice))
            {
                Console.WriteLine("Invalid price. Product addition canceled.");
                return;
            }

            while (true)
            {
                Console.Write("Enter currency (Dollar, Euro, Pound): ");
                if (Enum.TryParse(Console.ReadLine(), true, out Currency currency))
                {
                    Console.Write("Enter product quantity: ");
                    if (!int.TryParse(Console.ReadLine(), out int quantity))
                    {
                        Console.WriteLine("Invalid quantity. Product addition canceled.");
                        return;
                    }
                    inventory.AddProduct(name, new Price { ItemPrice = itemPrice, Currency = currency }, quantity);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid currency. Please enter one of the following: Dollar, Euro, Pound.");
                }
            }
        }
        internal static void InitializeStock()
        {
            inventory.AddProduct("Sugar", new Price() { ItemPrice = 10, Currency = Currency.Euro }, 100);
            inventory.AddProduct("Cake decorations", new Price() { ItemPrice = 8, Currency = Currency.Euro }, 20);
            inventory.AddProduct("Strawberry", new Price() { ItemPrice = 3, Currency = Currency.Euro }, 10);
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
                        Console.ReadKey();
                        break;

                    case "2":
                        inventory.ViewProducts();
                        break;

                    case "3":
                        Console.Write("Enter the name of the product to edit: ");
                        string editName = Console.ReadLine();
                        inventory.EditProduct(editName);
                        break;

                    case "4":
                        Console.Write("Enter the name of the product to delete: ");
                        string deleteName = Console.ReadLine();
                        inventory.DeleteProduct(deleteName);
                        break;

                    case "5":
                        Console.Write("Enter the name of the product to search: ");
                        string searchName = Console.ReadLine();
                        inventory.SearchProduct(searchName);
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
