using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AnalyticsEngine
{
    class Program
    {
        static void Main(string[] args)
        {

            var numbers = new List<double>();

            var path = Properties.Settings.Default.FilePath;
            using (var reader = new StreamReader(path + @"\SampleData.csv"))
            {

                while (!reader.EndOfStream)
                {
                    var values = reader.ReadLine().Split(',').Select(st => double.Parse(st)).ToList();
                    numbers.AddRange(values);
                }
            }

            var calc = new AnalyticsCalculator(numbers);
            var analytics = calc.GetAnalytics();
            Console.WriteLine(analytics.Mean);
            Console.WriteLine(analytics.StdDev);
            foreach (var ds in analytics.Frequencies)
            {
                Console.WriteLine("Range: {0}-{1}: {2:0.0}", ds.Value.LowerBound, ds.Value.UpperBound, ds.Value.Frequency);
            }
            Console.ReadLine();
        }
    }
}
