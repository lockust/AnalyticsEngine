using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyticsEngine
{
    public class AnalyticsCalculator
    {
        public AnalyticsCalculator(IEnumerable<double> numbers)
        {
            _numbers = numbers;
        }
        private readonly int binSize = Properties.Settings.Default.binSize;
        private readonly IEnumerable<double> _numbers;
        private double Sum { get; set; }
        private int Count { get; set; }
        private double SqSum { get; set; }

        private double Mean { get => Sum / Count; }
        private double Stddev { get => Math.Sqrt(SqSum / Count - Mean * Mean); }
        private Dictionary<int, Bin> freq = new Dictionary<int, Bin>();

        public Analytics GetAnalytics()
        {
            InitializeFrequencies();
            foreach(var num in _numbers)
            {
                Sum += num;
                SqSum += num * num;
                Count++;
                CountObservations(num, Count);
            }
            UpdateFrequencies();
            return new Analytics(Mean, Stddev, freq);
        }

        private void UpdateFrequencies()
        {
            foreach (var val in freq.Values)
            {
                val.Frequency = val.Observations/(double)Count;
            }
        }

        private void InitializeFrequencies()
        {
            int startBin = Properties.Settings.Default.minObservation / binSize;
            int endBin = Properties.Settings.Default.maxObservation / binSize;
            for(int i = startBin; i <= endBin; i++)
            {
                freq.Add(i, new Bin
                {
                    LowerBound = i * binSize,
                    UpperBound = (i + 1) * binSize,
                    Observations = 0
                });
            }
        }

        private void CountObservations(double num, int count)
        {
            var bin = (int)Math.Floor(num / binSize);
            if (freq.TryGetValue(bin, out Bin b))
                freq[bin].Observations += 1;
            else
                Console.WriteLine("Observation {0} out of expected range", num);
            
            
        }
    }

    
}
