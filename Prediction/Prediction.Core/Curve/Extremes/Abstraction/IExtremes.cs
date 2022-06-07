using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prediction.Core.Curve.Extremes.Abstraction
{
    public interface IExtremes
    {

        public int[] LocalMaximas(int[] data);

        public int[] ExtremeGroups(int[] data);

        public int[] MergeExtremeGroups(int[] data);
    }
}
