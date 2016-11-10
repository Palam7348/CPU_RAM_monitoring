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
            Timer timer = new Timer();
            timer.GetInfo();
            Console.ReadKey();

        }
    }
}
