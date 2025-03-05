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
    }
}