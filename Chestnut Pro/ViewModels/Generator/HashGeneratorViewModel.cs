namespace Chestnut_Pro.ViewModels
{
    using Prism.Mvvm;
    using System;
    using System.Security.Cryptography;
    using System.Text;
    using System.Windows.Input;

    /// <summary>
    /// Hash Generator View Model
    /// </summary>
    public class HashGeneratorViewModel : BindableBase
    {
        private readonly MD5 md5 = MD5.Create();
        private readonly SHA1 sha1 = SHA1.Create();
        private readonly SHA256 sha256 = SHA256.Create();
        private readonly SHA512 sha512 = SHA512.Create();

        private bool _uppercase;

        /// <summary>
        /// Uppercase
        /// </summary>
        public bool Uppercase
        {
            get { return _uppercase; }
            set { _uppercase = value; RaisePropertyChanged(); }
        }

        private string _inputText;

        /// <summary>
        /// Input Text
        /// </summary>
        public string InputText
        {
            get { return _inputText; }
            set { _inputText = value; RaisePropertyChanged(); }
        }

        private string _md5;

        /// <summary>
        /// MD5
        /// </summary>
        public string MD5Output
        {
            get { return _md5; }
            set { _md5 = value; RaisePropertyChanged(); }
        }

        private string _sha1;

        /// <summary>
        /// SHA1
        /// </summary>
        public string SHA1Output
        {
            get { return _sha1; }
            set { _sha1 = value; RaisePropertyChanged(); }
        }

        private string _sha256;

        /// <summary>
        /// SHA256
        /// </summary>
        public string SHA256Output
        {
            get { return _sha256; }
            set { _sha256 = value; RaisePropertyChanged(); }
        }

        private string _sha512;

        /// <summary>
        /// SHA512
        /// </summary>
        public string SHA512Output
        {
            get { return _sha512; }
            set { _sha512 = value; RaisePropertyChanged(); }
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

        public ICommand ConvertCommand => _convertCommand ?? (_convertCommand = new RelayCommand(param => HashCalculate(param)));

        /// <summary>
        /// Clear Method
        /// </summary>
        /// <param name="parameter"></param>
        public void Clear(object? parameter)
        {
            InputText = string.Empty;
            MD5Output = string.Empty;
            SHA1Output = string.Empty;
            SHA256Output = string.Empty;
            SHA512Output = string.Empty;
        }

        /// <summary>
        /// Calculate Hash
        /// </summary>
        /// <param name="parameter"></param>
        private void HashCalculate(object? parameter)
        {
            var bytesInput = Encoding.UTF8.GetBytes(InputText);
            var format = (parameter ?? "Hex") as string;

            MD5Output = Calculate(format, md5.ComputeHash(bytesInput));
            SHA1Output = Calculate(format, sha1.ComputeHash(bytesInput));
            SHA256Output = Calculate(format, sha256.ComputeHash(bytesInput));
            SHA512Output = Calculate(format, sha512.ComputeHash(bytesInput));
        }

        private string Calculate(string format, byte[] bytes)
        {
            return format.Equals("Hex") ? (Uppercase ? Convert.ToHexString(bytes).ToUpper() : Convert.ToHexString(bytes)) : Convert.ToBase64String(bytes);
        }
    }
}