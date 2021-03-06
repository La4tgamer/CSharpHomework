﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager {
    class OrderService {
        //能够实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询）功能。
        //在订单删除、修改失败时，能够产生异常并显示给客户错误信息。
        //储存order的list
        public List<Order> Orders { set; get; }
        public int orderNum { set; get; }
        //构造函数
        public OrderService() {
            Orders = new List<Order>();
            orderNum = 0;
        }
        //show
        public void ShowOrders() {
            if (orderNum != 0) {
                foreach (Order order in Orders) {
                    order.ShowOrder();
                }
            }
            else {
                Console.WriteLine("没有订单");
            }
        }
        
        //add order
        public bool AddOrder() {
            Order order = new Order();
            Orders.Add(order);
            orderNum++;
            return true;
        }
        public bool AddOrder(string customer) {
            Order order = new Order(customer);
            Orders.Add(order);
            orderNum++;
            return true;
        }
        public bool AddOrder(string customer, long ID) {
            Order order = new Order(customer, ID);
            Orders.Add(order);
            orderNum++;
            return true;
        }
        public bool AddOrder(Order order) {
            Orders.Add(order);
            orderNum++;
            return true;
        }
        //delete
       public bool DeleteOrder(int index) {
            Orders.RemoveAt(index);
            orderNum--;
            return true;
        }
        public bool DeleteOrder(Order order) {
            try {
                Orders.RemoveAt(Orders.IndexOf(order));
                orderNum--;
                return true;
            }
            catch {
                return false;
            }
        }
        //find
        public Order FindOrder(string customer) {
            Order order = Orders.Find(findOrder => {
                if (findOrder.Customer == customer) {
                    return true;
                }
                return false;
            });
            return order;
        }
        public Order FindOrder(long ID) {
            Order order = Orders.Find(findOrder => {
                if (findOrder.OrderID == ID) {
                    return true;
                }
                return false;
            });
            return order;
        }
        //Modify
        public void ModifyOrder(int index, Order order) {
            Orders[index] = order;
        }
    }
}
