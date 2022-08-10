using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prediction.Core.Filtrations.Abstraction;
using Prediction.Core.Grouping;

namespace Prediction.Core.Filtrations
{
    public class FrequencySignificance : IFiltration
    {
        public float[] SignificanceFilter(IEnumerable<FrequencyArray> data)
        {
            var periodAscend = data.OrderBy(data => data.Period).ToArray();
            var significance = new List<SignificanceArray> { };
            int time1 = 0;
            int time2 = 0;
            float freq = 0;
            float period = 0;
            int groupNumber = 0;



            return null;
        }
    }

    public class SignificanceArray
    {
        public int Period { get; set; }
        public float Frequency { get; set; }
        public int Group { get; set; }
        public bool Significance { get; set; }

    }
}
