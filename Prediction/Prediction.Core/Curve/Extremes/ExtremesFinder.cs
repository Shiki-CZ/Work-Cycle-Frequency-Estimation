using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Prediction.Core.Curve.Extremes.Abstraction;

namespace Prediction.Core.Curve.Extremes
{
    public class ExtremesFinder : IExtremesFinder
    {
        public Extreme[] LocalMaximas(float[] data)
        {
            var Extremes = new List<Extreme> { };
            if (data[0] > data[1])
                Extremes.Add(new Extreme { Time = 0, Value = data[0] });

            for (int i = 1; i < data.Length - 1; i++)
            {
                if ((data[i - 1] < data[i]) && (data[i] > data[i + 1]))
                    Extremes.Add(new Extreme { Time = i, Value = data[i] });
            }

            int pos = 0;

            return Extremes.ToArray();
        }

        public Extreme[] ExtremeGroups(IEnumerable<Extreme> data)
        {
            var extremesAscend = data.OrderBy(data => data.Value).ToArray();
            extremesAscend[0].ExtremeGroup = 1;
            int groups = 1;
            int counter = 1;
            float sumValue = extremesAscend[0].Value;
            float average = extremesAscend[0].Value;
            float lastVal = 0;

            for (int i = 1; i <= extremesAscend.Length - 1; i++)
            {
                float peakThresh = average + average * 0.12f;
                if (extremesAscend[i].Value < peakThresh)
                {

                    extremesAscend[i].ExtremeGroup = groups;

                    for (int element = 1; element <= extremesAscend.Length - 1; element++)
                    {
                        if (extremesAscend[element].ExtremeGroup == groups)
                        {
                            counter++;
                            sumValue += extremesAscend[element].Value;
                        }
                        else if (extremesAscend[element].ExtremeGroup == 0)
                        {
                            break;
                        }
                    }
                    average = sumValue / counter;
                    counter = 1;
                    if (groups == 1)
                    {
                        sumValue = extremesAscend[0].Value;
                    }
                    else
                    {
                        sumValue = lastVal;
                    }
                }
                else
                {
                    groups++;
                    counter = 1;
                    extremesAscend[i].ExtremeGroup = groups;
                    average = extremesAscend[i].Value;
                    lastVal = extremesAscend[i].Value;
                    sumValue = extremesAscend[i].Value;
                }
            }

            return extremesAscend;
        }

        public Extreme[] MergeExtreme(IEnumerable<Extreme> data)
        {
            var extremeGroupAscend = data.OrderBy(data => data.ExtremeGroup).ToArray();
            int pos1 = 0;
            int pos2 = 0;
            int posDiff = 0;
            int pos_thresh = 100;

            for (int groupNumber = 1; groupNumber <= extremeGroupAscend.Max(extremeGroupAscend => extremeGroupAscend.ExtremeGroup); groupNumber++)
            {
                for (int first = 0; first < extremeGroupAscend.Length; first++)
                {
                    if (extremeGroupAscend[first].ExtremeGroup == groupNumber)
                    {
                        pos1 = extremeGroupAscend[first].Time;
                        for (int second = 1; second < extremeGroupAscend.Length; second++)
                        {
                            if (extremeGroupAscend[second].ExtremeGroup == groupNumber)
                            {
                                pos2 = extremeGroupAscend[second].Time;
                                posDiff = Math.Abs(pos2 - pos1);
                                if (posDiff < pos_thresh)
                                {
                                    if (extremeGroupAscend[first].Value > extremeGroupAscend[second].Value)
                                    {
                                        extremeGroupAscend[first].MergeExtreme = false;
                                        extremeGroupAscend[second].MergeExtreme = true;
                                    }
                                    else
                                    {
                                        extremeGroupAscend[first].MergeExtreme = true;
                                        extremeGroupAscend[second].MergeExtreme = false;
                                    }
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            return extremeGroupAscend;
        }
    }



}
