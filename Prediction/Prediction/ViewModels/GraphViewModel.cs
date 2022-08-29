using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Series;
using Prediction.Core.Computing;
using Prediction.Core.Computing.Abstraction;
using Prediction.ViewModels.Abstraction;
using Prediction.Core.Curve.Abstraction;
using Prediction.Core.Curve.Extremes;
using Prediction.DataProvider.Mappers;
using Prediction.DataProvider.QueryBuilders;
using Prediction.Tools;
using Prediction.DataProvider.Repositories.Abstraction;
using SettingsProvider = Prediction.Core.SettingsProvider;

namespace Prediction.ViewModels
{
    internal class GraphViewModel : ViewModelBase
    {
        private readonly IDataSmoother _smoother;
        private readonly IFrequencyComputer _frequencyComputer;
        private readonly IConsole _console;
        private readonly IExtremeRepository _extremeRepository;
        private readonly SettingsProvider _settingsProvider;
        private PlotModel _oxyGraph;
        private int _sliderValue;
        private string _polynomeValue;

        public PlotModel OxyGraph
        {
            get => _oxyGraph;
            private set
            {
                _oxyGraph = value;
            }
        }
        public ICommand ComputeCommand { get; set; }

        public string PolynomeValue
        {
            get => _polynomeValue;
            set
            {
                _polynomeValue = value;
                OnPropertyChanged();
            }
        }

        public int SliderValue
        {
            get => _sliderValue;
            set
            {
                _sliderValue = value;
                PolynomeValue = _sliderValue.ToString();
                _settingsProvider.Poly = _sliderValue;
                OnPropertyChanged();
            }
        }

        private async void Compute()
        {
            _frequencyComputer.Compute();
            //_frequencyComputer.Compute(new DbFeeder());
            //_frequencyComputer.Compute(new CoppeliaFeeder());

            this.OxyGraph = new PlotModel { Title = "Local ExtremesFinder" };
            List<LineSeries> extremes = new List<LineSeries>();

            var mergedExtremes = _frequencyComputer.MergedExtremes;

            var all = await _extremeRepository.All(new ExtremeQueryBuilder(), CancellationToken.None);
            var ids = all.Select(item => item.Id).ToArray();
            await _extremeRepository.DeleteAsync(CancellationToken.None, ids);

            foreach (var item in mergedExtremes)
            {
                var allInDb = await _extremeRepository.Any(q => q.WithTime(item.Time).WithExtremeGroup(item.ExtremeGroup), CancellationToken.None);
                var res = all.Find(dto => dto.Equals(item));
                if (res == null)
                {
                    var guid = await _extremeRepository.CreateAsync(item.ToDto(), CancellationToken.None);
                }
            }

            var dtoList = await _extremeRepository.All(q => q.WithTimeOrMore(8000), CancellationToken.None);

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
                        extremeSeries.Points.Add(new DataPoint(item.Time, item.Value));
                        if (item.Value < min)
                            min = item.Value;
                        if (item.Value > max)
                            max = item.Value;
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

                var maxFrequencyDelimiter = new LineSeries();
                maxFrequencyDelimiter.Color = OxyColors.Red;
                maxFrequencyDelimiter.Points.Add(new DataPoint(_frequencyComputer.FrequencyLocator[0].Time2, 0));
                maxFrequencyDelimiter.Points.Add(new DataPoint(_frequencyComputer.FrequencyLocator[0].Time2, max));
                maxFrequencyDelimiter.StrokeThickness = 3;
                extremes.Add(maxFrequencyDelimiter);

                var minFrequencyDelimiter = new LineSeries();
                minFrequencyDelimiter.Color = OxyColors.Red;
                minFrequencyDelimiter.Points.Add(new DataPoint(_frequencyComputer.FrequencyLocator[0].Time1, 0));
                minFrequencyDelimiter.Points.Add(new DataPoint(_frequencyComputer.FrequencyLocator[0].Time1, max));
                minFrequencyDelimiter.StrokeThickness = 3;
                extremes.Add(minFrequencyDelimiter);

            }
            LineSeries curve = new LineSeries();
            var curveData = _frequencyComputer.CurveData;
            for (int i = 0; i < curveData.Length; i++)
            {
                curve.Points.Add(new DataPoint(i, curveData[i]));
            }


            curve.Color = OxyColors.Black;
            curve.Title = "Smoothed points";

            OxyGraph.Series.Add(curve);
            OxyGraph.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Time [s] x10^-2" });
            OxyGraph.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Voxel Count [-]" });
            OxyGraph.Subtitle = "Number of groups: " + mergedExtremes.Last().ExtremeGroup.ToString();
            foreach (var series in extremes)
            {
                if (series != null)
                {
                    OxyGraph.Series.Add(series);
                    OxyGraph.Legends.Add(new Legend()
                    {
                        LegendTitleColor = series.Color,
                    });
                }
            }
            OnPropertyChanged(nameof(OxyGraph));
            Console();
        }

        private void Console()
        {
            var mainFrequency = _frequencyComputer.FrequencyLocator[0].Frequency.ToString();
            var time1 = _frequencyComputer.FrequencyLocator[0].Time1.ToString();
            var time2 = _frequencyComputer.FrequencyLocator[0].Time2.ToString();
            var period = _frequencyComputer.FrequencyLocator[0].Period.ToString();
            var group = _frequencyComputer.FrequencyLocator[0].FrequencyGroup.ToString();
            _console.AddLine("Main Frequency: " + mainFrequency + "\n" +
                             "Time 1: " + time1 + "\n" +
                             "Time 2: " + time2 + "\n" +
                             "Period: " + period + "\n" +
                             "Found in group: " + group);

        }
        private void SetVal()
        {

        }

        public GraphViewModel(IDataSmoother smoother,
            IFrequencyComputer frequencyComputer,
            IConsole console,
            ICommandFactory commandFactory,
            IExtremeRepository extremeRepository,
            SettingsProvider settingsProvider)
        {
            _smoother = smoother;
            _frequencyComputer = frequencyComputer;
            _console = console;
            _extremeRepository = extremeRepository;
            _settingsProvider = settingsProvider;
            ComputeCommand = commandFactory.Create(Compute);
        }

        private double Test(double input)
        {
            return 0;
        }
    }
}
