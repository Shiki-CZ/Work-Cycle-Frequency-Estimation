using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prediction.Core.Curve.Extremes;
using Prediction.Core.Grouping.Abstraction;

namespace Prediction.Core.Grouping
{
    public class ToFrequency : IToFrequency
    {
        public FrequencyArray[] GetFrequencies(IEnumerable<GroupArray> data, float timestep)
        {
            var timeAscend = data.OrderBy(data => data.Time).ToArray();
            var frequency = new List<FrequencyArray> { };
            int time1 = 0;
            int time2 = 0;
            float freq = 0;
            int groupNumber = 0;

            for (int first = 0; first < timeAscend.Length - 1; first++)
            {
                if (timeAscend[first].MergeExtreme == true)
                {
                    continue;
                }
                time1 = timeAscend[first].Time;
                groupNumber = timeAscend[first].ExtremeGroup;
                for (int second = first + 1; second < timeAscend.Length; second++)
                {
                    if (timeAscend[second].MergeExtreme == true)
                    {
                        continue;
                    }
                    if (timeAscend[second].ExtremeGroup == groupNumber)
                    {
                        time2 = timeAscend[second].Time;
                        freq = 1 / (Math.Abs(time2 - time1) * timestep);
                        frequency.Add(new FrequencyArray { Time1 = time1, Time2 = time2, Frequency = freq, FrequencyGroup = groupNumber });
                    }
                }
            }


            return frequency.ToArray();
        }
    }
    public class FrequencyArray
    {
        public int Time1 { get; set; }
        public int Time2 { get; set; }
        public int FrequencyGroup { get; set; }
        public float Frequency { get; set; }
        public float Period { get; set; }

    }
}
