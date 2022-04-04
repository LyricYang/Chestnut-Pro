namespace Chestnut_Pro.ViewModel
{
    using System.ComponentModel;

    /// <summary>
    /// Settings View Model
    /// </summary>
    public class SettingsViewModel : INotifyPropertyChanged
    {
        public SettingsViewModel()
        {
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
