using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PaintTree {
    class Painter {
        private Pen pen = Pens.Blue;
        public Graphics graphics;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        public Painter() {
            
        }
        public void SetMultipleOfLength(double per1, double per2) {
            this.per1 = per1;
            this.per2 = per2;
        }
        public void SetPenColor(string color) {
             
            switch (color.ToLower()) {
                case "bule":
                    pen = Pens.Blue;
                    break;
                case "red":
                    pen = Pens.Red;
                    break;
                case "purple":
                    pen = Pens.Purple;
                    break;
                case "green":
                    pen = Pens.Green;
                    break;
                case "brown":
                    pen = Pens.Brown;
                    break;
            }
        }
        public void DrawCayleyTree(int n,
                double x0, double y0, double leng, double th) {
            if (n == 0) return;
           
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            //两个子树生长位置变化
            Random rand = new Random();
            double r1 = rand.NextDouble();
            r1 = r1 < 0.25 ? r1 + 0.5 : r1;//在0.25以上生长

            double x2 = x0 + r1 * leng * Math.Cos(th);
            double y2 = y0 + r1 * leng * Math.Sin(th);
            DrawLine(x0, y0, x1, y1, n);
            //随机角度    
            th1 = rand.Next(20, 35) * Math.PI / 180;
            th2 = rand.Next(20, 35) * Math.PI / 180;
            //随机左右子树在中间生成数
            if (rand.Next(0,2) == 0) {
                DrawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
                DrawCayleyTree(n - 1, x2, y2, per2 * leng, th - th2);
            }
            else {
                DrawCayleyTree(n - 1, x2, y2, per1 * leng, th + th1);
                DrawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
            }
           
        }
        void DrawLine(double x0, double y0, double x1, double y1, int n) {
            if (n == 1)
                graphics.DrawLine(
                Pens.Green,
                (int)x0, (int)y0, (int)x1, (int)y1);
            else
                graphics.DrawLine(
                    pen, (int)x0, (int)y0, (int)x1, (int)y1);
        }

    }
}
