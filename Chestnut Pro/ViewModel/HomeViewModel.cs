
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Media;
using Chestnut_Pro.Model;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace Chestnut_Pro.ViewModel
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public SeriesCollection SeriesCollection { get; set; }
        public SeriesCollection LastHourSeries { get; set; }
        public SeriesCollection LastHourSeries1 { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        // 86572.91 84577.91
        // 5897.46 7191.93 6614.49 5690.72 7117.13 6212.27 4877.82 7633.65 6799.73 11348.03 9189.2 800.48
        public HomeViewModel()
        {
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Overhead",
                    Stroke = Brushes.OrangeRed,
                    StrokeThickness = 2,
                    Fill = Brushes.Transparent,
                    PointGeometrySize = 10,
                    LineSmoothness = 1,
                    StrokeDashArray = new DoubleCollection { 2 },
                    Values = new ChartValues<ObservableValue>
                    {
                        new ObservableValue(6992.89),
                        new ObservableValue(8856.19),
                        new ObservableValue(5750.08),
                        new ObservableValue(5969.52),
                        new ObservableValue(6189.59),
                        new ObservableValue(4548.58),
                        new ObservableValue(5185.10),
                        new ObservableValue(4989.02),
                        new ObservableValue(12558.03),
                        new ObservableValue(8708.08),
                        new ObservableValue(7514.01),
                        new ObservableValue(7320.82),
                    }
                },
                new LineSeries
                {
                    Title = "Salary",
                    Stroke = Brushes.Blue,
                    StrokeThickness = 2,
                    Fill = Brushes.Transparent,
                    PointGeometrySize = 10,
                    LineSmoothness = 1,
                    Values = new ChartValues<ObservableValue>
                    {
                        new ObservableValue(18247.92),
                        new ObservableValue(28133.94),
                        new ObservableValue(31512.46),
                        new ObservableValue(22512.46),
                        new ObservableValue(15003.01),
                        new ObservableValue(41190.31),
                        new ObservableValue(18202.01),
                        new ObservableValue(17757.29),
                        new ObservableValue(17377.81),
                        new ObservableValue(17557.81),
                        new ObservableValue(17377.80),
                        new ObservableValue(17377.81),
                    }
                }
            };
            LastHourSeries = new SeriesCollection
            {
                new LineSeries
                {
                    AreaLimit = -10,
                    Values = new ChartValues<ObservableValue>
                    {
                        new ObservableValue(3),
                        new ObservableValue(1),
                        new ObservableValue(9),
                        new ObservableValue(4),
                        new ObservableValue(5),
                        new ObservableValue(3),
                        new ObservableValue(1),
                        new ObservableValue(2),
                        new ObservableValue(3),
                        new ObservableValue(7),
                    }
                }
            };
            LastHourSeries1 = new SeriesCollection
            {
                new LineSeries
                {
                    AreaLimit = -10,
                    Values = new ChartValues<ObservableValue>
                    {
                        new ObservableValue(13),
                        new ObservableValue(11),
                        new ObservableValue(9),
                        new ObservableValue(14),
                        new ObservableValue(5),
                        new ObservableValue(3),
                        new ObservableValue(12),
                        new ObservableValue(2),
                        new ObservableValue(3),
                        new ObservableValue(7),
                    }
                }
            };
            Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", " Aug", "Sep", "Oct", "Nov", "Dec"};
            Formatter = value => value.ToString();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }

}