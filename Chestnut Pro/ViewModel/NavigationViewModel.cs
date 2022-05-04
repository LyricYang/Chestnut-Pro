namespace Chestnut_Pro.ViewModel
{
    using Chestnut_Pro.Model;
    using Chestnut_Pro.View;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Input;

    /// <summary>
    /// Navigation View Model
    /// </summary>
    public class NavigationViewModel : ViewModelBase
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

            // Converter Views
            ObservableCollection<MenuItems> converterItems = new()
            {
                new() { MenuName = "NumberBase", MenuImage = @"Assets/number-base.png" },
                new() { MenuName = "Epoch", MenuImage = @"Assets/timestamp.png" },
                new() { MenuName = "TSV-CSV", MenuImage = @"Assets/csv.png" },
                new() { MenuName = "JSON-YAML", MenuImage = @"Assets/yaml.png" },
            };

            ConverterItemsCollection = new CollectionViewSource { Source = converterItems };
            ConverterItemsCollection.Filter += MenuItemsFilter;

            // Generator Views
            ObservableCollection<MenuItems> generatorItems = new()
            {
                new() { MenuName = "GUID", MenuImage = @"Assets/guid.png" },
                new() { MenuName = "Hash", MenuImage = @"Assets/hash.png" },
                new() { MenuName = "ASCII Art", MenuImage = @"Assets/ascii.png" },
                new() { MenuName = "Palette", MenuImage = @"Assets/palette.png" },
            };

            GeneratorItemsCollection = new CollectionViewSource { Source = generatorItems };
            GeneratorItemsCollection.Filter += MenuItemsFilter;

            // Formatter Views
            ObservableCollection<MenuItems> formatterItems = new()
            {
                new() { MenuName = "JSON", MenuImage = @"Assets/jsonformat.png" },
                new() { MenuName = "XML", MenuImage = @"Assets/xml.png" },
            };

            FormatterItemsCollection = new CollectionViewSource { Source = formatterItems };
            FormatterItemsCollection.Filter += MenuItemsFilter;

            // Encoder Views
            ObservableCollection<MenuItems> encoderItems = new()
            {
                new() { MenuName = "Base64", MenuImage = @"Assets/base64.png" },
                new() { MenuName = "JWT Decoder", MenuImage = @"Assets/jwt.png" },
            };

            EncoderItemsCollection = new CollectionViewSource { Source = encoderItems };
            EncoderItemsCollection.Filter += MenuItemsFilter;

            // Chart Views
            ObservableCollection<MenuItems> chartItems = new()
            {
                new() { MenuName = "Sankey Chart", MenuImage = @"Assets/chart.png" },
            };

            ChartItemsCollection = new CollectionViewSource { Source = chartItems };
            ChartItemsCollection.Filter += MenuItemsFilter;

            // Set Home Page
            SelectedViewModel = new AllToolsView();

        }

        /// <summary>
        /// Text Search Filter Text
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
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Selected View Model
        /// </summary>
        private object _selectedViewModel;

        public object SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Menu Command
        /// </summary>
        private ICommand _menuCommand;

        public ICommand MenuCommand => _menuCommand ?? (_menuCommand = new RelayCommand(param => SwitchViews(param)));

        /// <summary>
        /// Copy Command
        /// </summary>
        private ICommand _copyCommand;

        public ICommand CopyCommand => _copyCommand ?? (_copyCommand = new RelayCommand(param => CopyContent(param)));

        /// <summary>
        /// Switch Views
        /// </summary>
        /// <param name="parameter"></param>
        public void SwitchViews(object? parameter)
        {
            SelectedViewModel = parameter switch
            {
                "All Tools" => new AllToolsViewModel(),
                "NumberBase" => new NumberBaseViewModel(),
                "Epoch" => new EpochViewModel(),
                "TSV-CSV" => new TSVCSVViewModel(),
                "JSON-YAML" => new JsonYamlConverterVeiwModel(),
                "GUID" => new GUIDGeneratorViewModel(),
                "Hash" => new HashGeneratorViewModel(),
                "ASCII Art" => new ASCIIArtGeneratorViewModel(),
                "Palette" => new ColorPaletteViewModel(),
                "JSON" => new JsonFormatterViewModel(),
                "XML" => new XmlFormatterViewModel(),
                "Base64" => new Base64ViewModel(),
                "JWT Decoder" => new JWTDecoderViewModel(),
                "Sankey Chart" => new ChartGeneratorView(),
                "Settings" => new SettingsViewModel(),
                "Dashboard" => new DashboardViewModel(),
                _ => new AllToolsViewModel()
            };
        }

        /// <summary>
        /// Copy Text Box Content
        /// </summary>
        /// <param name="parameter"></param>
        public void CopyContent(object? parameter)
        {
            var content = parameter as string;
            if (!string.IsNullOrEmpty(content))
            {
                Clipboard.SetText(content.TrimEnd('\n').Trim('\r'));
            }
        }

        /// <summary>
        /// Menu Items Filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemsFilter(object sender, FilterEventArgs e)
        {
            if (string.IsNullOrEmpty(FilterText))
            {
                e.Accepted = true;
                return;
            }

            MenuItems? item = e.Item as MenuItems;
            e.Accepted = item.MenuName.ToUpper().Contains(FilterText.ToUpper()) ? true : false;
        }
    }
}