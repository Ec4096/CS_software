using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OrderWebAPI.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string Customer { get; set; }
        public virtual List<OrderDetails> OrderDetailsList { get; set; }
        [NotMapped]
        public double TotalAmount => OrderDetailsList.Sum(order => order.Amount);

        public Order()
        {
            OrderDetailsList = new List<OrderDetails>();
        }

        public Order(int orderId, string customer)
        {
            OrderId = orderId;
            Customer = customer;
            OrderDetailsList = new List<OrderDetails>();
        }
    }

    public class OrderDetails
    {
        [Key]
        public int OrderDetailsId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        [NotMapped]
        public double Amount => Quantity * UnitPrice;

        public OrderDetails() { }

        public OrderDetails(string productName, int quantity, double unitPrice)
        {
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}
