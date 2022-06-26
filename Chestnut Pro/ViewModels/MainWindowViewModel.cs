namespace Chestnut_Pro.ViewModels
{
    using Chestnut_Pro.Model;
    using Chestnut_Pro.Views;
    using Prism.Commands;
    using Prism.Mvvm;
    using Prism.Regions;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Input;

    /// <summary>
    /// Main Window View Model
    /// </summary>
    public class MainWindowViewModel : BindableBase
    {
        /// <summary>
        /// CollectionViewSource enables XAML code to set the commonly used CollectionView properties,
        /// passing these settings to the underlying view.
        /// </summary>
        private CollectionViewSource ToolItemsViewSource;

        /// <summary>
        /// ICollectionView enables collections to have the functionalities of current record management,
        /// custom sorting, filtering, and grouping.
        /// </summary>
        public ICollectionView ToolsCollection => ToolItemsViewSource.View;

        private readonly IRegionManager regionManager;

        public DelegateCommand<string> OpenCommand { get; private set; }

        /// <summary>
        /// The Constructor
        /// </summary>
        /// <param name="regionManager"></param>
        public MainWindowViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            OpenCommand = new DelegateCommand<string>((obj) => regionManager.Regions["ContentRegion"].RequestNavigate(obj));

            // ObservableCollection represents a dynamic data collection that provides notifications when items
            // get added, removed, or when the whole list is refreshed.
            ObservableCollection<MenuItems> ToolItems = new()
            {
                new() { MenuName = "NumberBase", MenuType=nameof(NumberBaseView), MenuImage = @"Assets/number-base.png" },
                new() { MenuName = "Epoch", MenuType=nameof(EpochView), MenuImage = @"Assets/timestamp.png" },
                new() { MenuName = "TSV-CSV", MenuType=nameof(TSVCSVView), MenuImage = @"Assets/csv.png" },
                new() { MenuName = "JSON-YAML", MenuType=nameof(JsonYamlConverterView), MenuImage = @"Assets/yaml.png" },
                new() { MenuName = "GUID", MenuType=nameof(GUIDGeneratorView), MenuImage = @"Assets/guid.png" },
                new() { MenuName = "Hash", MenuType=nameof(HashGeneratorView), MenuImage = @"Assets/hash.png" },
                new() { MenuName = "ASCII Art",MenuType=nameof(ASCIIArtGeneratorView), MenuImage = @"Assets/ascii.png" },
                new() { MenuName = "Palette",MenuType=nameof(ColorPaletteView), MenuImage = @"Assets/palette.png" },
                new() { MenuName = "JSON",MenuType=nameof(JsonFormatterView), MenuImage = @"Assets/jsonformat.png" },
                new() { MenuName = "XML",MenuType=nameof(XmlFormatterView), MenuImage = @"Assets/xml.png" },
                new() { MenuName = "Base64",MenuType=nameof(Base64View), MenuImage = @"Assets/base64.png" },
                new() { MenuName = "JWT Decoder",MenuType=nameof(JWTDecoderView), MenuImage = @"Assets/jwt.png" },
                new() { MenuName = "Sankey Chart",MenuType=nameof(ChartGeneratorView), MenuImage = @"Assets/chart.png" },
            };

            ToolItemsViewSource = new CollectionViewSource { Source = ToolItems };
            ToolItemsViewSource.Filter += (sender, e) =>
            {
                if (string.IsNullOrEmpty(FilterText))
                {
                    e.Accepted = true;
                    return;
                }

                MenuItems? item = e.Item as MenuItems;
                e.Accepted = item.MenuName.ToUpper().Contains(FilterText.ToUpper()) ? true : false;
            };

            // Set Home Page
            //regionManager.Regions["ContentRegion"].RequestNavigate("AllToolsView");
            this.regionManager.RegisterViewWithRegion("ContentRegion", typeof(DashboardView));
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
                ToolItemsViewSource.View.Refresh();
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Copy Command
        /// </summary>
        private ICommand _copyCommand;

        public ICommand CopyCommand => _copyCommand ??= new RelayCommand(param =>
        {
            var content = param as string;
            if (!string.IsNullOrEmpty(content))
            {
                Clipboard.SetText(content.TrimEnd('\n').Trim('\r'));
            }
        });
    }
}
