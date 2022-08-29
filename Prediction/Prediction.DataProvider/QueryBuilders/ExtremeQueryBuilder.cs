using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prediction.DataProvider.Dto;
using Prediction.DataProvider.Mappers;
using Prediction.DataProvider.Models;
using Prediction.DataProvider.QueryBuilders.Abstraction;

namespace Prediction.DataProvider.QueryBuilders
{
    public class ExtremeQueryBuilder : QueryBuilder<ExtremeQueryBuilder, ExtremeModel>
    {
        public ExtremeQueryBuilder WithTimeOrMore(int time) => AddCondition(m => m.Time > time);
        public ExtremeQueryBuilder Equal(ExtremeDto dto) => AddCondition((m) =>
            dto.MergeExtreme == m.MergeExtreme &&
            dto.Value == m.Value &&
            dto.ExtremeGroup == m.ExtremeGroup &&
            dto.Time == m.Time);

        public ExtremeQueryBuilder WithTime(int time) => AddCondition(m => m.Time == time);
        public ExtremeQueryBuilder WithExtremeGroup(int group) => AddCondition(m => m.ExtremeGroup == group);
        public ExtremeQueryBuilder WithValue(float value) => AddCondition(m => m.Value == value);
    }
}
