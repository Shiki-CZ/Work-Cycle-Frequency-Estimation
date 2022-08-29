using Prediction.DataProvider.Dto;
using Prediction.DataProvider.QueryBuilders;
using Prediction.DataProvider.Repositories.Abstraction;

namespace Prediction.DataProvider.Repositories.Abstraction
{
    public interface IVoxelRepository : IQueryableRepository<VoxelQueryBuilder, VoxelDto>
    {
    }
}