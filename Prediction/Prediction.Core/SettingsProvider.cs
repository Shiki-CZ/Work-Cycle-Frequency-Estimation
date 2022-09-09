using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prediction.Core
{
    public class SettingsProvider
    {
        public int Poly { get; set; } = 2;
        public float ExtremeGroupsThreshold { get; set; }= 0.12f;
        public int SmoothRange { get; set; } = 91;
        public int MergeExtermesThreshold { get; set; } = 100;
    }
}
