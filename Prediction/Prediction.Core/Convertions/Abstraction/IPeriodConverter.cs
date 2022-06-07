using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prediction.Core.Convertions.Abstraction
{
    internal interface IPeriodConverter
    {
        public int[] ToFrequency(int[] data);

    }
}
