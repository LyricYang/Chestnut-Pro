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
                new () { MenuName = "Home", MenuImage = @"Assets/Home_Icon.png"},
                new () { MenuName = "All Tools", MenuImage = @"Assets/Desktop_Icon.png"},
                new () { MenuName = "Number Base", MenuImage = @"Assets/Document_Icon.png" },
                new () { MenuName = "Downloads", MenuImage = @"Assets/Download_Icon.png" },
                new () { MenuName = "Pictures", MenuImage = @"Assets/Images_Icon.png" },
                new () { MenuName = "Music", MenuImage = @"Assets/Music_Icon.png" },
                new () { MenuName = "Movies", MenuImage = @"Assets/Movies_Icon.png" },
                new () { MenuName = "Trash", MenuImage = @"Assets/Trash_Icon.png" },
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
                case "Downloads":
                    SelectedViewModel = new DownloadViewModel();
                    break;
                case "Pictures":
                    SelectedViewModel = new PictureViewModel();
                    break;
                case "Music":
                    SelectedViewModel = new MusicViewModel();
                    break;
                case "Movies":
                    SelectedViewModel= new MovieViewModel();
                    break;
                case "Trash":
                    SelectedViewModel = new TrashViewModel();
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

        /// <summary>
        /// Show PC View
        /// </summary>
        public void PCView()
        {
            SelectedViewModel = new PCViewModel();
        }

        /// <summary>
        /// The PC Button Command
        /// </summary>
        private ICommand _pccommand;
        public ICommand PCCommand
        {
            get
            {
                if(_pccommand == null)
                {
                    _pccommand = new RelayCommand(param => PCView());
                }
                return _pccommand;
            }
        }

        /// <summary>
        /// Show Home View
        /// </summary>
        private void ShowHome()
        {
            SelectedViewModel = new HomeViewModel();
        }

        private ICommand _backHomeCommand;
        public ICommand BackHomeCommand
        {
            get
            {
                if (_backHomeCommand == null)
                {
                    _backHomeCommand = new RelayCommand(param => ShowHome());
                }
                return _backHomeCommand;
            }
        }
    }
}
