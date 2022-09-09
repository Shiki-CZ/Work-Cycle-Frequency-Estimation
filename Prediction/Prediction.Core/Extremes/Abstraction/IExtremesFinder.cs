using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prediction.Core.Curve.Extremes.Abstraction
{
    public interface IExtremesFinder
    {

        public Extreme[] LocalMaximas(float[] data);

        public Extreme[] ExtremeGroups(IEnumerable<Extreme> data, float groupsThreshold);

        public Extreme[] MergeExtreme(IEnumerable<Extreme> data, int mergeExtremesThreshold);
    }
}
