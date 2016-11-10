using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;


namespace CapacityProcessor
{

    class Timer
    {
        System.Timers.Timer aTimer = new System.Timers.Timer();
        CPU_RAM_Counter counter;
        private List<string> storage;
        
        public Timer()
        {
            storage = new List<string>();
            counter = new CPU_RAM_Counter();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;

            //Console.WriteLine("Press \'q\' to quit.");
            //while (Console.Read() != 'q') ;
        }
        
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {    
            storage.Add(string.Format("CPU: {0}. \nRAM available: {1}.", counter.getCurrentCpuUsage(), counter.getAvailableRAM()));
        }

        public void GetInfo()
        {
            aTimer.Enabled = false;
            foreach (var item in storage)
            {
                Console.WriteLine(item);
            }
            aTimer.Enabled = true;
        }
    }
}
