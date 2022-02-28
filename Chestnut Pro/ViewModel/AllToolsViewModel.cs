namespace Chestnut_Pro.ViewModel
{
    using System.ComponentModel;

    public class AllToolsViewModel : INotifyPropertyChanged
    {

        private string? filterText;

        public string? FilterText
        {
            get => filterText;
            set
            {
                filterText = value;
                OnPropertyChanged(nameof(FilterText));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    }
}
