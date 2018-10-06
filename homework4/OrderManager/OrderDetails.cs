using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager {
    class OrderDetails {
        public string ProductName{ set; get;}
        public int ProductNum { set; get; }
        public double ProductPrice { set; get; }
        //构造方法
        public OrderDetails() {
            ProductName = "未知";
            ProductNum = 0;
            ProductPrice = 0;
        }
        public OrderDetails(string productName) :this() {
            ProductName = productName;
        }
        public OrderDetails(string productName, int productNum) : this(productName) {
            ProductNum = productNum;
        }
        public OrderDetails(string productName, int productNum, double productPrice) : this(productName, productNum) {
            ProductPrice = productPrice;
        }
        //show
        public void ShowItem() {
            Console.WriteLine(ProductName + " " + ProductPrice + "/件 *" + ProductNum);
        }
    }
}
