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
        private short maxStorageLength;
        private short lengthOfMaxSequenceToSend;
        private const short lengthOfDeletingOldRecords = 99;

        public CpuRamInfoLoad(short lengthOfMaxSequenceToSend, int interval)
        {
            maxStorageLength = (short)(lengthOfMaxSequenceToSend + lengthOfDeletingOldRecords);
            storageOfCpuRamInfo = new List<string>();
            this.lengthOfMaxSequenceToSend = lengthOfMaxSequenceToSend;
            counter = new CpuRamCounter();
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Interval = interval;
            timer.Start();
        }
        
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            string cpuLoading = counter.GetInformationLoadCpu();
            string ramLoading = counter.GetInformationLoadRAM();
            if (storageOfCpuRamInfo.Count() >= maxStorageLength)
            {
                storageOfCpuRamInfo.RemoveRange(0, lengthOfDeletingOldRecords);
            }
            storageOfCpuRamInfo.Add(string.Format("CPU: {0}. \nRAM available: {1}.", cpuLoading, ramLoading));
        }

        public List<string> GetCpuRamInfo()
        {
            return storageOfCpuRamInfo.Take(lengthOfMaxSequenceToSend).Reverse().ToList();         
        }     
    }
}
