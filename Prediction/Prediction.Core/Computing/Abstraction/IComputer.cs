using Prediction.Core.Curve.Extremes;
using Prediction.Core.Frequencies;

namespace Prediction.Core.Computing.Abstraction;


public interface IComputer
{
    //void Compute(IDataFeeder feeder);
    void Compute();

    FrequencyArray[] Frequency { get; }
    Extreme[] MergedExtremes { get; }
    float[] CurveData { get; }
    List<float> MainFrequency { get; }
    FrequencyArray[] FrequencyLocator { get; }
}