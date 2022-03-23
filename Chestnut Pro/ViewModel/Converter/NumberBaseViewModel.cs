
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using Chestnut_Pro.Model;

namespace Chestnut_Pro.ViewModel
{
    public class NumberBaseViewModel : INotifyPropertyChanged
    {
        public NumberBaseViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    }
}
