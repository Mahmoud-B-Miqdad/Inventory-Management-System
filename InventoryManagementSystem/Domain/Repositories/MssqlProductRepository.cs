using Microsoft.Data.SqlClient;
using System.Configuration;
using InventoryManagementSystem.Domain.Models;
using InventoryManagementSystem.Domain.General;
using InventoryManagementSystem.Domain.Repositories;

namespace InventoryManagementSystem.DataAccess
{
    public class MssqlProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public MssqlProductRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["InventoryDBConnectionString"].ConnectionString;
        }

        public void AddProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Products (Name, ItemPrice, Currency, Quantity) 
                                 VALUES (@Name, @ItemPrice, @Currency, @Quantity)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@ItemPrice", product.Price.ItemPrice);
                    command.Parameters.AddWithValue("@Currency", (int)product.Price.Currency);
                    command.Parameters.AddWithValue("@Quantity", product.Quantity);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT Name, ItemPrice, Currency, Quantity FROM Products";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string name = reader["Name"].ToString();
                        double itemPrice = Convert.ToDouble(reader["ItemPrice"]);
                        Currency currency = (Currency)Convert.ToInt32(reader["Currency"]);
                        int quantity = Convert.ToInt32(reader["Quantity"]);

                        products.Add(new Product(name, new Price { ItemPrice = itemPrice, Currency = currency }, quantity));
                    }
                }
            }
            return products;
        }

        public void UpdateProduct(Product product, string OriginalName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"UPDATE Products SET 
                                    Name = @Name, 
                                    ItemPrice = @ItemPrice, 
                                    Currency = @Currency, 
                                    Quantity = @Quantity 
                                 WHERE Name = @OriginalName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OriginalName", OriginalName);
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@ItemPrice", product.Price.ItemPrice);
                    command.Parameters.AddWithValue("@Currency", (int)product.Price.Currency);
                    command.Parameters.AddWithValue("@Quantity", product.Quantity);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteProduct(string productName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Products WHERE Name = @Name";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", productName);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
