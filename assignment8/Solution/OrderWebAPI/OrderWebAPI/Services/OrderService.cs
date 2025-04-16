using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OrderWebAPI.Models;
using OrderWebAPI.Data;

namespace OrderWebAPI.Services
{
    public class OrderService
    {
        public void AddOrder(Order order)
        {
            using (var context = new OrderContext())
            {
                if (context.Orders.Any(o => o.OrderId == order.OrderId))
                {
                    throw new Exception("Order already exists.");
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
                    throw new Exception("Order not found.");
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
                return context.Orders.Include(o => o.OrderDetailsList).Where(predicate).ToList();
            }
        }
    }
}
