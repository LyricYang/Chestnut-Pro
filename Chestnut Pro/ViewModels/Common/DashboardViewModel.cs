namespace Chestnut_Pro.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using Chestnut_Pro.Model;
    using Chestnut_Pro.Service;
    using Newtonsoft.Json;
    using Prism.Mvvm;

    /// <summary>
    /// Dashboard View Model
    /// </summary>
    public class DashboardViewModel : BindableBase
    {
        private readonly ObservableCollection<ComboBoxItem> _userEntries;
        private ComboBoxItem _userEntry;

        public ObservableCollection<ComboBoxItem> UserEntries => _userEntries;

        public ComboBoxItem UserEntry
        {
            get { return _userEntry; }
            set
            {
                if (_userEntry == value) return;
                _userEntry = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<AgendaModel> _finishAgenda;

        public ObservableCollection<AgendaModel> FinishAgenda
        {
            get { return _finishAgenda; }
            set { _finishAgenda = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<GithubRepo> _repos;

        /// <summary>
        /// Data Source
        /// </summary>
        public ObservableCollection<GithubRepo> Repos
        {
            get { return _repos; }
            set { _repos = value; RaisePropertyChanged(); }
        }

        private int _stars;

        public int Stars
        {
            get { return _stars; }
            set { _stars = value; RaisePropertyChanged(); }
        }

        private int _forks;

        public int Forks
        {
            get { return _forks; }
            set { _forks = value; RaisePropertyChanged(); }
        }

        private GithubUser _user;

        public GithubUser User
        {
            get { return _user; }
            set { _user = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Stock
        /// </summary>
        private string _lastestPri;

        public string LastestPri
        {
            get { return _lastestPri; }
            set { _lastestPri = value; RaisePropertyChanged(); }
        }

        private string _limit;

        public string Limit
        {
            get { return _limit; }
            set { _limit = value; RaisePropertyChanged(); }
        }

        private string _maxPri;

        public string MaxPri
        {
            get { return _maxPri; }
            set { _maxPri = value; RaisePropertyChanged(); }
        }

        private string _minPri;

        public string MinPri
        {
            get { return _minPri; }
            set { _minPri = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Gold
        /// </summary>
        private string _AU99LastestPri;

        public string AU99LastestPri
        {
            get { return _AU99LastestPri; }
            set { _AU99LastestPri = value; RaisePropertyChanged(); }
        }

        private string _AU99Limit;

        public string AU99Limit
        {
            get { return _AU99Limit; }
            set { _AU99Limit = value; RaisePropertyChanged(); }
        }

        private string _AU99MaxPri;

        public string AU99MaxPri
        {
            get { return _AU99MaxPri; }
            set { _AU99MaxPri = value; RaisePropertyChanged(); }
        }

        private string _AU99MinPri;

        public string AU99MinPri
        {
            get { return _AU99MinPri; }
            set { _AU99MinPri = value; RaisePropertyChanged(); }
        }

        public ObservableCollection<FollowingModel> FollowingUserCollection { get; set; }

        public DashboardViewModel()
        {
            _userEntries = new ObservableCollection<ComboBoxItem>()
            {
                new ComboBoxItem()
                {
                    ID = 1,
                    Name = "LyricYang"
                },
                new ComboBoxItem()
                {
                    ID= 2,
                    Name = "Microsoft"
                }
            };
            _userEntry = new ComboBoxItem()
            {
                ID = 1,
                Name = "LyricYang"
            };

            // Github Information
            _repos = new ObservableCollection<GithubRepo>();
            var content = HttpSearchAPI.GetGithubReposAsync("LyricYang").GetAwaiter().GetResult();
            dynamic repos = JsonConvert.DeserializeObject(content);

            foreach (var repo in repos)
            {
                _repos.Add(new GithubRepo()
                {
                    Name = repo.name,
                    Url = repo.html_url,
                    CreatedTime = repo.created_at,
                    Language = repo.language,
                    Watchers = repo.watchers,
                    Forks = repo.forks,
                });
            }

            _stars = _repos.Sum(t => t.Watchers);
            _forks = _repos.Sum(t => t.Forks);

            var userContent = HttpSearchAPI.GetGithubUserAsync("LyricYang").GetAwaiter().GetResult();
            dynamic user = JsonConvert.DeserializeObject(userContent);

            _user = new GithubUser()
            {
                UserName = user.login,
                Url = user.html_url,
                Company = user.company,
                ReposCount = user.public_repos,
                Followers = user.followers,
                CreatedTime = user.created_at,
                BIO = user.bio,
            };

            FollowingUserCollection = new ObservableCollection<FollowingModel>();
            var relationship = HttpSearchAPI.GetGithubUserRelationshipAsync("LyricYang", "following").GetAwaiter().GetResult();
            dynamic follows = JsonConvert.DeserializeObject(relationship);
            foreach (var f in follows)
            {
                FollowingUserCollection.Add(new FollowingModel()
                {
                    Name = f.login,
                    Avatar = f.avatar_url
                });
            }

            // MSFT stock
            var stock = HttpSearchAPI.GetUSAStockAsync("msft").GetAwaiter().GetResult();
            dynamic msft = JsonConvert.DeserializeObject(stock);

            _lastestPri = "$" + msft.result[0].data.lastestpri;
            _limit = msft.result[0].data.limit + "%";
            _minPri = "$" + msft.result[0].data.min52;
            _maxPri = "$" + msft.result[0].data.max52;

            // Gold price
            var gold = HttpSearchAPI.GetSHGoldAsync().GetAwaiter().GetResult();
            dynamic shGold = JsonConvert.DeserializeObject(gold);

            _AU99LastestPri = "￥" + shGold.result[0]["4"].latestpri;
            _AU99Limit = shGold.result[0]["4"].limit;
            _AU99MinPri = "￥" + shGold.result[0]["4"].minpri;
            _AU99MaxPri = "￥" + shGold.result[0]["4"].maxpri;
        }
    }
}