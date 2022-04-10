namespace Chestnut_Pro.ViewModel
{
    using Chestnut_Pro.Model;
    using Chestnut_Pro.Service;
    using Microsoft.Win32;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Input;

    /// <summary>
    /// TSV CSV Converter View Model
    /// </summary>
    public class TSVCSVViewModel : ViewModelBase
    {
        private const string TSV = ".tsv";
        private const string CSV = ".csv";

        private WarningMessage _message;

        /// <summary>
        /// Warning Message
        /// </summary>
        public WarningMessage Message
        {
            get { return _message; }
            set { _message = value; OnPropertyChanged(); }
        }

        private string _tsvVisible;

        /// <summary>
        /// TSV Visible
        /// </summary>
        public string TSVVisible
        {
            get { return _tsvVisible; }
            set { _tsvVisible = value; OnPropertyChanged(); }
        }

        private string _csvVisible;

        /// <summary>
        /// CSV Visible
        /// </summary>
        public string CSVVisible
        {
            get { return _csvVisible; }
            set { _csvVisible = value; OnPropertyChanged(); }
        }

        private string _tsvText;

        /// <summary>
        /// TSV Text
        /// </summary>
        public string TSVText
        {
            get { return _tsvText; }
            set { _tsvText = value; OnPropertyChanged(); }
        }

        private string _csvText;

        /// <summary>
        /// CSV Text
        /// </summary>
        public string CSVText
        {
            get { return _csvText; }
            set { _csvText = value; OnPropertyChanged(); }
        }

        private string _tsvFileText;

        /// <summary>
        /// CSV Text
        /// </summary>
        public string TSVFileText
        {
            get { return _tsvFileText; }
            set { _tsvFileText = value; OnPropertyChanged(); }
        }

        private string _csvFileText;

        /// <summary>
        /// CSV Text
        /// </summary>
        public string CSVFileText
        {
            get { return _csvFileText; }
            set { _csvFileText = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Clear Command
        /// </summary>
        private ICommand _clearCommand;

        public ICommand ClearCommand => _clearCommand ?? (_clearCommand = new RelayCommand(param => Clear(param)));

        /// <summary>
        /// Text Convert Command
        /// </summary>
        private ICommand _textConvertCommand;

        public ICommand TextConvertCommand => _textConvertCommand ?? (_textConvertCommand = new RelayCommand(param => TSVCSVTextConvert(param)));

        /// <summary>
        /// Text Convert Command
        /// </summary>
        private ICommand _fileConvertCommand;

        public ICommand FileConvertCommand => _fileConvertCommand ?? (_fileConvertCommand = new RelayCommand(param => TSVCSVFileConvert(param)));

        /// <summary>
        /// Text Convert Command
        /// </summary>
        private ICommand _browserCommand;

        public ICommand BrowserCommand => _browserCommand ?? (_browserCommand = new RelayCommand(param => BrowseFile(param)));

        /// <summary>
        /// Clear
        /// </summary>
        /// <param name="parameter"></param>
        private void Clear(object? parameter)
        {
            if (parameter != null)
            {
                _ = (parameter as string) switch
                {
                    "TSV_File_Text_Box" => TSVFileText = string.Empty,
                    "TSV_Text_Box" => TSVText = string.Empty,
                    "CSV_File_Text_Box" => CSVFileText = string.Empty,
                    "CSV_Text_Box" => CSVText = string.Empty,
                    _ => string.Empty
                };
            }
        }

        /// <summary>
        /// Browse TSV file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrowseFile(object? parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Message = new WarningMessage();
                var file = openFileDialog.FileName;
                if (Path.GetExtension(file) == TSV)
                {
                    TSVFileText = file;
                    TSVVisible = "Visible";
                }
                else if (Path.GetExtension(file) == CSV)
                {
                    CSVFileText = file;
                    CSVVisible = "Visible";
                }
                else
                {
                    Message = new WarningMessage(true, $"Doesn't support this file type: {Path.GetExtension(file)}!");
                }
            }
        }

        /// <summary>
        /// TSV CSV File Convert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSVCSVFileConvert(object? parameter)
        {
            try
            {
                List<string> outputLines = new List<string>();
                var outputFolder = string.Empty;
                var outputFile = string.Empty;
                Message = new WarningMessage();

                if (!string.IsNullOrEmpty(TSVFileText))
                {
                    outputFolder = Path.GetDirectoryName(TSVFileText) + "\\";
                    outputFile = Path.GetFileNameWithoutExtension(TSVFileText) + CSV;
                    foreach (var line in FileUtils.GetFileContent(TSVFileText))
                    {
                        outputLines.Add(line.Replace("\t", ","));
                    }

                    CSVFileText = outputFolder + outputFile;
                }
                else if (!string.IsNullOrEmpty(CSVFileText))
                {
                    outputFolder = Path.GetDirectoryName(CSVFileText) + "\\";
                    outputFile = Path.GetFileNameWithoutExtension(CSVFileText) + TSV;
                    foreach (var line in FileUtils.GetFileContent(CSVFileText))
                    {
                        outputLines.Add(line.Replace(",", "\t"));
                    }

                    TSVFileText = outputFolder + outputFile;
                }

                FileUtils.WriteTextToFile(outputFolder, outputFile, outputLines);
            }
            catch (Exception ex)
            {
                Message = new WarningMessage(true, ex.Message);
            }
        }

        /// <summary>
        /// TSV CSV Text Convert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSVCSVTextConvert(object? parameter)
        {
            try
            {
                Message = new WarningMessage();
                if (!string.IsNullOrEmpty(TSVText))
                {
                    CSVText = TSVText.Replace("\t", ",");
                }
                else if (!string.IsNullOrEmpty(CSVText))
                {
                    TSVText = CSVText.Replace(",", "\t");
                }
            }
            catch (Exception ex)
            {
                Message = new WarningMessage(true, ex.Message);
            }
        }
    }
}
