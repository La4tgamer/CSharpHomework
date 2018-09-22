using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateGraphics {
    class Factory {
        public static Graphics CreateGraphics(string type) {
            Graphics graphic = null;
            if (type == "triangle") {
                try {
                    Console.Write("input a:");
                    double a = double.Parse(Console.ReadLine());
                    Console.Write("input h:");
                    double h = double.Parse(Console.ReadLine());
                    graphic = new Triangle(a, h);
                }
                catch {
                    Console.WriteLine("wrong");
                    graphic = new Triangle();
                }
                Console.WriteLine("initialization");
            }
            else if (type == "rectangle") {
                try {
                    Console.Write("input a:");
                    double a = double.Parse(Console.ReadLine());
                    Console.Write("input h:");
                    double h = double.Parse(Console.ReadLine());
                    graphic = new Rectangle(a, h);
                }
                catch {
                    Console.WriteLine("wrong");
                    graphic = new Rectangle();
                }
                Console.WriteLine("initialization");
            }
            else if (type == "circle") {
                try {
                    Console.Write("input r:");
                    double r = double.Parse(Console.ReadLine());
                    graphic = new Circle(r);
                }
                catch {
                    Console.WriteLine("wrong");
                    graphic = new Circle();
                }
                
                Console.WriteLine("initialization");
            }
            else if (type == "square") {
                try {
                    Console.Write("input r:");
                    double r = double.Parse(Console.ReadLine());
                    graphic = new Square(r);
                }
                catch {
                    Console.WriteLine("wrong");
                    graphic = new Square();
                }

                Console.WriteLine("initialization");
            }

            return graphic;
        }
    }
}
