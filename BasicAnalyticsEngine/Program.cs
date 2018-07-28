using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicAnalyticsEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<double>() { 1.223, 40.2123, 1.123, 1.123, 1.123 };
            var calc = new Analytics(numbers);
            calc.Calculate();
            Console.WriteLine(calc.Mean);
            Console.WriteLine(calc.StDev);
            var asd = calc.Freq;
            foreach (var ds in asd)
            {
                Console.WriteLine("Range: {0}-{1}: {2}", ds.Value.LowerBound, ds.Value.UpperBound, ds.Value.Freq);
            }
            Console.ReadLine();
        }
    }
}
