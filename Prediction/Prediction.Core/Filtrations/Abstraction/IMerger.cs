using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prediction.Core.Curve.Extremes;

namespace Prediction.Core.Filtrations.Abstraction
{
    internal interface IMerger
    {
        public GroupArray[] Merge(IEnumerable<GroupArray> data);
    }
}
