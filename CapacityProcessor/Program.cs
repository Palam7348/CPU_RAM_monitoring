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
            CpuRamInfoLoad loader = new CpuRamInfoLoad(300, 3000);
            
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(5000);
                ShowList(loader.GetCpuRamInfo());
                
            }

            Console.ReadKey();

        }
    }
}
