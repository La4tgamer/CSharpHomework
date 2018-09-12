using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace topic5 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            double INum1 = 0;
            double INum2 = 0;
            if (double.TryParse(textBox1.Text, out INum1)) {
                INum1 = double.Parse(textBox1.Text);
            }
            else {
                INum1 = 0;
                label2.Text = "Input Number!";
            }
            if (double.TryParse(textBox2.Text, out INum2)) {
                INum2 = double.Parse(textBox2.Text);
            }
            else {
                INum2 = 0;
                label2.Text = "Input Number!";
            }
            label2.Text = (INum1 * INum2).ToString();
        }

        private void textBox1_Click(object sender, EventArgs e) {
            textBox1.Text = "";
        }

        private void textBox2_Click(object sender, EventArgs e) {
            textBox2.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e) {

        }
    }
}
