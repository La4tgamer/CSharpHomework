using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateGraphics {
    class Client {
        static void Main(string[] args) {
            string[] type = { "triangle", "rectangle", "circle", "square" };
            Graphics[] graphics = new Graphics[4];
            for (int i = 0; i < graphics.Length; i++) {
                graphics[i] = Factory.CreateGraphics(type[i]);
            }
            for (int i = 0; i < graphics.Length; i++) {
                graphics[i].CalculateArea();
            }


            Console.ReadKey();
        }
    }
}
