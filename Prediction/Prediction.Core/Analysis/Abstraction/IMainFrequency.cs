using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prediction.Core.Analysis.Abstraction
{
    internal interface IMainFrequency
    {
        public float[] FindFrequency(float[] data);
    }
}
