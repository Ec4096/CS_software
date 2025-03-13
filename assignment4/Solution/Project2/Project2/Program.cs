using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Clock;

namespace Project2
{

    class Program
    {
        static void Main(string[] args)
        {
            AlarmClock alarmClock = new AlarmClock();
            alarmClock.Tick += OnTick;
            alarmClock.Alarm += OnAlarm;

            alarmClock.SetAlarm(DateTime.Now.AddSeconds(10)); // 设置闹钟在10秒后响铃
            alarmClock.Start();

            Console.WriteLine("Set a Alarm clock...");
            Console.ReadKey();
        }

        private static void OnTick(object sender, EventArgs e)
        {
            Console.WriteLine("嘀嗒...");
        }

        private static void OnAlarm(object sender, EventArgs e)
        {
            Console.WriteLine("闹钟响了！");
        }
    }

    
}

