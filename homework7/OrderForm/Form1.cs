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
    public partial class Form1 : Form {
        OrderService orderService = new OrderService();
        public Form1() {
            InitializeComponent();
            List<Order> Orders = new List<Order>();
            this.dataGridView1.DataSource = orderService.Orders;
            //this.dataGridView1.
            //this.dataGridView2.DataSource = orderService.Orders[this.dataGridView1.CurrentRow.Index].Items;
        }


        private void button1_Click(object sender, EventArgs e) {
            Form2 form2 = new Form2(orderService);
            form2.ShowDialog();
            this.dataGridView1.DataSource = new List<Order>();
            this.dataGridView1.DataSource = orderService.Orders;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            this.dataGridView2.DataSource = orderService.Orders[this.dataGridView1.CurrentRow.Index].Items;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e) {
            try {
                this.dataGridView2.DataSource = orderService.Orders[this.dataGridView1.CurrentRow.Index].Items;
            }
            catch{
                this.dataGridView2.DataSource = new List<OrderDetails>();
            }
            


        }

        private void Form1_Load(object sender, EventArgs e) {
            orderService.Import(Application.StartupPath.ToString() + "\\Order.xml");
            //加载时重新绑定
            this.dataGridView1.DataSource = new List<Order>();
            this.dataGridView1.DataSource = orderService.Orders;
        }

        private void button2_Click(object sender, EventArgs e) {
            Form2 form2 = new Form2(orderService, this.dataGridView1.CurrentRow.Index);
            form2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e) {
            orderService.DeleteOrder(this.dataGridView1.CurrentRow.Index);
            this.dataGridView1.DataSource = new List<Order>();
            this.dataGridView1.DataSource = orderService.Orders;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e) {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            if (orderService.Export(Application.StartupPath.ToString() + "\\Order.xml")) {
                MessageBox.Show("成功保存至" + 
                    Application.StartupPath.ToString() + "\\Order.xml");
            }

        }
    }
}
