using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_class;

namespace UnitTestProject1
{
    [TestClass]
    public class OrderServiceTests
    {
        private OrderService orderService;

        [TestInitialize]
        public void Setup()
        {
            orderService = new OrderService();
        }

        [TestMethod]
        public void TestAddOrder()
        {
            Order order = new Order(1, "Customer1");
            orderService.AddOrder(order);
            var result = orderService.QueryOrders(o => o.OrderId == 1);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(order, result[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Order already exists.")]
        public void TestAddDuplicateOrder()
        {
            Order order = new Order(1, "Customer1");
            orderService.AddOrder(order);
            orderService.AddOrder(order);
        }

        [TestMethod]
        public void TestRemoveOrder()
        {
            Order order = new Order(1, "Customer1");
            orderService.AddOrder(order);
            orderService.RemoveOrder(1);
            var result = orderService.QueryOrders(o => o.OrderId == 1);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Order not found.")]
        public void TestRemoveNonExistentOrder()
        {
            orderService.RemoveOrder(1);
        }

        [TestMethod]
        public void TestUpdateOrder()
        {
            Order order = new Order(1, "Customer1");
            orderService.AddOrder(order);
            order.Customer = "UpdatedCustomer1";
            orderService.UpdateOrder(order);
            var result = orderService.QueryOrders(o => o.OrderId == 1);
            Assert.AreEqual("UpdatedCustomer1", result[0].Customer);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Order not found.")]
        public void TestUpdateNonExistentOrder()
        {
            Order order = new Order(1, "Customer1");
            orderService.UpdateOrder(order);
        }

        [TestMethod]
        public void TestQueryOrdersByCustomer()
        {
            Order order1 = new Order(1, "Customer1");
            orderService.AddOrder(order1);
            Order order2 = new Order(2, "Customer2");
            orderService.AddOrder(order2);
            var result = orderService.QueryOrders(o => o.Customer == "Customer1");
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(order1, result[0]);
        }

        [TestMethod]
        public void TestQueryOrdersByProductName()
        {
            Order order1 = new Order(1, "Customer1");
            order1.OrderDetailsList.Add(new OrderDetails("Product1", 2, 100));
            orderService.AddOrder(order1);
            Order order2 = new Order(2, "Customer2");
            order2.OrderDetailsList.Add(new OrderDetails("Product2", 1, 200));
            orderService.AddOrder(order2);
            var result = orderService.QueryOrders(o => o.OrderDetailsList.Any(od => od.ProductName == "Product1"));
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(order1, result[0]);
        }

        [TestMethod]
        public void TestQueryOrdersByTotalAmount()
        {
            Order order1 = new Order(1, "Customer1");
            order1.OrderDetailsList.Add(new OrderDetails("Product1", 2, 100));
            orderService.AddOrder(order1);
            Order order2 = new Order(2, "Customer2");
            order2.OrderDetailsList.Add(new OrderDetails("Product2", 1, 200));
            orderService.AddOrder(order2);
            var result = orderService.QueryOrders(o => o.TotalAmount == 200);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(order2, result[0]);
        }

        [TestMethod]
        public void TestSortOrders()
        {
            Order order1 = new Order(1, "Customer1");
            order1.OrderDetailsList.Add(new OrderDetails("Product1", 2, 100));
            orderService.AddOrder(order1);
            Order order2 = new Order(2, "Customer2");
            order2.OrderDetailsList.Add(new OrderDetails("Product2", 1, 200));
            orderService.AddOrder(order2);
            orderService.SortOrders((o1, o2) => o2.TotalAmount.CompareTo(o1.TotalAmount));
            var result = orderService.QueryOrders(o => true);
            Assert.AreEqual(2, result[0].OrderId);
        }
    }
}
