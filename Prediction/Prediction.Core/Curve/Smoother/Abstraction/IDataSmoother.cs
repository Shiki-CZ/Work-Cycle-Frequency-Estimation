using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prediction.Core.Curve.Abstraction
{
    public interface IDataSmoother
    {
        public float[] Smooth(int[] data);

    }
}
