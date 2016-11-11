using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CapacityProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            CpuRamInfoLoad cpuRamInfoLoader = new CpuRamInfoLoad();
            Thread.Sleep(5000);
            foreach (var item in cpuRamInfoLoader.GetCpuRamInfo())
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();

        }
    }
}
