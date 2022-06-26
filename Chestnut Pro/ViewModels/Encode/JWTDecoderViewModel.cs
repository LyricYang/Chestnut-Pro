namespace Chestnut_Pro.ViewModels
{
    using Chestnut_Pro.Model;
    using Chestnut_Pro.Service;
    using Prism.Mvvm;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Windows.Input;

    /// <summary>
    /// Base 64 View Model
    /// </summary>
    public class JWTDecoderViewModel : BindableBase
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

        private string _headerOutputText;

        /// <summary>
        /// OutputText
        /// </summary>
        public string HeaderOutputText
        {
            get { return _headerOutputText; }
            private set { _headerOutputText = value; RaisePropertyChanged(); }
        }

        private string _payloadOutputText;

        /// <summary>
        /// OutputText
        /// </summary>
        public string PayloadOutputText
        {
            get { return _payloadOutputText; }
            private set { _payloadOutputText = value; RaisePropertyChanged(); }
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

        public ICommand ConvertCommand => _convertCommand ?? (_convertCommand = new RelayCommand(param => JWTDecoder(param)));

        /// <summary>
        /// Clear Method
        /// </summary>
        /// <param name="parameter"></param>
        public void Clear(object? parameter)
        {
            InputText = string.Empty;
            HeaderOutputText = string.Empty;
            PayloadOutputText = string.Empty;
        }

        /// <summary>
        /// Base64 Convert
        /// </summary>
        /// <param name="parameter"></param>
        private void JWTDecoder(object? parameter)
        {
            try
            {
                Message = new WarningMessage();
                var handler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtSecurityToken = handler.ReadJwtToken(InputText);
                HeaderOutputText = JsonHelper.Format(jwtSecurityToken.Header.SerializeToJson(), Indentation.TwoSpaces);
                PayloadOutputText = JsonHelper.Format(jwtSecurityToken.Payload.SerializeToJson(), Indentation.TwoSpaces);
            }
            catch (Exception ex)
            {
                Message = new WarningMessage(true, ex.Message);
            }
        }
    }
}