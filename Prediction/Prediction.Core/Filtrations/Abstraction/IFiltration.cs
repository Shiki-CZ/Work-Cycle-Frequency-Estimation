using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prediction.Core.Frequencies;
using Prediction.Core.Grouping;

namespace Prediction.Core.Filtrations.Abstraction
{
    internal interface IFiltration
    {
        public float[] SignificanceFilter(IEnumerable<FrequencyArray> data);
    }
}
