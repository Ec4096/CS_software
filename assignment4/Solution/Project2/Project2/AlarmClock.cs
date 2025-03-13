using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Clock
{
    class AlarmClock
    {
        private Timer timer;
        private DateTime alarmTime;

        public event EventHandler Tick;
        public event EventHandler Alarm;

        public AlarmClock()
        {
            timer = new Timer(1000);
            timer.Elapsed += TimerElapsed;
        }
        public void SetAlarm(DateTime time)
        {
            alarmTime = time;
        }
        public void Start()
        {
            timer.Start();
        }
        public void Stop()
        {
            timer.Stop();
        }
        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (Tick != null)
            {
                Tick(this, EventArgs.Empty);
            }

            if (DateTime.Now >= alarmTime)
            {
                if (Alarm != null)
                {
                    Alarm(this, EventArgs.Empty);
                }
                Stop();
            }
        }

    }
}
