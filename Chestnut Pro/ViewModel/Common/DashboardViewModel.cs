namespace Chestnut_Pro.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Chestnut_Pro.Model;
    using Chestnut_Pro.Service;
    using Newtonsoft.Json;

    /// <summary>
    /// Dashboard View Model
    /// </summary>
    public class DashboardViewModel : ViewModelBase
    {
        private ObservableCollection<AgendaModel> _todayAgenda;

        public ObservableCollection<AgendaModel> TodayAgenda
        {
            get { return _todayAgenda; }
            set { _todayAgenda = value; OnPropertyChanged(); }
        }

        private ObservableCollection<AgendaModel> _finishAgenda;

        public ObservableCollection<AgendaModel> FinishAgenda
        {
            get { return _finishAgenda; }
            set { _finishAgenda = value; OnPropertyChanged(); }
        }

        private ObservableCollection<GithubRepo> _repos;

        /// <summary>
        /// Data Source
        /// </summary>
        public ObservableCollection<GithubRepo> Repos
        {
            get { return _repos; }
            set { _repos = value; OnPropertyChanged(); }
        }

        private int _stars;

        public int Stars
        {
            get { return _stars; }
            set { _stars = value; OnPropertyChanged(); }
        }

        private int _forks;

        public int Forks
        {
            get { return _forks; }
            set { _forks = value; OnPropertyChanged(); }
        }

        private GithubUser _user;

        public GithubUser User
        {
            get { return _user; }
            set { _user = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Stock
        /// </summary>
        private string _lastestPri;

        public string LastestPri
        {
            get { return _lastestPri; }
            set { _lastestPri = value; OnPropertyChanged(); }
        }

        private string _limit;

        public string Limit
        {
            get { return _limit; }
            set { _limit = value; OnPropertyChanged(); }
        }

        private string _maxPri;

        public string MaxPri
        {
            get { return _maxPri; }
            set { _maxPri = value; OnPropertyChanged(); }
        }

        private string _minPri;

        public string MinPri
        {
            get { return _minPri; }
            set { _minPri = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Gold
        /// </summary>
        private string _AU99LastestPri;

        public string AU99LastestPri
        {
            get { return _AU99LastestPri; }
            set { _AU99LastestPri = value; OnPropertyChanged(); }
        }

        private string _AU99Limit;

        public string AU99Limit
        {
            get { return _AU99Limit; }
            set { _AU99Limit = value; OnPropertyChanged(); }
        }

        private string _AU99MaxPri;

        public string AU99MaxPri
        {
            get { return _AU99MaxPri; }
            set { _AU99MaxPri = value; OnPropertyChanged(); }
        }

        private string _AU99MinPri;

        public string AU99MinPri
        {
            get { return _AU99MinPri; }
            set { _AU99MinPri = value; OnPropertyChanged(); }
        }

        public ObservableCollection<FollowingModel> FollowingUserCollection { get; set; }

        public DashboardViewModel()
        {
            _todayAgenda = new ObservableCollection<AgendaModel>();
            _finishAgenda = new ObservableCollection<AgendaModel>();

            var agendaJson = FileUtils.ReadJsonFile(AppDomain.CurrentDomain.BaseDirectory + "\\Data\\Agenda.json");
            var todayData = agendaJson.Agenda[DateTime.Now.Date.ToString("yyyyMMdd")];

            if (todayData != null)
            {
                foreach (var agenda in todayData.agency)
                {
                    _todayAgenda.Add(new AgendaModel()
                    {
                        AgendaId = agenda.id,
                        Title = agenda.title,
                        Content = agenda.content,
                        From = agenda.from,
                        To = agenda.to,
                    });
                }

                foreach (var agenda in todayData.finish)
                {
                    _finishAgenda.Add(new AgendaModel()
                    {
                        AgendaId = agenda.id,
                        Title = agenda.title,
                        Content = agenda.content,
                        From = agenda.from,
                        To = agenda.to,
                    });
                }
            }

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