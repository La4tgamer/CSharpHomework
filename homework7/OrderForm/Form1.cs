using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.IO;
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
            //check money
            CheckMoney();
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
        public void CheckMoney() {
            //检查价格对不对
            foreach (var item in orderService.Orders) {
                foreach (var item1 in item.Items) {
                    item1.CalTotalMoney();
                }
                item.CalTotalMoney();
            }
        }
        private void Form1_Load(object sender, EventArgs e) {
            orderService.Import(Application.StartupPath.ToString() + "\\Order.xml");
            //检查价格
            CheckMoney();
            //加载时重新绑定
            this.dataGridView1.DataSource = new List<Order>();
            this.dataGridView1.DataSource = orderService.Orders;
        }

        private void button2_Click(object sender, EventArgs e) {
            Form2 form2 = new Form2(orderService, this.dataGridView1.CurrentRow.Index);
            form2.ShowDialog();
            //check money
            CheckMoney();
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

        private void textBox1_TextChanged(object sender, EventArgs e) {
            if (textBox1.Text == "" || textBox1.Text == null) {
                this.dataGridView1.DataSource = new List<Order>();
                this.dataGridView1.DataSource = orderService.Orders;
            }
            else {
                List<Order> orders = null;
                var query = from order in orderService.Orders
                            where order.Customer.Contains(textBox1.Text)
                            select order;
                orders = query.ToList();
                //
                this.dataGridView1.DataSource = new List<Order>();
                this.dataGridView1.DataSource = orders;
            }

        }

        private void outputHtmlToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                XmlDocument doc = new XmlDocument();
                doc.Load(@".\Order.xml");

                XPathNavigator nav = doc.CreateNavigator();
                nav.MoveToRoot();

                XslCompiledTransform xt = new XslCompiledTransform();
                xt.Load(@".\Order.xslt");

                FileStream outFileStream = File.Create(@".\OrderList.html");
                XmlTextWriter writer =
                    new XmlTextWriter(outFileStream, System.Text.Encoding.UTF8);
                xt.Transform(nav, null, writer);


            }catch {

            }
            //catch (XmlException e) {
            //    Console.WriteLine("XML Exception:" + e.ToString());
            //}
            //catch (XsltException e) {
            //    Console.WriteLine("XSLT Exception:" + e.ToString());
            //}
        
        }
    }
}
