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
        public GroupArray[] GetFrequencies(IEnumerable<GroupArray> data, float timestep)
        {
            var timeAscend = data.OrderBy(data => data.Time).ToArray();
            int time1 = 0;
            int time2 = 0;

            for (int groupNumber = 1; groupNumber <= timeAscend.Max(extremeGroupAscend => extremeGroupAscend.ExtremeGroup); groupNumber++)
            {
                for (int first = 0; first < timeAscend.Length; first++)
                {
                    if (timeAscend[first].ExtremeGroup == groupNumber)
                    {
                        time1 = timeAscend[first].Time;
                        for (int second = 1; second <= timeAscend.Length; second++)
                        {
                            if (timeAscend[second].ExtremeGroup == groupNumber)
                            {
                                time2 = timeAscend[second].Time;
                                posDiff = Math.Abs(time2 - time1);
                                if (posDiff < pos_thresh)
                                {
                                    if (timeAscend[first].Extreme > timeAscend[second].Extreme)
                                    {
                                        timeAscend[first].MergeExtreme = false;
                                        timeAscend[second].MergeExtreme = true;
                                    }
                                    else
                                    {
                                        timeAscend[first].MergeExtreme = true;
                                        timeAscend[second].MergeExtreme = false;
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            throw new NotImplementedException();
        }
    }
}
