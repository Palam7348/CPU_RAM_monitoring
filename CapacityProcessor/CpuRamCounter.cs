using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapacityProcessor
{
    public class CpuRamCounter
    {
        private PerformanceCounter cpuCounter;
        private PerformanceCounter ramCounter;
        private const string cpuCategoryName = "Processor";
        private const string cpuCounterName = "% Processor Time";
        private const string cpuInstanceName = "_Total";
        private const string ramCategoryName = "Memory";
        private const string ramCounterName = "Available MBytes";


        public CpuRamCounter()
        {
            cpuCounter = new PerformanceCounter();

            cpuCounter.CategoryName = cpuCategoryName;
            cpuCounter.CounterName = cpuCounterName;
            cpuCounter.InstanceName = cpuInstanceName;

            ramCounter = new PerformanceCounter(ramCategoryName, ramCounterName);
        }

        public string GetInformationLoadCpu()
        {
            return cpuCounter.NextValue() + "%";
        }

        public string GetInformationLoadRAM()
        {
            return ramCounter.NextValue() + "MB";
        }
    }
}
