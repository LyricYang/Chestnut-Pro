namespace Chestnut_Pro.ViewModel
{
    using Chestnut_Pro.Model;
    using Chestnut_Pro.View;
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
                new () { MenuName = "Home",              MenuImage = @"Assets/home.png" },
                new () { MenuName = "All Tools",         MenuImage = @"Assets/tools-hardware.png" },
                new () { MenuName = "Number Base",       MenuImage = @"Assets/number-base.png" },
                new () { MenuName = "GUID Generator",    MenuImage = @"Assets/guid.png" },
                new () { MenuName = "Base64 Generator",  MenuImage = @"Assets/base64.png" },
                new () { MenuName = "Epoch Converter",   MenuImage = @"Assets/timestamp.png" },
                new () { MenuName = "JSON Formatter",    MenuImage = @"Assets/jsonformat.png" },
                new () { MenuName = "TSV/CSV Converter", MenuImage = @"Assets/csv.png" },
                new () { MenuName = "Color Palette",     MenuImage = @"Assets/palette.png" },
            };

            MenuItemsCollection = new CollectionViewSource { Source = menuItems };
            MenuItemsCollection.Filter += MenuItems_Filter;

            // Set Home Page
            SelectedViewModel = new AllToolsView();

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
                OnPropertyChanged(nameof(FilterText));
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
                case "Base64 Generator":
                    SelectedViewModel = new Base64ViewModel();
                    break;
                case "Color Palette":
                    SelectedViewModel = new ColorPaletteViewModel();
                    break;
                case "TSV/CSV Converter":
                    SelectedViewModel = new TSVCSVConverterViewModel();
                    break;
                case "JSON Formatter":
                    SelectedViewModel = new JsonFormatterViewModel();
                    break;
                case "Epoch Converter":
                    SelectedViewModel = new TimestampConverterViewModel();
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

        // ============================== Show Base 64 Generator View =============================================
        public void Base64GeneratorView()
        {
            SelectedViewModel = new Base64ViewModel();
        }

        // This PC button Command
        private ICommand _Base64GeneratorCommand;
        public ICommand Base64GeneratorCommand
        {
            get
            {
                if (_Base64GeneratorCommand == null)
                {
                    _Base64GeneratorCommand = new RelayCommand(param => Base64GeneratorView());
                }
                return _Base64GeneratorCommand;
            }
        }

        // ============================== Show Json Formatter View =============================================
        public void JsonFormatterView()
        {
            SelectedViewModel = new JsonFormatterViewModel();
        }

        // This PC button Command
        private ICommand _JsonFormatterCommand;
        public ICommand JsonFormatterCommand
        {
            get
            {
                if (_JsonFormatterCommand == null)
                {
                    _JsonFormatterCommand = new RelayCommand(param => JsonFormatterView());
                }
                return _JsonFormatterCommand;
            }
        }

        // ============================== Show TSV/CSV Converter View =============================================
        public void TSVCSVConverterView()
        {
            SelectedViewModel = new TSVCSVConverterViewModel();
        }

        // This PC button Command
        private ICommand _TsvCsvConverterCommand;
        public ICommand TsvCsvConverterCommand
        {
            get
            {
                if (_TsvCsvConverterCommand == null)
                {
                    _TsvCsvConverterCommand = new RelayCommand(param => TSVCSVConverterView());
                }
                return _TsvCsvConverterCommand;
            }
        }

        // ============================== Show Settings View =============================================
        public void SettingsView()
        {
            SelectedViewModel = new SettingsViewModel();
        }

        // This PC button Command
        private ICommand _SettingsCommand;
        public ICommand SettingsCommand
        {
            get
            {
                if (_SettingsCommand == null)
                {
                    _SettingsCommand = new RelayCommand(param => SettingsView());
                }
                return _SettingsCommand;
            }
        }

        // ============================== Show Settings View =============================================
        public void EpochConverterView()
        {
            SelectedViewModel = new TimestampConverterViewModel();
        }

        // This PC button Command
        private ICommand _EpochConverterCommand;
        public ICommand EpochConverterCommand
        {
            get
            {
                if (_EpochConverterCommand == null)
                {
                    _EpochConverterCommand = new RelayCommand(param => EpochConverterView());
                }
                return _EpochConverterCommand;
            }
        }
    }
}