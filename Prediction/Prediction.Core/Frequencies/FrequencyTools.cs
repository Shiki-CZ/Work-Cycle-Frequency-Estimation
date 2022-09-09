using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Prediction.Core.Curve.Extremes;
using Prediction.Core.Frequencies;
using Prediction.Core.Grouping.Abstraction;

namespace Prediction.Core.Grouping
{
    public static class FrequencyTools
    {
        public static FrequencyArray[] ToFrequencies(this IEnumerable<Extreme> data, float timestep)
        {
            var timeAscend = data.OrderBy(data => data.Time).ToArray();
            var frequency = new List<FrequencyArray> { };
            int time1 = 0;
            int time2 = 0;
            float freq = 0;
            float period = 0;
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
                        period = Math.Abs(time2 - time1) * timestep;
                        freq = 1 / period;
                        frequency.Add(new FrequencyArray { Time1 = time1, Time2 = time2, Frequency = freq, FrequencyGroup = groupNumber, Period = period });
                    }
                }
            }


            return frequency.ToArray();
        }

        public static List<float> FindMainFrequency(this IEnumerable<FrequencyArray> data)
        {
            List<float> mainFrequencies = new List<float>();
            var periodAscend = data.OrderBy(data => data.Period).ToArray();
            var counts = periodAscend.Select(item => periodAscend.Count(i => i.Period == item.Period)).ToList();
            var countsDescent = counts.OrderByDescending(counts => counts).ToArray();
            var countsDescentDistinct = countsDescent.Distinct().ToArray();

            for (int i = 0; i < countsDescentDistinct.Length; i++)
            {
                var index = counts.FindIndex(counts => counts == countsDescentDistinct[i]);
                mainFrequencies.Add(periodAscend[index].Period);
            }
            //možná přidat filtr s tolerancí např. +/- 1% pro sjednocení "stejných" frekvencí => lepší čitelnost a jistota nalezení nejčastější frekvence
            return mainFrequencies;
        }

        public static FrequencyArray[] MainFrequencyLocator(this IEnumerable<FrequencyArray> data, List<float> mainFrequencies)
        {
            var frequencyLocation = new List<FrequencyArray> { };
            var groupdAscend = data.OrderBy(data => data.FrequencyGroup).ToArray();
            var mainFrequencyGroups = groupdAscend.Where(a => a.Period == mainFrequencies[0]).ToArray();
            var groupCountOccurence =
                mainFrequencyGroups.Select(item => mainFrequencyGroups.Count(i => i.FrequencyGroup == item.FrequencyGroup)).ToList();
            var groupCountOccurenceMax = groupCountOccurence.Max();
            var index = groupCountOccurence.FindIndex(countsInGroups => countsInGroups == groupCountOccurenceMax);
            var mainFrequencyGroup = mainFrequencyGroups[index].FrequencyGroup;
            var mainFrequency = mainFrequencyGroups.Where(a => a.FrequencyGroup == mainFrequencyGroup).ToList();

            frequencyLocation.Add(new FrequencyArray { Time1 = mainFrequency[0].Time1, Time2 = mainFrequency[0].Time2, Frequency = mainFrequency[0].Frequency, FrequencyGroup = mainFrequency[0].FrequencyGroup, Period = mainFrequency[0].Period });
            return frequencyLocation.ToArray();
        }
    }
}
