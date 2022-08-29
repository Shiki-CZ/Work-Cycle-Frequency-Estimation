using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prediction.DataProvider.Dto;
using Prediction.DataProvider.Mappers;
using Prediction.DataProvider.Models;
using Prediction.DataProvider.QueryBuilders;
using Prediction.DataProvider.Repositories.Abstraction;
using Prediction.DataProvider.Repositories.Base;

namespace Prediction.DataProvider.Repositories
{
    public class ExtremeRepository : QueryableRepository<ExtremeQueryBuilder, ExtremeModel, ExtremeDto>, IExtremeRepository
    {
        public ExtremeRepository(CustomDbContext dbContext) : base(dbContext)
        {
        }

        protected override ExtremeModel MapToModel(ExtremeDto dto) => dto.ToModel();

        protected override ExtremeDto MapToDto(ExtremeModel model) => model.ToDto();

    }
}
