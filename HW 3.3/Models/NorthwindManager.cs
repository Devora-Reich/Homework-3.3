using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HW_3._3.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipAddress { get; set; }

    }

    public class OrderDetails
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class Product
    {
        public string Name { get; set; }
    }
    public class NorthwindManager
    {
        private readonly string _connectionString;

        public NorthwindManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Order> GetOrders()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT OrderID, OrderDate, ShippedDate, Freight, ShipAddress " +
                "FROM Orders";
            connection.Open();
            List<Order> orders = new List<Order>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                orders.Add(new Order
                {
                    OrderId = (int)reader["OrderId"],
                    OrderDate = (DateTime)reader["OrderDate"],
                    ShipAddress = (string)reader["ShipAddress"]

                });
            }
            return orders;
        }

        public List<OrderDetails> GetOrderDetails()
        {

            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM [Order Details] od " +
                "JOIN Orders o " +
                "ON o.OrderID = od.OrderID " +
                "WHERE DATEPART (YEAR, OrderDate) = 1997";
            connection.Open();
            List<OrderDetails> orderDetails = new List<OrderDetails>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                orderDetails.Add(new OrderDetails
                {
                    OrderId = (int)reader["OrderID"],
                    ProductId = (int)reader["ProductID"],
                    UnitPrice = (decimal)reader["UnitPrice"],
                    Quantity = (short)reader["Quantity"],
                });
            }
            return orderDetails;
        }

        public List<Category> GetCategories()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Categories";
            connection.Open();
            List<Category> categories = new List<Category>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                categories.Add(new Category
                {
                    Id = (int)reader["CategoryID"],
                    Name = (string)reader["CategoryName"],
                    Description = (string)reader["Description"],
                });
            }
            return categories;
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Products " +
                "WHERE CategoryID = @Id";
            command.Parameters.AddWithValue("@Id", categoryId);
            connection.Open();
            List<Product> products = new List<Product>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                products.Add(new Product
                {
                    Name = (string)reader["ProductName"]
                });
            }
            return products;
        }

        public string SetProductCategoryName(int Id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT CategoryName FROM Categories " +
                "WHERE CategoryId = @Id";
            command.Parameters.AddWithValue("@Id", Id);
            connection.Open();

            return (string)command["CategoryName"];
        }
    }
}