using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Series;
using Prediction.Core.Curve.Abstraction;
using Prediction.Core.Curve.Extremes.Abstraction;
using Prediction.Core.Grouping.Abstraction;
using Prediction.Tools;
using Prediction.ViewModels.Abstraction;

namespace Prediction.ViewModels
{
    internal class TabTestViewModel : ViewModelBase
    {

        private readonly IConsole _console;
        private PlotModel _oxyGraph_2;

        public PlotModel OxyGraph_2
        {
            get => _oxyGraph_2;
            private set
            {
                _oxyGraph_2 = value;
                OnPropertyChanged();
            }
        }

        private int[] Data = new int[]
            {
                24, 24, 26, 22, 20, 22, 24, 30, 25, 24, 30, 30, 30, 34, 36, 38, 44, 46, 45, 46, 48, 50, 52, 52, 56, 56,
                56,
                56, 52, 52, 52, 48, 46, 48, 44, 40, 36, 28, 24, 22, 22, 20, 16, 16, 10, 8, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6,
                6,
                6, 8, 8, 12, 14, 12, 14, 14, 18, 28, 28, 40, 48, 50, 60, 56, 60, 62, 60, 58, 66, 72, 74, 66, 62, 64, 66,
                70, 70, 72, 72, 70, 66, 64, 64, 62, 66, 68, 74, 74, 66, 64, 60, 66, 62, 64, 64, 60, 54, 60, 58, 54, 58,
                52,
                48, 48, 50, 44, 44, 50, 52, 52, 52, 56, 56, 62, 62, 66, 68, 70, 70, 70, 72, 76, 78, 78, 78, 78, 78, 78,
                78,
                78, 74, 74, 74, 72, 68, 65, 64, 62, 62, 62, 62, 58, 54, 48, 52, 50, 48, 46, 40, 38, 34, 40, 34, 32, 30,
                30,
                28, 26, 30, 30, 26, 24, 22, 20, 20, 20, 18, 18, 18, 18, 18, 18, 18, 16, 16, 16, 16, 16, 16, 16, 16, 16,
                16,
                16, 16, 16, 14, 14, 14, 14, 16, 14, 14, 12, 13, 19, 52, 74, 94, 118, 142, 156, 188, 209, 225, 239, 221,
                245, 231, 242, 235, 231, 258, 259, 242, 244, 216, 178, 151, 119, 92, 60, 56, 54, 54, 52, 56, 56, 56, 56,
                52, 52, 50, 48, 44, 44, 44, 44, 40, 36, 32, 30, 30, 28, 26, 26, 30, 26, 24, 20, 26, 24, 24, 24, 22, 26,
                28,
                28, 28, 28, 30, 30, 32, 34, 34, 36, 36, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 32, 34, 32, 30, 30,
                30,
                28, 28, 28, 24, 22, 24, 24, 26, 22, 20, 22, 24, 30, 25, 24, 30, 30, 30, 34, 36, 38, 44, 46, 45, 46, 48,
                50,
                52, 52, 56, 56, 56, 56, 52, 52, 52, 48, 46, 48, 44, 40, 36, 28, 24, 22, 22, 20, 16, 16, 10, 8, 6, 6, 6,
                6,
                6, 6, 6, 6, 6, 6, 6, 8, 8, 12, 14, 12, 14, 14, 18, 28, 28, 40, 48, 50, 60, 56, 60, 62, 60, 58, 66, 72,
                74,
                66, 62, 64, 66, 70, 70, 72, 72, 70, 66, 64, 64, 62, 66, 68, 74, 74, 66, 64, 60, 66, 62, 64, 64, 60, 54,
                60,
                58, 54, 58, 52, 48, 48, 50, 44, 44, 50, 52, 52, 52, 56, 56, 62, 62, 66, 68, 70, 70, 70, 72, 76, 78, 78,
                78,
                78, 78, 78, 78, 78, 74, 74, 74, 72, 68, 65, 64, 62, 62, 62, 62, 58, 54, 48, 52, 50, 48, 46, 40, 38, 34,
                40,
                34, 32, 30, 30, 28, 26, 30, 30, 26, 24, 22, 20, 20, 20, 18, 18, 18, 18, 18, 18, 18, 16, 16, 16, 16, 16,
                16,
                16, 16, 16, 16, 16, 16, 16, 14, 14, 14, 14, 16, 14, 14, 12, 12, 14, 16, 14, 14, 22, 27, 48, 76, 96, 127,
                139, 171, 217, 226, 236, 239, 231, 257, 241, 259, 256, 252, 254, 239, 238, 218, 192, 180, 155, 120, 112,
                97, 64, 62, 56, 52, 52, 50, 48, 44, 44, 44, 44, 40, 36, 32, 30, 30, 28, 26, 26, 30, 26, 24, 20, 26, 24,
                24,
                24, 22, 26, 28, 28, 28, 28, 30, 30, 32, 34, 34, 36, 36, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 32, 34,
                32,
                30, 30, 30, 28, 28, 28, 24, 22, 24, 24, 26, 22, 20, 22, 24, 30, 25, 24, 30, 30, 30, 34, 36, 38, 44, 46,
                45,
                46, 48, 50, 52, 52, 56, 56, 56, 56, 56, 52, 52, 52, 48, 46, 48, 44, 40, 36, 28, 24, 22, 22, 20, 16, 16,
                10,
                8, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 8, 8, 12, 14, 12, 14, 14, 18, 28, 28, 40, 48, 50, 60, 56, 60, 62,
                60,
                58, 66, 72, 74, 66, 62, 64, 66, 70, 70, 72, 72, 70, 66, 64, 64, 62, 66, 68, 74, 74, 66, 64, 60, 66, 62,
                64,
                64, 60, 54, 60, 58, 54, 58, 52, 48, 48, 50, 44, 44, 50, 52, 52, 52, 56, 56, 62, 62, 66, 68, 70, 70, 70,
                72,
                76, 78, 78, 78, 78, 78, 78, 78, 78, 74, 74, 74, 72, 68, 65, 64, 62, 62, 62, 62, 58, 54, 48, 52, 50, 48,
                46,
                40, 38, 34, 40, 34, 32, 30, 30, 28, 26, 30, 30, 26, 24, 22, 20, 20, 20, 18, 18, 18, 18, 18, 18, 18, 16,
                16,
                16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 14, 14, 14, 14, 16, 14, 14, 12, 12, 14, 16, 14, 14, 16,
                16,
                26, 39, 63, 98, 122, 157, 195, 225, 242, 222, 244, 255, 241, 255, 236, 236, 248, 238, 260, 259, 250,
                246,
                235, 194, 180, 172, 141, 113, 71, 60, 58, 54, 48, 44, 44, 44, 44, 40, 36, 32, 30, 30, 28, 26, 26, 30,
                26,
                24, 20, 26, 24, 24, 24, 22, 26, 28, 28, 28, 28, 30, 30, 32, 34, 34, 36, 36, 34, 34, 34, 34, 34, 34, 34,
                34,
                34, 34, 32, 34, 32, 30, 30, 30, 28, 28, 28, 24, 22, 24, 24, 26, 22, 20, 22, 24, 30, 25, 24, 30, 30, 30,
                34,
                36, 38, 44, 46, 45, 46, 48, 50, 52, 52, 56, 56, 56, 56, 52, 52, 52, 48, 46, 48, 44, 40, 36, 28, 24, 22,
                22,
                20, 16, 16, 10, 8, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 8, 8, 12, 14, 12, 14, 14, 18, 28, 28, 40, 48, 50,
                60, 56, 60, 62, 60, 58, 66, 72, 74, 66, 62, 64, 66, 70, 70, 72, 72, 72, 70, 66, 64, 64, 62, 66, 68, 74,
                74,
                66, 64, 60, 66, 62, 64, 64, 60, 54, 60, 58, 54, 58, 52, 48, 48, 50, 44, 44, 50, 52, 52, 52, 56, 56, 62,
                62,
                66, 68, 70, 70, 70, 72, 76, 78, 78, 78, 78, 78, 78, 78, 78, 74, 74, 74, 72, 68, 65, 64, 62, 62, 62, 62,
                58,
                54, 48, 52, 50, 48, 46, 40, 38, 34, 40, 34, 32, 30, 30, 28, 26, 30, 30, 26, 24, 22, 20, 20, 20, 18, 18,
                18,
                18, 18, 18, 18, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 14, 14, 14, 14, 16, 14, 14, 12,
                12,
                14, 16, 14, 14, 16, 22, 29, 51, 79, 125, 134, 169, 200, 220, 225, 228, 233, 243, 233, 251, 241, 235,
                256,
                256, 251, 271, 262, 253, 253, 239, 205, 184, 141, 95, 71, 64, 58, 54, 48, 44, 44, 44, 44, 40, 36, 32,
                30,
                30, 28, 26, 26, 30, 26, 24, 20, 26, 24, 24, 24, 22, 26, 28, 28, 28, 28, 30, 30, 32, 34, 34, 36, 36, 34,
                34,
                34, 34, 34, 34, 34, 34, 34, 34, 34, 32, 34, 32, 30, 30, 30, 28, 28, 28, 24, 22, 24, 24, 26, 22, 20, 22,
                24,
                30, 25, 24, 30, 30, 30, 34, 36, 38, 44, 46, 45, 46, 48, 50, 52, 52, 56, 56, 56, 56, 52, 52, 52, 48, 46,
                48,
                44, 40, 36, 28, 24, 22, 22, 20, 16, 16, 10, 8, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 8
            };

        public TabTestViewModel(IDataSmoother smoother, IExtremes extreme, IConsole console, IToFrequency frequency)
        {
            _console = console;
            this.OxyGraph_2 = new PlotModel { Title = "Local Extremes" };
            LineSeries curve = new LineSeries();
            //LineSeries extremes = new LineSeries();
            //series.MarkerType = MarkerType.Circle;
            //series.LineStyle = LineStyle.None;

            var curveData = smoother.Smooth(Data);
            for (int i = 0; i < Data.Length; i++)
            {
                curve.Points.Add(new DataPoint(i, curveData[i]));
            }
            
            var extremeData = extreme.LocalMaximas(curveData);
            var extremeGroup = extreme.ExtremeGroups(extremeData);
            var mergedExtremes = extreme.MergeExtreme(extremeGroup);
            var freq = frequency.GetFrequencies(mergedExtremes, 0.1f);
            //Console.WriteLine("mergedExtremes");

            ////////////////////////////////////////////  CONSOLE  ///////////////////////////////////////  CONSOLE  ///////////////////////////////  CONSOLE  //////////////
            var msg1 = mergedExtremes.Select(value => value.MergeExtreme.ToString()).ToList();
            var msg2 = mergedExtremes.Select(value => value.Extreme.ToString()).ToList();
            var msg3 = mergedExtremes.Select(value => value.ExtremeGroup.ToString()).ToList();
            var msg4 = mergedExtremes.Select(value => value.Time.ToString()).ToList();
            int cnt = 0;
            foreach (var line in msg1)
            {
                _console.AddLine("Merged extremes: " + line + "     " + "Extreme: " + msg2[cnt] + "    " +
                                 "Group: " + msg3[cnt] + "     " + "Time: " + msg4[cnt]);
                cnt++;
            }
            _console.AddLine(cnt.ToString());

            var freq1 = freq.Select(value => value.Time1.ToString()).ToList();
            var freq2 = freq.Select(value => value.Time2.ToString()).ToList();
            var freq3 = freq.Select(value => value.Frequency.ToString()).ToList();
            var freq4 = freq.Select(value => value.FrequencyGroup.ToString()).ToList();
            int cnt2 = 0;

            foreach (var line in freq1)
            {
                _console.AddLine("Time1: " + line + "     " + "Time2: " + freq2[cnt2] + "    " +
                                 "Frequency: " + freq3[cnt2] + "     " + "Group: " + freq4[cnt2]);
                cnt2++;
            }
            _console.AddLine(cnt2.ToString());

            var freq5 = freq.OrderBy(frequency => frequency.Frequency).ToArray();
            var freq51 = freq5.Select(value => value.Frequency).ToList();

            foreach (var lines in freq51)
            {
                float num = 1 / lines;
                num.ToString();
                _console.AddLine("frequency: " + num);
            }
            ////////////////////////////////////////////  CONSOLE  ///////////////////////////////////////  CONSOLE  //////////////////////////////  CONSOLE  ///////////////
            
            List<LineSeries> extremes = new List<LineSeries>();

            int colorMax = mergedExtremes.Last().ExtremeGroup;
            float colorStep = 255 / colorMax;

            List<OxyColor> colors = new List<OxyColor>();

            for (int colorNumber = 0; colorNumber < colorMax; colorNumber++)
            {
                double r = 255 * (((-Math.Cos(colorNumber * (Math.PI / colorMax))) / 2) + 0.5);
                double g = 255 * (Math.Sin(colorNumber * (Math.PI / colorMax)));
                double b = 255 * (((Math.Cos(colorNumber * (Math.PI / colorMax))) / 2) + 0.5);
                colors.Add(OxyColor.FromRgb((byte)r, (byte)g, (byte)b));
            }

            for (int group = 0; group < mergedExtremes.Last().ExtremeGroup; group++)
            {

                if (colors.Count == group)
                {
                    break;
                }

                var extremeSeries = new LineSeries();
                extremeSeries.MarkerType = MarkerType.Circle;
                extremeSeries.LineStyle = LineStyle.None;
                extremeSeries.Color = colors[group];
                extremeSeries.Title = "Extremes Group " + group.ToString();
                float min = 1000;
                float max = -1;
                float time = 0;
                foreach (var item in mergedExtremes)
                {
                    if (group + 1 == item.ExtremeGroup && item.MergeExtreme == false)
                    {
                        extremeSeries.Points.Add(new DataPoint(item.Time, item.Extreme));
                        if (item.Extreme < min)
                            min = item.Extreme;
                        if (item.Extreme > max)
                            max = item.Extreme;
                    }
                    if (item.Time > time)
                        time = item.Time;
                }

                extremes.Add(extremeSeries);
                var maxLineDelimiter = new LineSeries();
                maxLineDelimiter.Color = colors[group];
                maxLineDelimiter.Points.Add(new DataPoint(0, max));
                maxLineDelimiter.Points.Add(new DataPoint(time, max));
                maxLineDelimiter.StrokeThickness = 1;
                extremes.Add(maxLineDelimiter);

                var minLineDelimiter = new LineSeries();
                minLineDelimiter.Color = colors[group];
                minLineDelimiter.Points.Add(new DataPoint(0, min));
                minLineDelimiter.Points.Add(new DataPoint(time, min));
                minLineDelimiter.StrokeThickness = 1;
                extremes.Add(minLineDelimiter);

            }

            curve.Color = OxyColors.Black;
            curve.Title = "Smoothed points";

            OxyGraph_2.Series.Add(curve);
            OxyGraph_2.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Time [s] x10^2" });
            OxyGraph_2.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Frequencies" });
            OxyGraph_2.Subtitle = "Number of groups: " + mergedExtremes.Last().ExtremeGroup.ToString();
            foreach (var series in extremes)
            {
                if (series != null)
                {
                    OxyGraph_2.Series.Add(series);
                    OxyGraph_2.Legends.Add(new Legend()
                    {
                        LegendTitleColor = series.Color,
                    });
                }
            }
        }

        private double Test(double input)
        {
            return 0;
        }
    }
}
