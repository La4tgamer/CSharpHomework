using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Tests {
    [TestClass()]
    public class OrderServiceTests {
        [TestMethod()]
        public void OrderServiceTest() {
            OrderService orderService = new OrderService();
        }

        [TestMethod()]
        public void ShowOrdersTest() {
            OrderService orderService = new OrderService();
            Order order = new Order("周", 123);
            order.AddItem("洗衣液", 3, 6);
            orderService.AddOrder(order);
            orderService.ShowOrders();
            orderService.DeleteOrder(order);
            orderService.ShowOrders();
        }

        [TestMethod()]
        public void AddOrderTest() {
            OrderService orderService = new OrderService();
            Assert.IsTrue(orderService.AddOrder());
        }

        [TestMethod()]
        public void AddOrderTest1() {
            OrderService orderService = new OrderService();
            Order order = new Order();
            Assert.IsTrue(orderService.AddOrder(order));
        }

        [TestMethod()]
        public void AddOrderTest2() {
            OrderService orderService = new OrderService();
            Assert.IsTrue(orderService.AddOrder("周"));
        }

        [TestMethod()]
        public void AddOrderTest3() {
            OrderService orderService = new OrderService();
            Assert.IsTrue(orderService.AddOrder("周", 123));
        }

        [TestMethod()]
        public void DeleteOrderTest() {
            OrderService orderService = new OrderService();
            orderService.AddOrder("周", 123);
            Assert.IsTrue(orderService.DeleteOrder(0));
        }

        [TestMethod()]
        public void DeleteOrderTest1() {
            OrderService orderService = new OrderService();
            Order order = new Order();
            orderService.AddOrder(order);
            Assert.IsTrue(orderService.DeleteOrder(order));
        }

        [TestMethod()]
        public void FindOrderTest() {
            OrderService orderService = new OrderService();
            orderService.AddOrder("周", 123);
            Order order = orderService.FindOrder("周");
            Assert.AreSame(order, orderService.Orders[0]);
        }

        [TestMethod()]
        public void FindOrderByIDTest() {
            OrderService orderService = new OrderService();
            orderService.AddOrder("周", 123);
            Order order = orderService.FindOrder(123);
            Assert.AreSame(order, orderService.Orders[0]);
        }

        [TestMethod()]
        public void FindOrderByCustomerTest() {
            OrderService orderService = new OrderService();
            orderService.AddOrder("周", 123);
            List<Order> Orders = orderService.FindOrderByCustomer("周");
            Assert.AreEqual(Orders[0].Customer, orderService.Orders[0].Customer);
        }

        [TestMethod()]
        public void FindOrderByMoneyTest() {
            OrderService orderService = new OrderService();
            orderService.AddOrder("周", 123);
            orderService.Orders[0].TotalMoney = 100000;
            List<Order> Orders = orderService.FindOrderByMoney();
            Assert.AreEqual(Orders[0].TotalMoney, orderService.Orders[0].TotalMoney);
        }

        [TestMethod()]
        public void FindOrderTest1() {
            OrderService orderService = new OrderService();
            orderService.AddOrder("周", 123);
            Order order = orderService.FindOrder(123);
            Assert.AreSame(order, orderService.Orders[0]);
        }

        [TestMethod()]
        public void ModifyOrderTest() {
            OrderService orderService = new OrderService();
            orderService.AddOrder("周", 123);
            Order order = new Order("王", 124);
            orderService.ModifyOrder(0, order);
            Assert.AreSame(order, orderService.Orders[0]);
        }

        [TestMethod()]
        public void ExportTest() {
            OrderService orderService = new OrderService();
            orderService.AddOrder("周", 123);
            Assert.IsTrue(orderService.Export(@"E:\C#Homework\CSharpHomework\homework6\OrderManager\bin\Debug\Orders.xml"));
        }

        [TestMethod()]
        public void ImportTest() {
            OrderService orderService = new OrderService();
            orderService.AddOrder("周", 123);
            Assert.IsTrue(orderService.Export(@"E:\C#Homework\CSharpHomework\homework6\OrderManager\bin\Debug\OrderText.xml"));
            Assert.IsTrue(orderService.Import(@"E:\C#Homework\CSharpHomework\homework6\OrderManager\bin\Debug\OrderText.xml"));
        }
    }
}