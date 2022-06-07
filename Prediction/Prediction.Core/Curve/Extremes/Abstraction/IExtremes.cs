using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prediction.Core.Curve.Extremes.Abstraction
{
    public interface IExtremes
    {

        public GroupArray[] LocalMaximas(float[] data);

        public GroupArray[] ExtremeGroups(GroupArray[] data);

        public int[] MergeExtremeGroups(int[] data);
    }
}
