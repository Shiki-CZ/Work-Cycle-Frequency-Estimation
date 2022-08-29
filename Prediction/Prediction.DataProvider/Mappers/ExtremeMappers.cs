using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prediction.DataProvider.Dto;
using Prediction.DataProvider.Models;

namespace Prediction.DataProvider.Mappers
{
    public static class ExtremeMappers
    {
        public static ExtremeModel ToModel(this ExtremeDto dto)
        {
            return new ExtremeModel
            {
                Id = dto.Id,
                Time = dto.Time,
                ExtremeGroup = dto.ExtremeGroup,
                MergeExtreme = dto.MergeExtreme,
                Value = dto.Value
            };
        }

        public static  ExtremeDto ToDto(this ExtremeModel model)
        {
            return new ExtremeDto
            {
                Id = model.Id,
                Time = model.Time,
                ExtremeGroup = model.ExtremeGroup,
                MergeExtreme = model.MergeExtreme,
                Value = model.Value
            };
        }

        public static bool Equals(this ExtremeDto a, ExtremeDto b)
        {
            if (a.MergeExtreme != b.MergeExtreme) return false;
            if (Math.Abs(a.Value - b.Value) > 0.001) return false;
            if (a.ExtremeGroup != b.ExtremeGroup) return false;
            return a.Time == b.Time;
        }
    }
}
