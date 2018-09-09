using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS9_9_4 {
    class Program {
        static void Main(string[] args) {
            int IVa1 = 0;
            int IVa2 = 0;
            string s;
            Console.Write("input the first number:");
            s = Console.ReadLine();
            IVa1 = int.Parse(s);
            Console.Write("input the second number:");
            s = Console.ReadLine();
            IVa2 = int.Parse(s);
            Console.Write("Their product is");
            Console.WriteLine(IVa2 * IVa2);
        }
    }
}
