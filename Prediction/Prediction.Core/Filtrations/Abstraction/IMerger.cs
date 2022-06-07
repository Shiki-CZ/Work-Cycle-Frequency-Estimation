using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prediction.Core.Filtrations.Abstraction
{
    internal interface IMerger
    {
        public float[] Merge(float[] data);
    }
}
