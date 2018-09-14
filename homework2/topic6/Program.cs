using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topic6 {
    class Program {
        static void Main(string[] args) {
            int number = 0;
            while (true) {
                try {
                    Console.Write("input an integer:");
                    number = int.Parse(Console.ReadLine());
                    break;
                }
                catch {
                    Console.Write("Please correctly ");
                }
            }
            StringBuilder primeFactor = new StringBuilder();
            for(int i = 2; i <= Math.Sqrt(number); i++) {
                while (true) {
                    if(number % i == 0) {
                        number /= i;
                        primeFactor.Append(i);
                        if (number != 1) {
                            primeFactor.Append(" * ");
                        }
                    }
                    else {
                        break;
                    }
                }
                
            }
            if (number != 1) {
                primeFactor.Append(number);
                primeFactor.Append(" ");
            }
            Console.WriteLine(primeFactor);
            Console.Read();
        }
    }
}
