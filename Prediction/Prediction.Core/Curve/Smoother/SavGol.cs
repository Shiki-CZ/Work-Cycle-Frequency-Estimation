using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CenterSpace.NMath.Core;
using Prediction.Core.Curve.Abstraction;

namespace Prediction.Core.Curve;

public class SavGol : IDataSmoother
{
    public float[] Smooth(int[] data, int polynome, int smoothRange)
    {
        int numberLeft = smoothRange;
        int numberRight = smoothRange;

        SavitzkyGolayFilter sgf = new SavitzkyGolayFilter(numberLeft, numberRight, polynome);
        DoubleVector input = new DoubleVector();
        foreach (var item in data)
        {
            input.Append(item);
        }
        DoubleVector output = new DoubleVector();
        sgf.Filter(input, ref output);

        var result = new int[output.Length];

        var floats = output.Select(item => (float)item).ToArray();

        return floats;

    }
}