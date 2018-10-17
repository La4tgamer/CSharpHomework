using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager {
    class OrderManager {
        
        static void Main(string[] args) {
           
            /*设计思路：创建order service来开始，通过客户输入的不同的指令来添加order
            * 在order中提示客户输入item的数据，利用循环，输入完毕之后关闭
            * 在关于订单的修改中，提供重新生成一个新的订单，也提供删除item或者增加item，或者提供修改某个item
            * 订单查询支持各种数据的查询，通过item查询还需要想想怎么查询，而且查询分两种，第一个或者所有符合的订单
            */
           
            OrderService orderService = new OrderService();
            //开始输入订单
            //有关删除商品的异常处理ok,修改商品的异常处理ok,添加商品ok,添加订单ok，修改订单ok，删除订单ok
            while (true) {
                string customer = null;
                long ID = 0;
                Console.WriteLine("输入0显示所有订单，1添加订单，2删除订单，3查询订单(修改)，4退出");
                int a;
                try {
                    a = int.Parse(Console.ReadLine());
                }
                catch {
                    Console.WriteLine("输入错误");
                    continue;
                }
                if (a == 0) {
                    orderService.ShowOrders();
                }
                else if (a == 1) {
                    AddOrder(orderService);
                }
                else if (a == 2) {
                    Order order = null;
                    try {
                        Console.Write("请输入订单号:");
                        long find = long.Parse(Console.ReadLine());
                        order = orderService.FindOrder(find);
                        if (orderService.DeleteOrder(order)) {
                            Console.WriteLine("成功删除订单");
                        }
                        else {
                            Console.WriteLine("删除订单失败");
                        }
                    }
                    catch {
                        Console.WriteLine("失败");
                    }
                }
              
                else if (a == 3) {
                    Console.Write("请输入客户姓名或订单号(输入'按照金额'搜索大于1w元订单):");
                    string find = Console.ReadLine();
                    List<Order> orders = null;
                    Order order = null;
                    if (long.TryParse(find, out ID)) {
                        order = orderService.FindOrder(ID);
                    }
                    else {
                        if (find == "按照消费") {
                            orders = orderService.FindOrderByMoney();
                        }
                        else {
                            customer = find;
                            order = orderService.FindOrder(customer);
                        }
                    }
                    if (order != null) {
                        order.ShowOrder();
                        Console.WriteLine("输入1修改，0返回");
                        while (int.Parse(Console.ReadLine()) == 1) {
                            ModifyOrder(orderService, order);
                            Console.WriteLine("输入1修改，0返回");
                        }                        
                    }
                    else if (orders != null) {
                        foreach (var e in orders) {
                            e.ShowOrder();
                        }
                        Console.WriteLine("输入1修改，0返回");
                        while (int.Parse(Console.ReadLine()) == 1) {
                            Console.WriteLine("选择修改第几个订单");
                            int index = int.Parse(Console.ReadLine());
                            ModifyOrder(orderService, orders[index]);
                            Console.WriteLine("输入1继续修改，0返回");
                        }
                    }
                    else {
                        Console.WriteLine("未找到订单");
                    }
                }
                else {
                    break;
                }
                
            }
            Console.ReadKey();
        }

       public static void AddOrder(OrderService orderService) {
            string customer = null;
            long ID = 0;
            try {
                Console.Write("请输入客户姓名:");
                customer = Console.ReadLine();
                Console.Write("请输入订单编号:");
                ID = long.Parse(Console.ReadLine());
            }
            catch {
                Console.WriteLine("添加失败");
                return;
            }
            Order order = null;
            try { 
                orderService.AddOrder(customer, ID);
                order = orderService.Orders[orderService.orderNum - 1];
                while (true) {
                    Console.WriteLine("输入1添加商品，2删除，3修改，0退出");
                    int b = int.Parse(Console.ReadLine());
                    if (b == 1) {
                        Console.WriteLine("输入商品名字");
                        string productName = Console.ReadLine();
                        Console.WriteLine("输入商品数量");
                        int productNum = int.Parse(Console.ReadLine());
                        Console.WriteLine("输入商品单价");
                        double productPrice = double.Parse(Console.ReadLine());
                        order.AddItem(productName, productNum, productPrice);
                    }
                    else if (b == 2) {
                        Console.WriteLine("请输入删除的商品序列号");
                        int index = int.Parse(Console.ReadLine());
                        if (order.DeleteItem(index)) {
                            Console.WriteLine("删除成功");
                        }
                        else {
                            Console.WriteLine("删除失败");
                        }
                    }
                    else if (b == 3) {
                        Console.WriteLine("请输入修改的商品序列号(第几件)");
                        int index = int.Parse(Console.ReadLine());
                        Console.WriteLine("输入商品名字");
                        string productName = Console.ReadLine();
                        Console.WriteLine("输入商品数量");
                        int productNum = int.Parse(Console.ReadLine());
                        Console.WriteLine("输入商品单价");
                        double productPrice = double.Parse(Console.ReadLine());
                        if (order.ModifyItem(index - 1, productName, productNum, productPrice)) {
                            Console.WriteLine("修改成功");
                        }
                        else {
                            Console.WriteLine("修改失败");
                        }
                    }
                    else {
                        break;
                    }
                }
                Console.WriteLine("成功添加如下订单");
                order.ShowOrder();
                return;
            }
            catch {
                Console.WriteLine("添加失败");
                orderService.DeleteOrder(order);
            }
            
        }
       public static void ModifyOrder(OrderService orderService, Order order) {
            try {
                string customer = null;
                long ID = 0;
                Console.Write("请输入客户姓名:");
                customer = Console.ReadLine();
                Console.Write("请输入订单编号:");
                ID = long.Parse(Console.ReadLine());
                Order newOrder = new Order(customer, ID);
                while (true) {
                    Console.WriteLine("输入1添加商品，2删除，3修改，0退出");
                    int b = int.Parse(Console.ReadLine());
                    if (b == 1) {
                        Console.WriteLine("输入商品名字");
                        string productName = Console.ReadLine();
                        Console.WriteLine("输入商品数量");
                        int productNum = int.Parse(Console.ReadLine());
                        Console.WriteLine("输入商品单价");
                        double productPrice = double.Parse(Console.ReadLine());
                        newOrder.AddItem(productName, productNum, productPrice);
                    }
                    else if (b == 2) {
                        Console.WriteLine("请输入删除的商品序列号");
                        int index = int.Parse(Console.ReadLine());
                        if (newOrder.DeleteItem(index)) {
                            Console.WriteLine("删除成功");
                        }
                        else {
                            Console.WriteLine("删除失败");
                        }
                    }
                    else if (b == 3) {
                        Console.WriteLine("请输入修改的商品序列号");
                        int index = int.Parse(Console.ReadLine());
                        Console.WriteLine("输入商品名字");
                        string productName = Console.ReadLine();
                        Console.WriteLine("输入商品数量");
                        int productNum = int.Parse(Console.ReadLine());
                        Console.WriteLine("输入商品单价");
                        double productPrice = double.Parse(Console.ReadLine());
                        if (newOrder.ModifyItem(index - 1, productName, productNum, productPrice)) {
                            Console.WriteLine("修改成功");
                        }
                        else {
                            Console.WriteLine("修改失败");
                        }
                    }
                    else {
                        break;
                    }
                }
                orderService.ModifyOrder(orderService.Orders.IndexOf(order), newOrder);
                Console.WriteLine("成功修改为如下订单");
                newOrder.ShowOrder();
            }
            catch {
                Console.WriteLine("修改订单失败");
            }
        }
    }
}
