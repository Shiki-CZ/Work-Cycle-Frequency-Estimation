using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prediction.Core.Curve.Extremes.Abstraction;

namespace Prediction.Core.Curve.Extremes
{
    public class Extremes : IExtremes
    {
        public GroupArray[] LocalMaximas(float[] data)
        {
            var Extremes = new List<GroupArray> { };
            if (data[0] > data[1])
                Extremes.Add(new GroupArray { Time = 0, Extreme = data[0] });

            for (int i = 1; i < data.Length - 1; i++)
            {
                if ((data[i - 1] < data[i]) && (data[i] > data[i + 1]))
                    Extremes.Add(new GroupArray { Time = i, Extreme = data[i] });
            }

            int pos = 0;

            return Extremes.ToArray();
        }

        public GroupArray[] ExtremeGroups(IEnumerable<GroupArray> data)
        {
            float peakThresh = 0.12f;

            var extremesAscend = data.OrderBy(data => data.Extreme).ToArray();
            extremesAscend[0].ExtremeGroup = 1;
            int groups = 1;
            int counter = 1;
            float average = extremesAscend[0].Extreme;

            for (int i = 1; i <= extremesAscend.Length - 1; i++)
            {
                if (extremesAscend[i].Extreme < average + average*peakThresh)
                {
                    extremesAscend[i].ExtremeGroup = groups;

                    for (int element = 1; element <= extremesAscend.Length - 1; element++)
                    {
                        if (extremesAscend[element].ExtremeGroup == groups)
                        {
                            counter++;
                            average = (average + extremesAscend[element].Extreme) / counter;
                        }
                    }
                }
                else
                {
                    groups++;
                    counter = 1;
                    extremesAscend[i].ExtremeGroup = groups;
                    average = extremesAscend[i].Extreme;
                }
            }

            return extremesAscend;
        }

        public int[] MergeExtremeGroups(int[] data)
        {
            throw new NotImplementedException();
        }
    }

    public class GroupArray
    {
        public float Time { get; set; }
        public float Extreme { get; set; }
        public int ExtremeGroup { get; set; }
    }

}
