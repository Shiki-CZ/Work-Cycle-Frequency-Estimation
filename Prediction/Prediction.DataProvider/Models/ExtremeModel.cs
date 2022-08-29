using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prediction.DataProvider.Abstraction;

namespace Prediction.DataProvider.Models
{
    public class ExtremeModel : IEntity
    {
        public Guid Id { get; set; }
        public int Time { get; set; }
        public float Value { get; set; }
        public int ExtremeGroup { get; set; }
        public bool MergeExtreme { get; set; }
  
    }
}
