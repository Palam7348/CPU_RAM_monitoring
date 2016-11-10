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
        System.Timers.Timer timer = new System.Timers.Timer();
        CpuRamCounter counter;
        private List<string> storageOfCpuRamInfo;
        private const short interval = 1000;
        
        public Timer()
        {
            storageOfCpuRamInfo = new List<string>();
            counter = new CpuRamCounter();
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Interval = interval;
            timer.Enabled = true;

            //Press q to quit 
            while (Console.Read() != 'q') ;
        }
        
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {    
            storageOfCpuRamInfo.Add(string.Format("CPU: {0}. \nRAM available: {1}.", counter.GetInformationLoadCpu(), counter.GetInformationLoadRAM()));
        }

        public List<string> GetCpuRamInfo()
        {
            return storageOfCpuRamInfo.ToList();
        }


    }
}
