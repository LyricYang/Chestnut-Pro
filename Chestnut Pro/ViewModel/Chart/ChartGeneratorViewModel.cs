namespace Chestnut_Pro.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Windows.Input;
    using Chestnut_Pro.Model;
    using Chestnut_Pro.Service;
    using Microsoft.Win32;

    /// <summary>
    /// Chart Generator View Model
    /// </summary>
    public class ChartGeneratorViewModel : ViewModelBase
    {
        /// <summary>
        /// The Constructor
        /// </summary>
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

        private ObservableCollection<ChartModel> _data;

        /// <summary>
        /// Data Source
        /// </summary>
        public ObservableCollection<ChartModel> Data
        {
            get { return _data; }
            set { _data = value; OnPropertyChanged(); }
        }

        private bool _clearChecked;

        /// <summary>
        /// Clear property
        /// </summary>
        public bool ClearChecked { get { return _clearChecked; } set { _clearChecked = value; OnPropertyChanged(); } }

        private string _fileText;

        /// <summary>
        /// FileText
        /// </summary>
        public string FileText
        {
            get { return _fileText; }
            set { _fileText = value; OnPropertyChanged(); }
        }

        private WarningMessage _message;

        /// <summary>
        /// Warning Message
        /// </summary>
        public WarningMessage Message
        {
            get { return _message; }
            set { _message = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Clear Command
        /// </summary>
        private ICommand _clearCommand;

        public ICommand ClearCommand => _clearCommand ?? (_clearCommand = new RelayCommand(param => Clear(param)));

        /// <summary>
        /// Select All Command
        /// </summary>
        private ICommand _selectAllCommand;

        public ICommand SelectAllCommand => _selectAllCommand ?? (_selectAllCommand = new RelayCommand(param => SelectAll(param)));

        /// <summary>
        /// Select All Command
        /// </summary>
        private ICommand _browserCommand;

        public ICommand BrowserCommand => _browserCommand ?? (_browserCommand = new RelayCommand(param => BrowseFile(param)));

        /// <summary>
        /// Clear Method
        /// </summary>
        /// <param name="parameter"></param>
        private void Clear(object? parameter)
        {
            Data.Clear();
            ClearChecked = false;
        }

        /// <summary>
        /// Select All
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectAll(object? parameter)
        {
            var check = Convert.ToBoolean(parameter ?? "False");
            foreach (var item in Data)
            {
                if (check)
                {
                    item.Visible = true;
                }
                else
                {
                    item.Visible = false;
                }
            }
        }

        /// <summary>
        /// Browse file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrowseFile(object? parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var file = openFileDialog.FileName;
                if (Path.GetExtension(file) == ".csv")
                {
                    Message = new WarningMessage();
                    FileText = file;
                    var source = new ObservableCollection<ChartModel>();
                    foreach (var row in FileUtils.GetFileContent(file))
                    {
                        var cols = row.Split(',');
                        source.Add(new ChartModel()
                        {
                            Source = cols[0],
                            Destination = cols[1],
                            Value = Convert.ToInt32(cols[2]),
                            Visible = true,
                        });
                    }

                    Data = source;
                }
                else
                {
                    Message = new WarningMessage(true, "File types other than .csv are not supported!");
                }
            }
        }
    }
}
