namespace Chestnut_Pro.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Data;
    using Chestnut_Pro.Model;
    using Chestnut_Pro.Service;

    public class ChartGeneratorViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ChartModel> _data;
        public ObservableCollection<ChartModel> Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public ChartGeneratorViewModel()
        {
            _data = new ObservableCollection<ChartModel>();
            foreach (var line in FileUtils.GetFileContent(AppDomain.CurrentDomain.BaseDirectory + "/Data/sankeydemo.csv"))
            {
                var cols = line.Split(',');
                _data.Add(new ChartModel()
                {
                    Source = cols[0],
                    Destination = cols[1],
                    Value = Convert.ToInt32(cols[2]),
                    Visible = true,
                });
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
