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
        private const string CPUcategoryName = "Processor";
        private const string CPUcounterName = "% Processor Time";
        private const string CPUinstanceName = "_Total";
        private const string RAMcategoryName = "Memory";
        private const string RAMcounterName = "Available MBytes";


        public CpuRamCounter()
        {
            cpuCounter = new PerformanceCounter();

            cpuCounter.CategoryName = CPUcategoryName;
            cpuCounter.CounterName = CPUcounterName;
            cpuCounter.InstanceName = CPUinstanceName;

            ramCounter = new PerformanceCounter(RAMcategoryName, RAMcounterName);
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
