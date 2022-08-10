using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prediction.Core.Filtrations.Abstraction;
using Prediction.Core.Grouping;

namespace Prediction.Core.Filtrations
{
    public class FrequencyCounter : IFiltration
    {
        public float[] SignificanceFilter(IEnumerable<FrequencyArray> data)
        {
            throw new NotImplementedException();
        }
    }
}
