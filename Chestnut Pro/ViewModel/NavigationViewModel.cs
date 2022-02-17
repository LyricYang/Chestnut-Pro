namespace Chestnut_Pro.ViewModel
{
    using Chestnut_Pro.Model;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Data;
    using System.Windows.Input;

    /// <summary>
    /// Navigation View Model
    /// </summary>
    public class NavigationViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// CollectionViewSource enables XAML code to set the commonly used CollectionView properties,
        /// passing these settings to the underlying view.
        /// </summary>
        private CollectionViewSource MenuItemsCollection;

        /// <summary>
        /// ICollectionView enables collections to have the functionalities of current record management,
        /// custom sorting, filtering, and grouping.
        /// </summary>
        public ICollectionView SourceCollection => MenuItemsCollection.View;

        /// <summary>
        /// The Constructor
        /// </summary>
        public NavigationViewModel()
        {
            // ObservableCollection represents a dynamic data collection that provides notifications when items
            // get added, removed, or when the whole list is refreshed.
            ObservableCollection<MenuItems> menuItems = new ()
            {
                new () { MenuName = "Home",           MenuImage = @"Assets/home.png" },
                new () { MenuName = "All Tools",      MenuImage = @"Assets/tools-hardware.png" },
                new () { MenuName = "Number Base",    MenuImage = @"Assets/number-base.png" },
                new () { MenuName = "GUID Generator", MenuImage = @"Assets/guid.png" },
                new () { MenuName = "Color Palette",  MenuImage = @"Assets/palette.png" },
                new () { MenuName = "TSV <=> CSV",    MenuImage = @"Assets/csv.png" },
            };

            MenuItemsCollection = new CollectionViewSource { Source = menuItems };
            MenuItemsCollection.Filter += MenuItems_Filter;

            // Set Home Page
            SelectedViewModel = new HomeViewModel();

        }

        /// <summary>
        /// Implement interface member for INotifyPropertyChanged.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        /// <summary>
        /// Text Search Filter
        /// </summary>
        private string filterText;

        public string FilterText
        {
            get => filterText;
            set
            {
                filterText = value;
                MenuItemsCollection.View.Refresh();
                OnPropertyChanged("FilterText");
            }
        }

        private void MenuItems_Filter(object sender, FilterEventArgs e)
        {
            if (string.IsNullOrEmpty(FilterText))
            {
                e.Accepted = true;
                return;
            }

            MenuItems? _item = e.Item as MenuItems;
            if (_item.MenuName.ToUpper().Contains(FilterText.ToUpper()))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }

        private object _selectedViewModel;
        public object SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        /// <summary>
        /// Switch Views
        /// </summary>
        /// <param name="parameter"></param>
        public void SwitchViews(object parameter)
        {
            switch (parameter)
            {
                case "Home":
                    SelectedViewModel = new HomeViewModel();
                    break;
                case "All Tools":
                    SelectedViewModel = new AllToolsViewModel();
                    break;
                case "Number Base":
                    SelectedViewModel = new NumberBaseViewModel();
                    break;
                case "GUID Generator":
                    SelectedViewModel = new GUIDGeneratorViewModel();
                    break;
                case "Color Palette":
                    SelectedViewModel = new ColorPaletteViewModel();
                    break;
                case "TSV <=> CSV":
                    SelectedViewModel = new TSVCSVConverterViewModel();
                    break;
                default:
                    SelectedViewModel = new HomeViewModel();
                    break;
            }
        }

        private ICommand _menuCommand;
        public ICommand MenuCommand
        {
            get
            {
                if (_menuCommand == null)
                {
                    _menuCommand = new RelayCommand(param => SwitchViews(param));
                }
                return _menuCommand;
            }
        }

        // ============================== Show Color Palette View =============================================
        public void ColorPaletteView()
        {
            SelectedViewModel = new ColorPaletteViewModel();
        }

        // This PC button Command
        private ICommand _colorPaletteCommand;
        public ICommand ColorPaletteCommand
        {
            get
            {
                if (_colorPaletteCommand == null)
                {
                    _colorPaletteCommand = new RelayCommand(param => ColorPaletteView());
                }
                return _colorPaletteCommand;
            }
        }

        // ============================== Show GUID Generator View =============================================
        public void GUIDGeneratorView()
        {
            SelectedViewModel = new GUIDGeneratorViewModel();
        }

        // This PC button Command
        private ICommand _GUIDGeneratorCommand;
        public ICommand GUIDGeneratorCommand
        {
            get
            {
                if (_GUIDGeneratorCommand == null)
                {
                    _GUIDGeneratorCommand = new RelayCommand(param => GUIDGeneratorView());
                }
                return _GUIDGeneratorCommand;
            }
        }

        // ============================== Show Number Base Converter View =============================================
        public void NumberBaseConverterView()
        {
            SelectedViewModel = new NumberBaseViewModel();
        }

        // This PC button Command
        private ICommand _NumberBaseCommand;
        public ICommand NumberBaseCommand
        {
            get
            {
                if (_NumberBaseCommand == null)
                {
                    _NumberBaseCommand = new RelayCommand(param => NumberBaseConverterView());
                }
                return _NumberBaseCommand;
            }
        }
    }
}