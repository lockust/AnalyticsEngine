using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyticsEngine
{
    public class Analytics
    {
        private readonly double _mean;
        private readonly double _stdev;
        private readonly Dictionary<int, Bin> _freq;

        public Analytics(double mean, double stdev, Dictionary<int, Bin> frequencies)
        {
            _mean = mean;
            _stdev = stdev;
            _freq = frequencies;
        }
        public double Mean { get => _mean; }
        public double StdDev { get => _stdev; }
        public Dictionary<int, Bin> Frequencies { get => _freq; }

    }
}
