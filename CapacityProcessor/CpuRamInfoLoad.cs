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
        private const short maxStorageLength = 600;
        private const short maxLengthToSendInfo = 500;
        private const short lengthOfDeletingOldRecords = 99;

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
            if (storageOfCpuRamInfo.Count() == maxStorageLength)
            {
                storageOfCpuRamInfo.RemoveRange(maxLengthToSendInfo + 1, lengthOfDeletingOldRecords);
            }
            storageOfCpuRamInfo.Add(string.Format("CPU: {0}. \nRAM available: {1}.", cpuLoading, ramLoading));
        }

        public List<string> GetCpuRamInfo()
        {
            return storageOfCpuRamInfo.Count > maxLengthToSendInfo ? storageOfCpuRamInfo.GetRange(0, maxLengthToSendInfo + 1) :
                storageOfCpuRamInfo.GetRange(0, storageOfCpuRamInfo.Count);           
        }
    }
}
