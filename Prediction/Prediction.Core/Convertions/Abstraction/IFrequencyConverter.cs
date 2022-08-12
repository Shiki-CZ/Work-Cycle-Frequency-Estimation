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
        public Extreme[] ToPeriod(IEnumerable<Extreme> data);

        public Extreme[] ToExtremes(IEnumerable<Extreme> data);
    }
}
