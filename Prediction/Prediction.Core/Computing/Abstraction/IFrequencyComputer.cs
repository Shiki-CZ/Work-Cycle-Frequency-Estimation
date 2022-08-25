using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prediction.Core.Curve.Extremes;
using Prediction.Core.Grouping;

namespace Prediction.Core.Computing.Abstraction
{
    public interface IFrequencyComputer : IComputer
    {
        FrequencyArray[] Frequency { get; }
        Extreme[] MergedExtremes { get; }
        float[] CurveData { get;}
        List<float> MainFrequency { get;}
        FrequencyArray[] FrequencyLocator { get;}
    }
}
