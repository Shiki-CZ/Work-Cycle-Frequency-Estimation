using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prediction.Core.Curve.Extremes;

namespace Prediction.Core.Grouping.Abstraction
{
    internal interface IToFrequency
    {
        public GroupArray[] GetFrequencies(IEnumerable<GroupArray> data, float timestep);
    }
}
