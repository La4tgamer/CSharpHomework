using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Data.Entity;

namespace OrderManager {
    public class OrderService {
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
        public bool AddOrder(string customer, string ID) {
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
        //find using LinkQ
        public Order FindOrderByID(string ID) {
            Order findOrder = null;
            var query = from order in this.Orders
                        where order.OrderID == ID
                        select order;
            findOrder = query.First();
            return findOrder;
        }
        public List<Order> FindOrderByCustomer(string customer) {
            List<Order> orders = null;
            var query = from order in this.Orders
                        where order.Customer == customer
                        select order;
            orders = query.ToList();
            return orders;
        }
        public List<Order> FindOrderByMoney() {
            List<Order> orders = null;
            var query = from order in this.Orders
                        where order.TotalMoney >= 10000
                        select order;
            orders = query.ToList();
            return orders;
        }
        public Order FindOrderID(string ID) {
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

        //序列化
        public bool Export(string fileName) {
            try {
                using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write)) {
                    XmlSerializer xml = new XmlSerializer(Orders.GetType());
                    xml.Serialize(fs, Orders);
                }
            }
            catch {
                return false;
            }
            return true;
            
        }
        //反序列化
        public bool Import(string fileName) {
            try {
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read)) {
                    XmlSerializer xml = new XmlSerializer(Orders.GetType());
                    Orders = (List<Order>)xml.Deserialize(fs);
                    orderNum = Orders.Count;
                }
            }
            catch {
                return false;
            }
            return true;
        }

        public void AddOrderEF(Order order) {
            using (OrderDB db = new OrderDB()) {
                try {
                    db.Order.Add(order);
                    //db.Order.Attach(order);
                    //db.Entry(order).State = EntityState.Added;
                    db.SaveChanges();
                }
                catch (Exception ex) {                }
            }
        }

        public void AddOrderDB(Order order) {
            using (var db = new OrderDB()) {
                db.Order.Add(order);
                //db.Order.Attach(order);
                //db.Entry(order).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void DeleteDB(string orderId) {
            using (var db = new OrderDB()) {
                var order = db.Order.Include("Items").SingleOrDefault(o => o.OrderID == orderId);
                db.OrderItem.RemoveRange(order.Items);
                db.Order.Remove(order);
                db.SaveChanges();
            }
        }

        public void Update(Order order) {
            using (var db = new OrderDB()) {
                db.Order.Attach(order);
                db.Entry(order).State = EntityState.Modified;
                order.Items.ForEach(
                    item => db.Entry(item).State = EntityState.Modified);
                db.SaveChanges();
            }
        }

        public Order GetOrder(string Id) {
            using (var db = new OrderDB()) {
                return db.Order.Include("Items").
                  SingleOrDefault(o => o.OrderID == Id);
            }
        }

        public void UpdateList() {
            using (var db = new OrderDB()) {
                this.Orders = db.Order.Include("items").ToList<Order>();
            }
        }
    }
}
