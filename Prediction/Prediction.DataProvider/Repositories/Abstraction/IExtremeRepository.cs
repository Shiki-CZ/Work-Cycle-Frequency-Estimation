using Prediction.DataProvider.Dto;
using Prediction.DataProvider.QueryBuilders;

namespace Prediction.DataProvider.Repositories.Abstraction;

public interface IExtremeRepository : IQueryableRepository<ExtremeQueryBuilder, ExtremeDto>
{
}