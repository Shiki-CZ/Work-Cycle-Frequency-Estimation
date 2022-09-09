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
using Prediction.Tools;
using Prediction.ViewModels.Abstraction;

namespace Prediction.ViewModels
{
    internal class PeriodGraphViewModel : ViewModelBase
    {

        private readonly IComputer _computer;
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

        private Task Compute()
        {
            return Task.Run(() =>
             {
                 _computer.Compute();

                 this.OxyGraph_2 = new PlotModel { Title = "Period Counter" };
                 LineSeries curve = new LineSeries();
                //LineSeries extremes = new LineSeries();
                //series.MarkerType = MarkerType.Circle;
                //series.LineStyle = LineStyle.None;

                var curveData = _computer.CurveData;
                 for (int i = 0; i < curveData.Length; i++)
                 {
                     curve.Points.Add(new DataPoint(i, curveData[i]));
                 }

                 var mergedExtremes = _computer.MergedExtremes;
                 var freq = _computer.Frequency;

                ////////////////////////////////////////////  CONSOLE  ///////////////////////////////////////  CONSOLE  ///////////////////////////////  CONSOLE  //////////////
                _console.AddLine("frequency: ");
                 var count = _computer.MainFrequency;
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
                     extremeSeries.Title = "Period Group " + group.ToString();

                     foreach (var item in freq)
                     {
                         if (group + 1 == item.FrequencyGroup)
                         {
                             extremeSeries.Points.Add(new DataPoint(item.Period, item.FrequencyGroup));
                         }
                     }

                     extremes.Add(extremeSeries);

                     var minFrequencyDelimiter = new LineSeries();
                     minFrequencyDelimiter.Color = OxyColors.Red;
                     minFrequencyDelimiter.Points.Add(new DataPoint(_computer.FrequencyLocator[0].Period, 0));
                     minFrequencyDelimiter.Points.Add(new DataPoint(_computer.FrequencyLocator[0].Period, group + 1));
                     minFrequencyDelimiter.StrokeThickness = 3;
                     extremes.Add(minFrequencyDelimiter);

                 }

                 OxyGraph_2.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Periods" });
                 OxyGraph_2.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Period group" });
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
             });
        }



        public PeriodGraphViewModel(IComputer computer, IConsole console, ICommandFactory commandFactory)
        {
            _computer = computer;
            _console = console;
            ComputeCommand2 = commandFactory.Create(Compute);
        }

        private double Test(double input)
        {
            return 0;
        }
    }
}
