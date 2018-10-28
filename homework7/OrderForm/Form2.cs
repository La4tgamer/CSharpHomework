using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderManager;
namespace OrderForm {
    public partial class Form2 : Form {
        int flag;//判断是修改1还是添加0
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
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++) {
                    OrderDetails item = new OrderDetails();
                    for (int j = 0; j < dataGridView1.ColumnCount; j++) {
                        if (j == 0) {
                            item.ProductName = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                        else if (j == 1) {
                            item.ProductNum = int.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString());
                        }
                        else if (j == 2) {
                            item.ProductPrice = double.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString());
                        }
                    }
                    order.AddItem(item);
                }
                if (flag == 0) {
                    orderService.AddOrder(order);
                }
                else {

                }
                this.Close();
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
