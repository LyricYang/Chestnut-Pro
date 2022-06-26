namespace Chestnut_Pro.ViewModels
{
    using Chestnut_Pro.Model;
    using Prism.Mvvm;
    using System;
    using System.Text;
    using System.Windows.Input;

    /// <summary>
    /// Base 64 View Model
    /// </summary>
    public class Base64ViewModel : BindableBase
    {
        private WarningMessage _message;

        /// <summary>
        /// Warning Message
        /// </summary>
        public WarningMessage Message
        {
            get { return _message; }
            set { _message = value; RaisePropertyChanged(); }
        }

        private string _inputText;

        /// <summary>
        /// InputText
        /// </summary>
        public string InputText
        {
            get { return _inputText; }
            set { _inputText = value; RaisePropertyChanged(); }
        }

        private string _outputText;

        /// <summary>
        /// OutputText
        /// </summary>
        public string OutputText
        {
            get { return _outputText; }
            private set { _outputText = value; RaisePropertyChanged(); }
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

        public ICommand ConvertCommand => _convertCommand ?? (_convertCommand = new RelayCommand(param => Base64Convert(param)));

        /// <summary>
        /// Clear Method
        /// </summary>
        /// <param name="parameter"></param>
        public void Clear(object? parameter)
        {
            InputText = string.Empty;
            OutputText = string.Empty;
        }

        /// <summary>
        /// Base64 Convert
        /// </summary>
        /// <param name="parameter"></param>
        private void Base64Convert(object? parameter)
        {
            try
            {
                Message = new WarningMessage();
                var encode = Convert.ToBoolean(parameter ?? "false");
                if (encode)
                {
                    var bytes = Encoding.UTF8.GetBytes(InputText);
                    OutputText = Convert.ToBase64String(bytes);
                }
                else
                {
                    var bytes = Convert.FromBase64String(InputText);
                    OutputText = Encoding.UTF8.GetString(bytes);
                }
            }
            catch (Exception ex)
            {
                Message = new WarningMessage(true, ex.Message);
            }
        }
    }
}