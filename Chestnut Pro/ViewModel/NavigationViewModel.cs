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
        private CollectionViewSource ConverterItemsCollection;

        private CollectionViewSource GeneratorItemsCollection;

        private CollectionViewSource FormatterItemsCollection;

        private CollectionViewSource EncoderItemsCollection;

        private CollectionViewSource ChartItemsCollection;

        /// <summary>
        /// ICollectionView enables collections to have the functionalities of current record management,
        /// custom sorting, filtering, and grouping.
        /// </summary>
        public ICollectionView ConverterCollection => ConverterItemsCollection.View;

        public ICollectionView GeneratorCollection => GeneratorItemsCollection.View;

        public ICollectionView FormatterCollection => FormatterItemsCollection.View;

        public ICollectionView EncoderCollection => EncoderItemsCollection.View;

        public ICollectionView ChartCollection => ChartItemsCollection.View;

        /// <summary>
        /// The Constructor
        /// </summary>
        public NavigationViewModel()
        {
            // ObservableCollection represents a dynamic data collection that provides notifications when items
            // get added, removed, or when the whole list is refreshed.
            ObservableCollection<MenuItems> menuItems = new ()
            {
                new () { MenuName = "Chart",      MenuImage = @"Assets/chart.png" },
            };
            // Converter Views
            ObservableCollection<MenuItems> converterItems = new()
            {
                new() { MenuName = "NumberBase", MenuImage = @"Assets/number-base.png" },
                new() { MenuName = "Epoch", MenuImage = @"Assets/timestamp.png" },
                new() { MenuName = "TSV/CSV", MenuImage = @"Assets/csv.png" },
            };

            ConverterItemsCollection = new CollectionViewSource { Source = converterItems };
            ConverterItemsCollection.Filter += MenuItems_Filter;

            // Generator Views
            ObservableCollection<MenuItems> generatorItems = new()
            {
                new() { MenuName = "GUID", MenuImage = @"Assets/guid.png" },
                new() { MenuName = "Palette", MenuImage = @"Assets/palette.png" },
            };

            GeneratorItemsCollection = new CollectionViewSource { Source = generatorItems };
            GeneratorItemsCollection.Filter += MenuItems_Filter;

            // Formatter Views
            ObservableCollection<MenuItems> formatterItems = new()
            {
                new() { MenuName = "JSON", MenuImage = @"Assets/jsonformat.png" },
                new() { MenuName = "XML", MenuImage = @"Assets/xml.png" },
            };

            FormatterItemsCollection = new CollectionViewSource { Source = formatterItems };
            FormatterItemsCollection.Filter += MenuItems_Filter;

            // Encoder Views
            ObservableCollection<MenuItems> encoderItems = new()
            {
                new() { MenuName = "Base64", MenuImage = @"Assets/base64.png" },
            };

            EncoderItemsCollection = new CollectionViewSource { Source = encoderItems };
            EncoderItemsCollection.Filter += MenuItems_Filter;

            // Chart Views
            ObservableCollection<MenuItems> chartItems = new()
            {
                new() { MenuName = "Sankey Chart", MenuImage = @"Assets/chart.png" },
            };

            ChartItemsCollection = new CollectionViewSource { Source = chartItems };
            ChartItemsCollection.Filter += MenuItems_Filter;

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
                ConverterItemsCollection.View.Refresh();
                FormatterItemsCollection.View.Refresh();
                GeneratorItemsCollection.View.Refresh();
                EncoderItemsCollection.View.Refresh();
                ChartItemsCollection.View.Refresh();
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
                case "All Tools":
                    SelectedViewModel = new AllToolsViewModel();
                    break;
                case "NumberBase":
                    SelectedViewModel = new NumberBaseViewModel();
                    break;
                case "GUID":
                    SelectedViewModel = new GUIDGeneratorViewModel();
                    break;
                case "Sankey Chart":
                    SelectedViewModel = new ChartGeneratorViewModel();
                    break;
                case "Base64":
                    SelectedViewModel = new Base64ViewModel();
                    break;
                case "Palette":
                    SelectedViewModel = new ColorPaletteViewModel();
                    break;
                case "TSV/CSV":
                    SelectedViewModel = new TSVCSVViewModel();
                    break;
                case "JSON":
                    SelectedViewModel = new JsonFormatterViewModel();
                    break;
                case "XML":
                    SelectedViewModel = new XmlFormatterViewModel();
                    break;
                case "Epoch":
                    SelectedViewModel = new EpochViewModel();
                    break;
                case "Dashboard":
                    SelectedViewModel = new DashboardViewModel();
                    break;
                default:
                    SelectedViewModel = new AllToolsViewModel();
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

        // ============================== Show XML Formatter View =============================================
        public void XMLFormatterView()
        {
            SelectedViewModel = new XmlFormatterViewModel();
        }

        // This PC button Command
        private ICommand _XMLFormatterCommand;
        public ICommand XMLFormatterCommand
        {
            get
            {
                if (_XMLFormatterCommand == null)
                {
                    _XMLFormatterCommand = new RelayCommand(param => XMLFormatterView());
                }
                return _XMLFormatterCommand;
            }
        }

        // ============================== Show TSV/CSV Converter View =============================================
        public void TSVCSVConverterView()
        {
            SelectedViewModel = new TSVCSVViewModel();
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
        public void DashboardView()
        {
            SelectedViewModel = new DashboardViewModel();
        }

        // This PC button Command
        private ICommand _DashboardCommand;
        public ICommand DashboardCommand
        {
            get
            {
                if (_DashboardCommand == null)
                {
                    _DashboardCommand = new RelayCommand(param => DashboardView());
                }
                return _DashboardCommand;
            }
        }

        // ============================== Show Settings View =============================================
        public void AllToolsView()
        {
            SelectedViewModel = new AllToolsViewModel();
        }

        // This PC button Command
        private ICommand _AllToolsCommand;
        public ICommand AllToolsCommand
        {
            get
            {
                if (_AllToolsCommand == null)
                {
                    _AllToolsCommand = new RelayCommand(param => AllToolsView());
                }
                return _AllToolsCommand;
            }
        }

        // ============================== Show Settings View =============================================
        public void EpochConverterView()
        {
            SelectedViewModel = new EpochViewModel();
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

        // ============================== Show Settings View =============================================
        public void SankeyChartView()
        {
            SelectedViewModel = new ChartGeneratorViewModel();
        }

        // This PC button Command
        private ICommand _SankeyChartCommand;
        public ICommand SankeyChartCommand
        {
            get
            {
                if (_SankeyChartCommand == null)
                {
                    _SankeyChartCommand = new RelayCommand(param => SankeyChartView());
                }
                return _SankeyChartCommand;
            }
        }
    }
}