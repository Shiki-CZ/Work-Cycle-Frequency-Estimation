using Prediction.DataProvider.Abstraction;
using Prediction.DataProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prediction.DataProvider.Dto
{
    public class VoxelDto : IDto
    {
        public Guid Id { get; set; }

        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }
    }
}
