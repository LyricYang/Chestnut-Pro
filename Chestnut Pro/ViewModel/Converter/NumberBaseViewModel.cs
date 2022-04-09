namespace Chestnut_Pro.ViewModel
{
    using Chestnut_Pro.Service;
    using System;
    using System.Windows.Input;

    /// <summary>
    /// Number Base View Model
    /// </summary>
    public class NumberBaseViewModel : ViewModelBase
    {
        private bool _active;

        /// <summary>
        /// Active
        /// </summary>
        public bool Active
        {
            get { return _active; }
            set { _active = value; OnPropertyChanged(); }
        }

        private bool _format = true;

        /// <summary>
        /// Format
        /// </summary>
        public bool Format
        {
            get { return _format; }
            set { _format = value; OnPropertyChanged(); }
        }

        private string _inputText;

        /// <summary>
        /// InputText
        /// </summary>
        public string InputText
        {
            get { return _inputText; }
            set { _inputText = value; OnPropertyChanged(); }
        }

        private string _binaryText;

        /// <summary>
        /// Binary Text
        /// </summary>
        public string BinaryText
        {
            get { return _binaryText; }
            set { _binaryText = value; OnPropertyChanged(); }
        }

        private string _octalText;

        /// <summary>
        /// Octal Text
        /// </summary>
        public string OctalText
        {
            get { return _octalText; }
            set { _octalText = value; OnPropertyChanged(); }
        }

        private string _deciamlText;

        /// <summary>
        /// Decimal Text
        /// </summary>
        public string DecimalText
        {
            get { return _deciamlText; }
            set { _deciamlText = value; OnPropertyChanged(); }
        }

        private string _hexadecimalText;

        /// <summary>
        /// Hexadecimal Text
        /// </summary>
        public string HexadecimalText
        {
            get { return _hexadecimalText; }
            set { _hexadecimalText = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Convert Command
        /// </summary>
        private ICommand _convertCommand;

        public ICommand ConvertCommand => _convertCommand ?? (_convertCommand = new RelayCommand(param => ConvertNumberBase(param)));

        /// <summary>
        /// Convert Number Base
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConvertNumberBase(object? parameter)
        {
            var param = parameter as string;
            var type = (NumberBaseType)Enum.Parse(typeof(NumberBaseType), string.IsNullOrEmpty(param) ? "Decimal" : param);

            var input = string.IsNullOrEmpty(InputText) ? "0" : InputText;
            input = input.Replace(" ", "").Replace(",", "");
            if (NumberBaseHelper.CheckNumberValid(input, type))
            {
                Active = false;
                var number = type switch
                {
                    NumberBaseType.Binary => Convert.ToInt32(input, 2),
                    NumberBaseType.Octal => Convert.ToInt32(input, 8),
                    NumberBaseType.Hexadecimal => Convert.ToInt32(input, 16),
                    _ => Convert.ToInt32(input),
                };

                BinaryText = Format ? NumberBaseHelper.SplitStringByWhiteSpace(Convert.ToString(number, 2), 4) : Convert.ToString(number, 2);
                OctalText = Format ? NumberBaseHelper.SplitStringByWhiteSpace(Convert.ToString(number, 8), 3) : Convert.ToString(number, 8);
                DecimalText = Format ? string.Format("{0:N0}", number) : Convert.ToString(number);
                HexadecimalText = Format ? NumberBaseHelper.SplitStringByWhiteSpace(Convert.ToString(number, 16), 4) : Convert.ToString(number, 16);
            }
            else
            {
                Active = true;
            }
        }
    }
}
