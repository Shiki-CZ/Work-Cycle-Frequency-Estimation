using CoppeliaSim;
using Prediction.Core.Computing.Abstraction;

namespace Prediction.Core.Computing;

public class CoppeliaFeeder : IDataFeeder
{
    private readonly ICoppeliaSimBase _sim;

    public CoppeliaFeeder(ICoppeliaSimBase sim)
    {
        _sim = sim;
    }

    public int[] GetData()
    {
        if (!_sim.IsConnected)
        {
            _sim.Connect();
            _sim.StartSimulation();
        }

        var res = _sim.CallScriptFunction("OcTree", Simx.ScriptType.ChildScript, "Func",
            new ScriptFunctionData { Ints = new[] { 5, 8, 120 }, Strings = new[] { "Hello c#" } }, Simx.Opmode.OneshotWait);
        return res.Ints;
    }

    //public Task<int[]> GetData()
    //{
    //    return Task.Run(() =>
    //    {
    //        if (!_sim.IsConnected)
    //        {
    //            _sim.Connect();
    //            _sim.StartSimulation();
    //        }

    //        var res = _sim.CallScriptFunction("OcTree", Simx.ScriptType.ChildScript, "Func",
    //            new ScriptFunctionData { Ints = new[] { 5, 8, 120 }, Strings = new[] { "Hello c#" } }, Simx.Opmode.OneshotWait);
    //        return res.Ints;
    //    })!;

}