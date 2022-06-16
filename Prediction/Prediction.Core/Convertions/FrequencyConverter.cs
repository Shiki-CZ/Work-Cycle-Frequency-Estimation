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
        public GroupArray[] ToPeriod(IEnumerable<GroupArray> data)
        {
            
            throw new NotImplementedException();
        }

        public GroupArray[] ToExtremes(IEnumerable<GroupArray> data)
        {
            throw new NotImplementedException();
        }
    }
}
