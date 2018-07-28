using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyticsEngine
{
    public class Bin
    {
        public int LowerBound{get;set;}
        public int UpperBound { get; set; }
        public int Observations { get; set; }
        public int PopulationSize { get; set; }
        public double Frequency { get; set; }

    }
}
