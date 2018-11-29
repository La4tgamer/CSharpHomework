using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using OrderManager;

namespace OrderForm {
    public partial class Form2 : Form {
        int flag;//判断是修改(1)还是添加(0)
        OrderService orderService;
        //处理前两个Text
        BindingSource bs = new BindingSource();
        Order order;
        //BindingList<OrderDetails> blist = new BindingList<OrderDetails>;
        public Form2(OrderService orderService) {
            flag = 0;
            InitializeComponent();
            this.orderService = orderService;
            order = new Order();
            bs.Add(order);
            textBox1.DataBindings.Add("Text", bs, "customer");
            textBox2.DataBindings.Add("Text", bs, "orderID");
        }
        public Form2(OrderService orderService, int index) {
            flag = 1;
            InitializeComponent();
            this.orderService = orderService;
            order = orderService.Orders[index];
            bs.Add(order);
            textBox1.DataBindings.Add("Text", bs, "customer");
            textBox2.DataBindings.Add("Text", bs, "orderID");
            //绑定items
            this.dataGridView1.DataSource = order.Items;
        }
        private void button1_Click(object sender, EventArgs e) {
            try {
                int count = dataGridView1.Rows.Count - 1;
                if (flag == 1) {
                    count++;
                    for (int i = 0; i < count; i++) {
                        //OrderDetails item = new OrderDetails();
                        for (int j = 1; j < dataGridView1.ColumnCount; j++) {
                            if (j == 1) {
                                order.Items[i].ProductName = dataGridView1.Rows[i].Cells[j].Value.ToString();
                            }
                            else if (j == 2) {
                                order.Items[i].ProductNum = int.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString());
                            }
                            else if (j == 3) {
                                order.Items[i].ProductPrice = double.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString());
                            }

                        }
                        order.Items[i].CalTotalMoney();
                    }
                }
                else {
                    for (int i = 0; i < count; i++) {
                        OrderDetails item = new OrderDetails();
                        for (int j = 1; j < dataGridView1.ColumnCount; j++) {
                            if (j == 1) {
                                item.ProductName = dataGridView1.Rows[i].Cells[j].Value.ToString();
                            }
                            else if (j == 2) {
                                item.ProductNum = int.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString());
                            }
                            else if (j == 3) {
                                item.ProductPrice = double.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString());
                            }

                        }
                        item.CalTotalMoney();
                        order.AddItem(item);
                    }
                }
                /*格式判断
                 * 订单号符合年月日加三位流水号(四位数加两位数0到12加0到31)
                 *电话号码规范
                 */
                Regex regexOrderNum = new Regex(@"^\d{4}[01]\d[0-3]\d{4}$");
                //Regex regexPhoneNum = new Regex()
                if (regexOrderNum.IsMatch(order.OrderID.ToString())) {
                    if (flag == 0) {
                        //orderService.AddOrder(order);
                        orderService.AddOrderDB(order);
                    }
                    else {
                        orderService.Update(order);
                    }
                    this.Close();
                }
                else {//失败添加失败
                    MessageBox.Show("订单号格式错误");
                }
            }
            catch {
                MessageBox.Show("添加失败");
                
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
