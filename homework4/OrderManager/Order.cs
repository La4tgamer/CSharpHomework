﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager {
    class Order {
        /* 订单号
         * 客户姓名
         * 订单条目（明细）
         * 添加或者删除条目
         */
        public long OrderID { set; get; }
        public string Customer { set; get; }
        public List<OrderDetails> Items { set; get; }
        //protected int maxItemNum = 10;
        public int itemNum { set; get; }
        //构造方法
        public Order() {
            OrderID = 0000;
            Customer = "未知";
            Items = new List<OrderDetails>();
            itemNum = 0;
        }
        public Order(string customer) :this() {
            Customer = customer;
        }
        public Order(string customer, long orderID) : this(customer) {
            //Customer = customer;
            OrderID = orderID;
        }
        //public Order(string customer, long orderID, int num) : this(customer, orderID) {
        //    //Customer = customer;
        //    //OrderNumber = orderNumber;
        //    maxItemNum = num;
        //}
        //change order
        
        public void ShowOrder() {
            Console.WriteLine(Customer + " " + OrderID);
            foreach (OrderDetails item in Items) {
                item.ShowItem();
                //Console.WriteLine(item.ProductName + " " + item.ProductPrice + "/件 *" + item.ProductNum);

            }
        }
        //add items
        public bool AddItem(OrderDetails item) {
            Items.Add(item);
            itemNum++;
            return true;
        }
        public bool AddItem(string productName) {
            OrderDetails item = new OrderDetails(productName);
            Items.Add(item);
            itemNum++;
            return true;
        }
        public bool AddItem(string productName, int productNum) {
            OrderDetails item = new OrderDetails(productName, productNum);
            Items.Add(item);
            itemNum++;
            return true;
        }
        public bool AddItem(string productName, int productNum, double productPrice) {
            OrderDetails item = new OrderDetails(productName, productNum, productPrice);
            Items.Add(item);
            itemNum++;
            return true;
        }
        //delete items
        public bool DeleteItem(int index) {
            if (itemNum == 0) {
                return false;
            }
            //for (int i = index; i < itemNum - 1; i++) {
            //    Items[index] = Items[index + 1];
            //}
            //Items[itemNum - 1] = null;
            //itemNum--;
            try {
                Items.RemoveAt(index);
            }
            catch { return false; }
            return true;
        }
        //modify items
        public bool ModifyItem(int index, string productName, int productNum, double productPrice) {
            try {
                OrderDetails item = new OrderDetails(productName, productNum, productPrice);
                Items[index] = item;
            }
            catch {
                return false;
            }
            return true;
        }
    }
}
