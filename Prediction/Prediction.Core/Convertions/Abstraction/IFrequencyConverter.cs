using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prediction.Core.Curve.Extremes;

namespace Prediction.Core.Convertions.Abstraction
{
    internal interface IFrequencyConverter
    {
        public GroupArray[] ToPeriod(IEnumerable<GroupArray> data);

        public GroupArray[] ToExtremes(IEnumerable<GroupArray> data);
    }
}
