namespace Chestnut_Pro.ViewModels
{
    using Prism.Mvvm;
    using System;
    using System.Windows.Input;

    /// <summary>
    /// GUID Generator View Model
    /// </summary>
    public class GUIDGeneratorViewModel : BindableBase
    {
        private bool _hyphens = true;

        /// <summary>
        /// Hyphens
        /// </summary>
        public bool Hyphens
        {
            get { return _hyphens; }
            set { _hyphens = value; RaisePropertyChanged(); }
        }

        private bool _uppercase;

        /// <summary>
        /// Uppercase
        /// </summary>
        public bool Uppercase
        {
            get { return _uppercase; }
            set { _uppercase = value; RaisePropertyChanged(); }
        }

        private string _outputText;

        /// <summary>
        /// Output Text
        /// </summary>
        public string OutputText
        {
            get { return _outputText; }
            set { _outputText = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Clear Command
        /// </summary>
        private ICommand _clearCommand;

        public ICommand ClearCommand => _clearCommand ?? (_clearCommand = new RelayCommand(param => Clear(param)));

        /// <summary>
        /// Convert Command
        /// </summary>
        private ICommand _convertCommand;

        public ICommand ConvertCommand => _convertCommand ?? (_convertCommand = new RelayCommand(param => GUIDGenerate(param)));

        /// <summary>
        /// Clear Method
        /// </summary>
        /// <param name="parameter"></param>
        public void Clear(object? parameter)
        {
            OutputText = string.Empty;
        }

        /// <summary>
        /// Generate GUIDs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GUIDGenerate(object? parameter)
        {
            var count = Convert.ToInt32(parameter ?? "1");

            string[] outputs = new string[count];
            for (int i = 0; i < count; i++)
            {
                var guid = Guid.NewGuid().ToString();
                outputs[i] = guid;
            }

            var output = string.Join("\r\n", outputs);
            output = Hyphens ? output : output.Replace("-", "");
            output = Uppercase ? output.ToUpper() : output;
            OutputText = output;
        }
    }
}
