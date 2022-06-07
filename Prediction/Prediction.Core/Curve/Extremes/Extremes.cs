using System;
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

        public GroupArray[] ExtremeGroups(GroupArray[] data)
        {
            //throw new NotImplementedException();
            float peakThresh = 0.12f;
            var ExtremesList = new List<float> { data.Extreme[0] };
            var TimeList = new List<float> { data.Time[0] };

            for (int i = 1; i <= data.Length - 1 ; i++)
            {
                float peak = data.Extreme[i];
                bool write = false;
                for (int j = 0; j < ExtremesList.Count; j++)
                {
                    float controlPeak;
                    controlPeak = ExtremesList.Average();
                    if (controlPeak - controlPeak * peakThresh <= peak && peak < controlPeak + controlPeak * peakThresh)
                    {
                        ExtremesList.Sort();
                    }
                }
            }

            return data;
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
