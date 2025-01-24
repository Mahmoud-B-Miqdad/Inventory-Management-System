using InventoryManagementSystem.Domain.General;
using InventoryManagementSystem.Domain.Models;
using System;

namespace InventoryManagementSystem.Domain.Main
{
    internal class Utilities
    {
        private static Inventory inventory = new Inventory();

        private static void Pause()
        {
            Console.WriteLine("Press enter key to Back. \r\n");
            Console.ReadKey();
        }

        private static void AddNewProduct()
        {
            string name = GetProductNameFromUser();
            double price = GetProductPriceFromUser();
            Currency currency = GetCurrencyFromUser();
            int quantity = GetProductQuantityFromUser();

            if (name != null && price >= 0 && quantity >= 0)
            {
                inventory.AddProduct(name, new Price { ItemPrice = price, Currency = currency }, quantity);
                Console.WriteLine("Product added successfully!");
            }
            else
            {
                Console.WriteLine("Product addition canceled due to invalid inputs.");
            }
        }

        private static void ViewProducts()
        {
            inventory.ViewProducts();
        }

        private static void EditProduct()
        {
            string name = GetProductNameToEditFromUser();
            if (name == null) return;

            var product = inventory.FindProductByName(name);
            if (product == null)
            {
                Console.WriteLine("Product not found! Please check the product name.");
                return;
            }

            string newName = GetNewProductNameFromUser() ?? product.Name;
            
            double newPrice = GetNewProductPriceFromUser();
            if (newPrice < 0)
                newPrice = product.Price.ItemPrice;

            Currency newCurrency = GetNewCurrencyFromUser();

            int newQuantity = GetNewProductQuantityFromUser();
            if (newQuantity < 0)
                newQuantity = product.Quantity;

            inventory.EditProduct(name, newName, new Price { ItemPrice = newPrice, Currency = newCurrency }, newQuantity);
            Console.WriteLine("Product updated successfully!");
        }

        private static void DeleteProduct()
        {
            string name = GetProductNameToDeleteFromUser();
            if (name == null) return;

            var product = inventory.FindProductByName(name);
            if (product == null)
            {
                Console.WriteLine("Product not found! Please check the product name.");
                return;
            }

            inventory.DeleteProduct(name);
            Console.WriteLine("Product deleted successfully!");
        }

        private static void SearchProduct()
        {
            string name = GetProductNameToSearchFromUser();
            if (name == null) return;

            var product = inventory.FindProductByName(name);
            if (product != null)
            {
                inventory.PrintProduct(product);
            }
            else
            {
                Console.WriteLine("Product not found.");
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
                        Pause();
                        break;

                    case "2":
                        ViewProducts();
                        Pause();
                        break;

                    case "3":
                        EditProduct();
                        Pause();
                        break;

                    case "4":
                        DeleteProduct();
                        Pause();
                        break;

                    case "5":
                        SearchProduct();
                        Pause();
                        break;

                    case "6":
                        Console.WriteLine("Exiting the program. Goodbye!");
                        Pause();
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Pause();
                        break;
                }
            }
        }

        private static string GetProductNameFromUser()
        {
            Console.Write("Enter product name: ");
            return Console.ReadLine();
        }

        private static double GetProductPriceFromUser()
        {
            double price = -1;
            Console.Write("Enter product price: ");
            if (double.TryParse(Console.ReadLine(), out price) && price >= 0)
            {
                return price;
            }
            return -1;
        }

        private static Currency GetCurrencyFromUser()
        {
            Currency currency = Currency.Dollar;
            while (true)
            {
                Console.Write("Enter currency (Dollar, Euro, Pound): ");
                if (Enum.TryParse(Console.ReadLine(), true, out currency))
                {
                    return currency;
                }
                else
                {
                    Console.WriteLine("Invalid currency. Please enter one of the following: Dollar, Euro, Pound.");
                }
            }
        }

        private static int GetProductQuantityFromUser()
        {
            int quantity = -1;
            Console.Write("Enter product quantity: ");
            if (int.TryParse(Console.ReadLine(), out quantity) && quantity >= 0)
            {
                return quantity;
            }
            return -1;
        }

        private static string GetProductNameToEditFromUser()
        {
            Console.Write("Enter the name of the product to edit: ");
            return Console.ReadLine();
        }

        private static string GetNewProductNameFromUser()
        {
            Console.Write("Enter new name (or press Enter to keep the current name): ");
            return Console.ReadLine();
        }

        private static double GetNewProductPriceFromUser()
        {
            double newPrice = -1;
            Console.Write("Enter new price value (or press Enter to keep the current price): ");
            string priceInput = Console.ReadLine();
            if (double.TryParse(priceInput, out newPrice) && newPrice >= 0)
            {
                return newPrice;
            }
            return -1;
        }

        private static Currency GetNewCurrencyFromUser()
        {
            Currency newCurrency = Currency.Dollar;
            while (true)
            {
                Console.Write("Enter currency (Dollar, Euro, Pound): ");
                if (Enum.TryParse(Console.ReadLine(), true, out newCurrency))
                {
                    return newCurrency;
                }
                else
                {
                    Console.WriteLine("Invalid currency. Please enter one of the following: Dollar, Euro, Pound.");
                }
            }
        }

        private static int GetNewProductQuantityFromUser()
        {
            int newQuantity = -1;
            Console.Write("Enter new quantity (or press Enter to keep the current quantity): ");
            string quantityInput = Console.ReadLine();
            if (int.TryParse(quantityInput, out newQuantity) && newQuantity >= 0)
            {
                return newQuantity;
            }
            return -1;
        }

        private static string GetProductNameToDeleteFromUser()
        {
            Console.Write("Enter the name of the product to delete: ");
            return Console.ReadLine();
        }

        private static string GetProductNameToSearchFromUser()
        {
            Console.Write("Enter the name of the product to search: ");
            return Console.ReadLine();
        }
    }
}
