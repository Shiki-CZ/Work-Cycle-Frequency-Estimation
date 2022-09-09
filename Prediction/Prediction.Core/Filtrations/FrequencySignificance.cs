using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prediction.Core.Filtrations.Abstraction;
using Prediction.Core.Frequencies;
using Prediction.Core.Grouping;

namespace Prediction.Core.Filtrations
{
    public class FrequencySignificance : IFiltration
    {
        public float[] SignificanceFilter(IEnumerable<FrequencyArray> data)
        {
            var periodAscend = data.OrderBy(data => data.Period).ToArray();
            var significance = new List<SignificanceArray> { };

            return null;
        }
    }
}
