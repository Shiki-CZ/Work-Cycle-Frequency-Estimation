using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prediction.Core.Convertions.Abstraction
{
    internal interface IFrequencyConverter
    {
        public int[] ToPeriod(int[] data);

        public int[] ToExtremes(int[] data);
    }
}
