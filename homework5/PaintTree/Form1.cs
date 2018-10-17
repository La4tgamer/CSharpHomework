using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintTree {
    public partial class Form1 : System.Windows.Forms.Form {
        private Painter painter = new Painter();
        public Form1() {
            InitializeComponent();           
        }
        
        private void Form1_Load(object sender, EventArgs e) {
            this.colors.SelectedIndex = 4;
        }

        private void draw_Click(object sender, EventArgs e) {
            painter.graphics = CreateGraphics();
            painter.graphics.Clear(Color.White);
            painter.SetMultipleOfLength((double)per1.Value, (double)per2.Value);
            painter.SetThicknessDegree((float)thicknessDegree.Value);
            painter.DrawCayleyTree((int)floor.Value, 250, 350
                , 100, -Math.PI / 2);
        }

        private void colors_SelectedIndexChanged(object sender, EventArgs e) {
            string a = colors.SelectedItem.ToString();
            painter.SetPenColor(a);
        }
    }
}
