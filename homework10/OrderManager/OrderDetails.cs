using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace OrderManager {
    [Serializable]
    public class OrderDetails {
        [Key]
        public string itemID { set; get; }
        public string ProductName{ set; get;}
        public int ProductNum { set; get; }
        public double ProductPrice { set; get; }
        public double TotalMoney { get; set; }
        //构造方法
        public OrderDetails() {
            itemID = Guid.NewGuid().ToString();
            ProductName = "未知";
            ProductNum = 0;
            ProductPrice = 0;
            TotalMoney = ProductPrice * ProductNum;

        }
        public OrderDetails(string productName) :this() {
            ProductName = productName;
            TotalMoney = ProductPrice * ProductNum;
        }
        public OrderDetails(string productName, int productNum) : this(productName) {
            ProductNum = productNum;
            TotalMoney = ProductPrice * ProductNum;
        }
        public OrderDetails(string productName, int productNum, double productPrice) : this(productName, productNum) {
            ProductPrice = productPrice;
            TotalMoney = ProductPrice * ProductNum;
        }
        //cal
        public void CalTotalMoney() {
            TotalMoney = ProductPrice * ProductNum;
        }
        //show
        public void ShowItem() {
            Console.WriteLine($"{ProductName} {ProductPrice}/件 * {ProductNum}件 共{TotalMoney}元");
        }
    }
}
