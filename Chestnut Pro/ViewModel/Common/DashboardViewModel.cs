namespace Chestnut_Pro.ViewModel
{
    using System;
    using System.ComponentModel;
    using System.Windows.Media;
    using Chestnut_Pro.Service;
    using Chestnut_Pro.Service.Common;
    using LiveCharts;
    using LiveCharts.Defaults;
    using LiveCharts.Wpf;

    /// <summary>
    /// Dashboard View Model
    /// </summary>
    public class DashboardViewModel : INotifyPropertyChanged
    {
        public SeriesCollection SeriesCollection { get; set; }
        public SeriesCollection LastHourSeries { get; set; }
        public SeriesCollection LastHourSeries1 { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }


        public DashboardViewModel()
        {
            dynamic data = FileUtils.ReadJsonFile(AppDomain.CurrentDomain.BaseDirectory + Constants.JSON_DATA_FILE_PATH);
            // overhead
            var overhead = new ChartValues<ObservableValue>();
            foreach (var monVal in data.Data.Expenditure.Year2021.Month)
            {
                overhead.Add(new ObservableValue(monVal.Value));
            }
            // salary
            var salary = new ChartValues<ObservableValue>();
            foreach (var monVal in data.Data.Income.Year2021.Month)
            {
                salary.Add(new ObservableValue(monVal.Value));
            }

            // Income and Expenditure
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
                    Values = overhead,
                },
                new LineSeries
                {
                    Title = "Salary",
                    Stroke = Brushes.Blue,
                    StrokeThickness = 2,
                    Fill = Brushes.Transparent,
                    PointGeometrySize = 10,
                    LineSmoothness = 1,
                    Values = salary
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