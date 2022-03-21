namespace Chestnut_Pro.ViewModel
{
    using System.ComponentModel;

    public class XMLFormatterViewModel : INotifyPropertyChanged
    {
        public XMLFormatterViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    }
}
