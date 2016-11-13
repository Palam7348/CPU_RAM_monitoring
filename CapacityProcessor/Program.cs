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
        public static void ShowList(List<string> list)
        {       
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        static void Main(string[] args)
        {
            CpuRamInfoLoad loader = new CpuRamInfoLoad(50, 1000);
            for (;;)
            {
                ShowList(loader.GetCpuRamInfo());
                Thread.Sleep(1000);
                Console.Clear();

            }

            Console.ReadKey();

        }
    }
}
