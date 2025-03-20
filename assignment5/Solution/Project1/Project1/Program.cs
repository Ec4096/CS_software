//version1
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using Project_class;

//namespace Project1
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {

//            OrderService orderService = new OrderService();

//            // 添加
//            Order order1 = new Order(1, "Customer1");
//            order1.OrderDetailsList.Add(new OrderDetails("Product1", 2, 100));
//            order1.OrderDetailsList.Add(new OrderDetails("Product2", 1, 200));
//            orderService.AddOrder(order1);

//            Order order2 = new Order(2, "Customer2");
//            order2.OrderDetailsList.Add(new OrderDetails("Product3", 3, 150));
//            orderService.AddOrder(order2);

//            // 查询
//            var orders = orderService.QueryOrders(o => o.Customer == "Customer1");
//            foreach (var order in orders)
//            {
//                Console.WriteLine(order);
//            }

//            // 删除
//            try
//            {
//                orderService.RemoveOrder(3);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }

//            // 修改
//            try
//            {
//                order1.Customer = "UpdatedCustomer1";
//                orderService.UpdateOrder(order1);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }

//            // 排序
//            orderService.SortOrders((o1, o2) => o2.TotalAmount.CompareTo(o1.TotalAmount));
//            foreach (var order in orderService.QueryOrders(o => true))
//            {
//                Console.WriteLine(order);
//            }
//        }
//    }
//}

//version2
using System;
using System.Collections.Generic;
using System.Linq;
using Project_class;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();
            bool exit = false;

            while (!exit)
            {
                DisplayMenu();
                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            AddOrder(orderService);
                            break;
                        case "2":
                            RemoveOrder(orderService);
                            break;
                        case "3":
                            UpdateOrder(orderService);
                            break;
                        case "4":
                            QueryOrders(orderService);
                            break;
                        case "5":
                            DisplayAllOrders(orderService);
                            break;
                        case "6":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("无效选择，请重新输入。");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"操作失败: {ex.Message}");
                }
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("请选择操作：");
            Console.WriteLine("1. 添加订单");
            Console.WriteLine("2. 删除订单");
            Console.WriteLine("3. 修改订单");
            Console.WriteLine("4. 查询订单");
            Console.WriteLine("5. 显示所有订单");
            Console.WriteLine("6. 退出");
        }

        static void AddOrder(OrderService orderService)
        {
            int orderId = ReadInt("请输入订单ID: ");
            string customer = ReadString("请输入客户名称: ");

            Order order = new Order(orderId, customer);

            while (true)
            {
                string productName = ReadString("请输入商品名称(输入'结束'结束添加): ");
                if (productName.ToLower() == "结束") break;

                int quantity = ReadInt("请输入商品数量: ");
                double unitPrice = ReadDouble("请输入商品单价: ");

                order.OrderDetailsList.Add(new OrderDetails(productName, quantity, unitPrice));
            }

            orderService.AddOrder(order);
            Console.WriteLine("订单添加成功！");
        }

        static void RemoveOrder(OrderService orderService)
        {
            int orderId = ReadInt("请输入要删除的订单ID: ");
            orderService.RemoveOrder(orderId);
            Console.WriteLine("订单删除成功！");
        }

        static void UpdateOrder(OrderService orderService)
        {
            int orderId = ReadInt("请输入要修改的订单ID: ");
            string customer = ReadString("请输入新的客户名称: ");

            Order order = new Order(orderId, customer);

            while (true)
            {
                string productName = ReadString("请输入商品名称(输入'结束'结束添加): ");
                if (productName.ToLower() == "结束") break;

                int quantity = ReadInt("请输入商品数量: ");
                double unitPrice = ReadDouble("请输入商品单价: ");

                order.OrderDetailsList.Add(new OrderDetails(productName, quantity, unitPrice));
            }

            orderService.UpdateOrder(order);
            Console.WriteLine("订单修改成功！");
        }

        static void QueryOrders(OrderService orderService)
        {
            Console.WriteLine("请选择查询条件：");
            Console.WriteLine("1. 按订单ID查询");
            Console.WriteLine("2. 按客户名称查询");
            Console.WriteLine("3. 按商品名称查询");
            Console.WriteLine("4. 按订单金额查询");

            string choice = Console.ReadLine();
            List<Order> orders = null;

            switch (choice)
            {
                case "1":
                    int orderId = ReadInt("请输入订单ID: ");
                    orders = orderService.QueryOrders(o => o.OrderId == orderId);
                    break;
                case "2":
                    string customer = ReadString("请输入客户名称: ");
                    orders = orderService.QueryOrders(o => o.Customer == customer);
                    break;
                case "3":
                    string productName = ReadString("请输入商品名称: ");
                    orders = orderService.QueryOrders(o => o.OrderDetailsList.Any(od => od.ProductName == productName));
                    break;
                case "4":
                    double amount = ReadDouble("请输入订单金额: ");
                    orders = orderService.QueryOrders(o => o.TotalAmount == amount);
                    break;
                default:
                    Console.WriteLine("无效选择，请重新输入。");
                    return;
            }

            foreach (var order in orders)
            {
                Console.WriteLine(order);
            }
        }

        static void DisplayAllOrders(OrderService orderService)
        {
            var orders = orderService.QueryOrders(o => true);
            foreach (var order in orders)
            {
                Console.WriteLine(order);
            }
        }

        static int ReadInt(string prompt)
        {
            Console.Write(prompt);
            return int.Parse(Console.ReadLine());
        }

        static double ReadDouble(string prompt)
        {
            Console.Write(prompt);
            return double.Parse(Console.ReadLine());
        }

        static string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}

