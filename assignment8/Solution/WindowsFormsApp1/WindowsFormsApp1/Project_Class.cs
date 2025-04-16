using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Data.Entity;

namespace Project_class
{
    public class Order : IComparable<Order>
    {
        [Key]
        public int OrderId { get; set; }
        public string Customer { get; set; }
        public virtual List<OrderDetails> OrderDetailsList { get; set; }
        [NotMapped]
        public double TotalAmount => OrderDetailsList.Sum(order => order.Amount);
        // 无参数构造函数
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
        [Key]
        public int OrderDetailsId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        [NotMapped]
        public double Amount => Quantity * UnitPrice;
        // 无参构造函数
        public OrderDetails()
        {
        }
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
        public void AddOrder(Order order)
        {
            using (var context = new OrderContext())
            {
                if (context.Orders.Any(o => o.OrderId == order.OrderId))
                {
                    throw new Exception("Order already exists, please check.");
                }
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }

        public void RemoveOrder(int orderId)
        {
            using (var context = new OrderContext())
            {
                var order = context.Orders.Include(o => o.OrderDetailsList).FirstOrDefault(o => o.OrderId == orderId);
                if (order == null)
                {
                    throw new Exception("Order not found, please check.");
                }
                context.Orders.Remove(order);
                context.SaveChanges();
            }
        }

        public void UpdateOrder(Order order)
        {
            using (var context = new OrderContext())
            {
                var existingOrder = context.Orders.Include(o => o.OrderDetailsList).FirstOrDefault(o => o.OrderId == order.OrderId);
                if (existingOrder == null)
                {
                    throw new Exception("Order not found.");
                }
                context.Entry(existingOrder).CurrentValues.SetValues(order);
                existingOrder.OrderDetailsList = order.OrderDetailsList;
                context.SaveChanges();
            }
        }

        public List<Order> QueryOrders(Func<Order, bool> predicate)
        {
            using (var context = new OrderContext())
            {
                return context.Orders.Include(o => o.OrderDetailsList).Where(predicate).OrderBy(o => o.TotalAmount).ToList();
            }
        }

        public void SortOrders(Comparison<Order> comparison = null)
        {
            using (var context = new OrderContext())
            {
                var orders = context.Orders.Include(o => o.OrderDetailsList).ToList();
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

}
