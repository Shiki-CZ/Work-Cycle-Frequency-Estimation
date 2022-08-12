using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prediction.Core.Convertions.Abstraction;
using Prediction.Core.Curve.Extremes;

namespace Prediction.Core.Convertions
{
    internal class FrequencyConverter : IFrequencyConverter
    {
        public Extreme[] ToPeriod(IEnumerable<Extreme> data)
        {
            
            throw new NotImplementedException();
        }

        public Extreme[] ToExtremes(IEnumerable<Extreme> data)
        {
            throw new NotImplementedException();
        }
    }
}
