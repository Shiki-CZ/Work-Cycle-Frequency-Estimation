using Prediction.DataProvider.Dto;
using Prediction.DataProvider.Models;
using Prediction.DataProvider.QueryBuilders;
using Prediction.DataProvider.Repositories.Abstraction;
using Prediction.DataProvider.Repositories.Base;

namespace Prediction.DataProvider.Repositories
{
    public class VoxelRepository : QueryableRepository<VoxelQueryBuilder, VoxelModel, VoxelDto>, IVoxelRepository
    {
        public VoxelRepository(CustomDbContext dbContext) : base(dbContext)
        {
        }

        protected override VoxelModel MapToModel(VoxelDto dto)
        {
            return new VoxelModel
            {
                Id = dto.Id,
                X = dto.X,
                Y = dto.Y,
                Z = dto.Z,
            };
        }

        protected override VoxelDto MapToDto(VoxelModel model)
        {
            return new VoxelDto
            {
                Id = model.Id,
                X = model.X,
                Y = model.Y,
                Z = model.Z,
            };

        }
    }
}