using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock {

    //参数类型
    public class ClockEventArgs : EventArgs {
        public DateTime Time { set; get; }
    }
    //声明委托
    public delegate void ClockEventHandler(object sender, ClockEventArgs e);
    class Clock {
        //注册到达时间的事件
        public event ClockEventHandler OnClock;
        //设置闹钟的函数，在里面调用事件
        public void SetAlarm(DateTime time) {
            //TimeSpan aTime = TimeSpan.FromMinutes(1);
            //time = DateTime.Now + aTime;
            if (OnClock != null) {
                ClockEventArgs args = new ClockEventArgs();
                args.Time = time;
                OnClock(this, args);
            }
        }
    }
}
