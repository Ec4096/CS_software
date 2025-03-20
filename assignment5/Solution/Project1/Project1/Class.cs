using Project_class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_class
{
    public class Order : IComparable<Order>
    {
        public int OrderId { get; set; }
        public string Customer { get; set; }
        public List<OrderDetails> OrderDetailsList { get; set; }
        public double TotalAmount => OrderDetailsList.Sum(order => order.Amount);

        public Order(int orderId, string customer)
        {
            OrderId = orderId;
            Customer = customer;
            OrderDetailsList = new List<OrderDetails>();
        }

        public override bool Equals(object obj)
        {
            return obj is Order order && OrderId == order.OrderId;
        }

        public override int GetHashCode()
        {
            return OrderId.GetHashCode();
        }

        public override string ToString()
        {
            return $"OrderId: {OrderId}, Customer: {Customer}, TotalAmount: {TotalAmount}";
        }

        public int CompareTo(Order other)
        {
            return OrderId.CompareTo(other.OrderId);
        }
    }

    public class OrderDetails
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Amount => Quantity * UnitPrice;

        public OrderDetails(string productName, int quantity, double unitPrice)
        {
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public override bool Equals(object obj)
        {
            return obj is OrderDetails details && ProductName == details.ProductName;
        }

        public override int GetHashCode()
        {
            return ProductName.GetHashCode();
        }

        public override string ToString()
        {
            return $"ProductName: {ProductName}, Quantity: {Quantity}, UnitPrice: {UnitPrice}, Amount: {Amount}";
        }
    }

    public class OrderService
    {
        private List<Order> orders = new List<Order>();

        public void AddOrder(Order order)
        {
            if (orders.Contains(order))
            {
                throw new Exception("Order is exists,Please check");
            }
            orders.Add(order);
        }

        public void RemoveOrder(int orderId)
        {
            var order = orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
            {
                throw new Exception("Order not found,Please check");
            }
            orders.Remove(order);
        }

        public void UpdateOrder(Order order)
        {
            var existingOrder = orders.FirstOrDefault(o => o.OrderId == order.OrderId);
            if (existingOrder == null)
            {
                throw new Exception("Order not found.");
            }
            existingOrder.Customer = order.Customer;
            existingOrder.OrderDetailsList = order.OrderDetailsList;
        }

        public List<Order> QueryOrders(Func<Order, bool> predicate)
        {
            return orders
                .Where(predicate)
                .OrderBy(o => o.TotalAmount)
                .ToList();
        }

        public void SortOrders(Comparison<Order> comparison = null)
        {
            if (comparison == null)
            {
                orders.Sort();
            }
            else
            {
                orders.Sort(comparison);
            }
        }
    }
}



