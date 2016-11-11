using System.Collections.Generic;
using System.Linq;
using System.Timers;


namespace CapacityProcessor
{

    class CpuRamInfoLoad
    {
        private System.Timers.Timer timer = new System.Timers.Timer();
        private CpuRamCounter counter;
        private List<string> storageOfCpuRamInfo;
        private const short interval = 1000;
        
        public CpuRamInfoLoad()
        {
            storageOfCpuRamInfo = new List<string>();
            counter = new CpuRamCounter();
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Interval = interval;
            timer.Start();
        }
        
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            string cpuLoading = counter.GetInformationLoadCpu();
            string ramLoading = counter.GetInformationLoadRAM();
            if (storageOfCpuRamInfo.Count() == 600)
            {
                storageOfCpuRamInfo.RemoveRange(501, 99);
            }
            storageOfCpuRamInfo.Add(string.Format("CPU: {0}. \nRAM available: {1}.", cpuLoading, ramLoading));
        }

        public List<string> GetCpuRamInfo()
        {
            return storageOfCpuRamInfo.Count > 500 ? storageOfCpuRamInfo.GetRange(0, 501) :
                storageOfCpuRamInfo.GetRange(0, storageOfCpuRamInfo.Count);           
        }
    }
}
