namespace Chestnut_Pro.ViewModel
{
    using System.ComponentModel;

    /// <summary>
    /// Color Palette View Model
    /// </summary>
    public class ColorPaletteViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The Constructor
        /// </summary>
        public ColorPaletteViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
