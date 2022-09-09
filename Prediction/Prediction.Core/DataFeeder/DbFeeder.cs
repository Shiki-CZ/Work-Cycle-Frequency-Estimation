using Prediction.Core.Computing.Abstraction;
using Prediction.DataProvider.QueryBuilders;
using Prediction.DataProvider.Repositories.Abstraction;

namespace Prediction.Core.Computing;

public class DbFeeder : IDataFeeder
{
    public IExtremeRepository ExtremeRepository { get; set; }

    public DbFeeder()
    {
    }


    public int[] GetData()
    {
        //var data = await ExtremeRepository.All(new ExtremeQueryBuilder(), CancellationToken.None);
        //var res = data.Select(d => d.Value).ToArray();
        //return res;
        throw new NotImplementedException();
    }
}
