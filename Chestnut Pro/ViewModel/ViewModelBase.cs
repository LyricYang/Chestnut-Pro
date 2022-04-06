namespace Chestnut_Pro.ViewModel
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// View Model Notification Base
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// On Property Changed
        /// </summary>
        /// <param name="propName"></param>
        public void OnPropertyChanged([CallerMemberName]string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
