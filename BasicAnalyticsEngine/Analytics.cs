using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicAnalyticsEngine
{
    class Analytics
    {
        public Analytics(IEnumerable<double> numbers)
        {
            _numbers = numbers;
        }
        public double Mean { get => sum/count; }
        public double StDev { get => Math.Sqrt(sqSum/count - Mean*Mean); }

        public Dictionary<int, Frequencies> Freq { get => freq;}

        public void Calculate()
        {
            foreach(var num in _numbers)
            {
                sum += num;
                sqSum += num * num;
                count++;
                Frequencies f;
                var bin = (int)Math.Floor(num / binSize);
                if (freq.TryGetValue(bin, out f))
                {
                    freq[bin].Freq += 1;
                }
                else
                {
                    freq.Add(bin, new Frequencies
                    {
                        LowerBound = bin * binSize,
                        UpperBound = (bin + 1) * binSize,
                        Freq = 1
                    });
                }
            }
            foreach (var key in freq.Keys)
            {
                freq[key].Freq = freq[key].Freq / (double)count;
            }
            isDataPrepared = true;
            return;
        }
        private Dictionary<int, Frequencies> freq = new Dictionary<int, Frequencies>();
        private bool isDataPrepared;
        private double sum;
        private double sqSum;
        private int count;
        private int binSize = 10;
        private IEnumerable<double> _numbers;
    }

    
}
