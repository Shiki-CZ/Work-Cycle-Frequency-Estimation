using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Series;
using Prediction.Core.Computing.Abstraction;
using Prediction.Core.Curve.Abstraction;
using Prediction.Core.Curve.Extremes.Abstraction;
using Prediction.Core.Grouping;
using Prediction.Core.Grouping.Abstraction;
using Prediction.Tools;
using Prediction.ViewModels.Abstraction;

namespace Prediction.ViewModels
{
    internal class TabTestViewModel : ViewModelBase
    {

        private readonly IFrequencyComputer _frequencyComputer;
        private readonly IConsole _console;
        private PlotModel _oxyGraph_2;

        public PlotModel OxyGraph_2
        {
            get => _oxyGraph_2;
            private set
            {
                _oxyGraph_2 = value;
            }
        }

        public ICommand ComputeCommand2 { get; set; }

        private void Compute()
        {
            _frequencyComputer.Compute();

            this.OxyGraph_2 = new PlotModel { Title = "Frequencies" };
            LineSeries curve = new LineSeries();
            //LineSeries extremes = new LineSeries();
            //series.MarkerType = MarkerType.Circle;
            //series.LineStyle = LineStyle.None;

            var curveData = _frequencyComputer.CurveData;
            for (int i = 0; i < curveData.Length; i++)
            {
                curve.Points.Add(new DataPoint(i, curveData[i]));
            }

            var mergedExtremes = _frequencyComputer.MergedExtremes;
            var freq = _frequencyComputer.Frequency;

            ////////////////////////////////////////////  CONSOLE  ///////////////////////////////////////  CONSOLE  ///////////////////////////////  CONSOLE  //////////////
            _console.AddLine("frequency: ");
            var count = _frequencyComputer.MainFrequency;
            var msg1 = count.Select(value => value.ToString()).ToList();
            _console.AddLine(msg1[0]);
            ////////////////////////////////////////////  CONSOLE  ///////////////////////////////////////  CONSOLE  ///////////////////////////////  CONSOLE  ///////////////

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
                extremeSeries.Title = "Frequency Group " + group.ToString();

                foreach (var item in freq)
                {
                    if (group + 1 == item.FrequencyGroup)
                    {
                        extremeSeries.Points.Add(new DataPoint(item.Period, item.FrequencyGroup));
                    }
                }
                
                extremes.Add(extremeSeries);

            }

            OxyGraph_2.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Frequencies" });
            OxyGraph_2.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Frequency group" });
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
            OnPropertyChanged(nameof(OxyGraph_2));
        }



        public TabTestViewModel(IFrequencyComputer frequencyComputer, IConsole console, ICommandFactory commandFactory)
        {
            _frequencyComputer = frequencyComputer;
            _console = console;
            ComputeCommand2 = commandFactory.Create(Compute);
        }

        private double Test(double input)
        {
            return 0;
        }
    }
}
