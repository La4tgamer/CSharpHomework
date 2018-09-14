using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topic7 {
    class Program {
        static void Main(string[] args) {
            int[] array1 = new int[10] {2, 5, 9, 8, 3, 4, 6, 1, 7, 10};
            int maxNumber = array1[0], minNumber = array1[0], sum = 0;
            foreach (int i in array1) {
                sum += i;
                if(i > maxNumber) {
                    maxNumber = i;
                }
                else if (i < minNumber) {
                    minNumber = i;
                }
            }
            double averageNumber = sum / (double)array1.Length;
            Console.WriteLine("最大值为:" + maxNumber + " 最小值为:" + minNumber
                + " 和为:" + sum + " 平均值为:" + averageNumber);
            /*这样比较方便
            Array.Sort(array1);
            foreach(int i in array1) {
                Console.Write(i + " ");
            }
            取出第一个和最后一个就是最值*/

            Console.Read();
        }
    }
}
