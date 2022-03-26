namespace Chestnut_Pro.Model
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public class ChartModel : INotifyPropertyChanged
    {
        private string source;
        public string Source
        {
            get { return source; }
            set { source = value; RaiseProperChanged(); }
        }

        private string destination;
        public string Destination
        {
            get { return destination; }
            set { destination = value; RaiseProperChanged(); }
        }

        public int? value;
        public int? Value
        {
            get { return value; }
            set { this.value = value; RaiseProperChanged(); }
        }

        private bool visible;
        public bool Visible
        {
            get { return visible; }
            set { visible = value; RaiseProperChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaiseProperChanged([CallerMemberName] string caller = "")
        {

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
    }
}
