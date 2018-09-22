using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateGraphics {
    abstract class Graphics {
        protected double area; 
        abstract public void CalculateArea();
    }

    class Triangle : Graphics {
        private double a;
        private double h;
        public Triangle() {
            a = 10;
            h = 10;
            Console.WriteLine("create triangle!");
        }

        public Triangle(double a, double h) {
            this.a = a;
            this.h = h;
            Console.WriteLine("create triangle!");
        }
        public override void CalculateArea() {
            area = a * h / 2;
            Console.WriteLine(area);
        }
    }

    class Rectangle : Graphics {
        private double a;
        private double h;
        public Rectangle() {
            Console.WriteLine("create Rectangle!");
        }
        public Rectangle(double a, double h) {
            this.a = a;
            this.h = h;
            Console.WriteLine("create Rectangle!");
        }
        public override void CalculateArea() {
            area = a * h;
            Console.WriteLine(area);
        }
    }

    class Circle : Graphics {
        private double r;
        public Circle() {
            r = 10;
            Console.WriteLine("create Circle!");
        }
        public Circle(double r) {
            this.r = r;
            Console.WriteLine("create Circle!");
        }
        public override void CalculateArea() {
            area = r * r * Math.PI;
            Console.WriteLine(area);
        }
    }
    class Square : Graphics {
        private double r;
        public Square() {
            r = 10;
            Console.WriteLine("create square!");
        }
        public Square(double r) {
            this.r = r;
            Console.WriteLine("create square!");
        }
        public override void CalculateArea() {
            area = r * r;
            Console.WriteLine(area);
        }
    }
}
