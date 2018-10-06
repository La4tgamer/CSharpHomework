using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager {
    class OrderManager {
        
        static void Main(string[] args) {
            OrderService orderService = new OrderService();
            orderService.AddOrder("王崎璇", 0001);
            orderService.Orders[0].AddItem("洗衣液", 2, 35.2);
            orderService.AddOrder("吴佳荫", 0002);
            orderService.Orders[1].AddItem("护发素", 6, 29.5);
            orderService.ShowOrders();
            Console.ReadKey();
        }

       
    }
}
