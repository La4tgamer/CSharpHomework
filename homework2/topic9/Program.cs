using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topic9 {
    class Program {
        static void Main(string[] args) {
            int[] array1 = new int[99];
            //初始化
            for (int i = 0; i < 99; i ++) {
                array1[i] = i + 2;
            }
            for (int i = 2; i < 51; i++) {
                for (int j = 0; j < 99; j++) {
                    if (array1[j] % i == 0 && array1[j] / i != 1) {
                        array1[j] = 0;
                    }
                }
            }
            foreach (int i in array1) {
                if (i != 0) {
                    Console.Write(i + " ");
                }
            }
            Console.Read();
        }
    }
}
