using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prediction.Core.Grouping.Abstraction
{
    internal interface IGrouping
    {
        public float[] MakeGroup(float[] data);
    }
}
