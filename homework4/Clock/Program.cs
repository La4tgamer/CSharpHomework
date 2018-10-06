using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock {
    class Program {
        static void Main(string[] args) {
            Clock aClock = new Clock();
            aClock.OnClock += ShowClock;
            DateTime time = DateTime.Now;
            bool flag = true;
            while (flag) {
                try {
                    //获取设定的闹钟时间
                    Console.Write("输入闹钟日期(Month):");
                    int clockMonth = int.Parse(Console.ReadLine());
                    Console.Write("输入闹钟日期(date):");
                    int clockDay = int.Parse(Console.ReadLine());
                    Console.Write("输入闹钟时间(Hour):");
                    int clockHour = int.Parse(Console.ReadLine());
                    Console.Write("输入闹钟时间(Minute):");
                    int clockMinute = int.Parse(Console.ReadLine());
                    time = new DateTime(DateTime.Now.Year, clockMonth, clockDay, clockHour, clockMinute, 0);
                    //保证闹钟在当前时间之后
                    if (time < DateTime.Now) {
                        Console.WriteLine("请输入有效时间");
                        continue;
                    }
                    flag = false;
                }
                catch {
                    Console.WriteLine("输入错误，请重新输入");
                }
            }
            aClock.SetAlarm(time);
            Console.ReadKey();
        }

        static void ShowClock(object sender, ClockEventArgs e) {
            while (e.Time > DateTime.Now) {
                Console.Clear();
                Console.WriteLine("剩余时间为");
                Console.WriteLine(e.Time - DateTime.Now);
                System.Threading.Thread.Sleep(500);
            }
            Console.WriteLine("Time out");
            while (true) {
                Console.Beep();
                System.Threading.Thread.Sleep(100);
            }
            
        }
    }
}
