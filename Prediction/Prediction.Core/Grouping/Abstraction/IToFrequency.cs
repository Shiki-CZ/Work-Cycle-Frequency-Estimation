using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prediction.Core.Curve.Extremes;

namespace Prediction.Core.Grouping.Abstraction
{
    public interface IToFrequency
    {
        public FrequencyArray[] GetFrequencies(IEnumerable<GroupArray> data, float timestep);
    }
}
