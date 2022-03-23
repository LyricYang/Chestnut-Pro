namespace Chestnut_Pro.ViewModel
{
    using System.ComponentModel;

    public class EpochViewModel : INotifyPropertyChanged
    {
        public EpochViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    }
}
