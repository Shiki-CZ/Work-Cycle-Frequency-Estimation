using Prediction.DataProvider.Models;
using Prediction.DataProvider.QueryBuilders.Abstraction;

namespace Prediction.DataProvider.QueryBuilders
{
    public class VoxelQueryBuilder : QueryBuilder<VoxelQueryBuilder, VoxelModel>
    {
        /*
         * Here is space for specify sorting/filtering methods for VoxelTables like:
         * 
         * public VoxelQueryBuilder WithZGreatherThen(float z) => AddCondition(v=> v.Z > z);
         * 
         */

    }
}
