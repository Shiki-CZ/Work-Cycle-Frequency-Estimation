using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prediction.Core.Curve.Extremes;
using Prediction.Core.Frequencies;

namespace Prediction.Core.Grouping.Abstraction
{
    public interface IFrequencyTools
    {
        public FrequencyArray[] ToFrequencies(IEnumerable<Extreme> data, float timestep);
        public List<int> FindMainFrequency(IEnumerable<FrequencyArray> data);
        public List<float> MainFrequencyLocator(IEnumerable<FrequencyArray> data, List<float> mainFrequencies);
    }
}
