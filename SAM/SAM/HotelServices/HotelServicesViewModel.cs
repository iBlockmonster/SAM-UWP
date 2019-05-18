using SAM.DependencyContainer;
using SAM.Model;
using SAM.Yelp;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace SAM.HotelServices
{
    public class HotelServicesViewModel : ViewModelBase
    {
        public HotelServicesViewModel(IDependencyContainer depdendencyContainer) : base(depdendencyContainer)
        {
            _ = WaitForInit();
        }

        private async Task WaitForInit()
        {
            await _dependencyContainer.WaitForInitComplete();
            _yelpModel = _dependencyContainer.GetDependency<YelpModel>();
            _newsModel = _dependencyContainer.GetDependency<NewsModel>();

            _ = LoadYelpData();
            _ = LoadNewsData();
        }

        #region Yelp

        private async Task LoadYelpData()
        {
            if (_localBusinesses != null)
            {
                foreach (var business in _localBusinesses)
                {
                    business.Activated -= Business_Activated;
                }
            }
            var localBusinesses = await _yelpModel.GetLocalDelivery();
            foreach (var business in localBusinesses)
            {
                business.Activated += Business_Activated;
            }

            LocalBusinesses = await _yelpModel.GetLocalDelivery();
        }

        private void Business_Activated(BusinessData obj)
        {
            var yelpDetailsModel = _dependencyContainer.GetDependency<YelpViewModel>();
            yelpDetailsModel.ActiveBusiness = obj;
            var navModel = _dependencyContainer.GetDependency<ContentNavModel>();
            navModel.RequestContentNavigation(ContentNavMode.Yelp);
        }

        private YelpModel _yelpModel;

        private IReadOnlyList<BusinessData> _localBusinesses;
        public IReadOnlyList<BusinessData> LocalBusinesses
        {
            get { return _localBusinesses; }
            private set
            {
                if (_localBusinesses != value)
                {
                    _localBusinesses = value;
                    RaisePropertyChangedFromSource();
                    RaisePropertyChanged("IsYelpDataLoading");
                }
            }
        }

        public bool IsYelpDataLoading
        {
            get { return _localBusinesses == null || _localBusinesses.Count == 0; }
        }

        #endregion

        #region News

        private NewsModel _newsModel;

        private async Task LoadNewsData()
        {
            TopNewsHeadlines = await _newsModel.GetTopHeadlines();
        }

        private IReadOnlyList<NewsArticleData> _topNewsHeadlines;
        public IReadOnlyList<NewsArticleData> TopNewsHeadlines
        {
            get { return _topNewsHeadlines; }
            private set
            {
                if (_topNewsHeadlines != value)
                {
                    _topNewsHeadlines = value;
                    RaisePropertyChangedFromSource();
                    RaisePropertyChanged("IsNewsDataLoading");
                }
            }
        }

        public bool IsNewsDataLoading
        {
            get { return _topNewsHeadlines == null || _topNewsHeadlines.Count == 0; }
        }

        #endregion

        public void OnMirrorHomeClick(object sender, RoutedEventArgs e)
        {
            _dependencyContainer.GetDependency<ContentNavModel>().RequestContentNavigation(ContentNavMode.MirrorHome);
        }

        public void OnRoomServiceClick(object sender, RoutedEventArgs e)
        {
            _dependencyContainer.GetDependency<ContentNavModel>().RequestContentNavigation(ContentNavMode.RoomService);
        }

        public void OnSpaClick(object sender, RoutedEventArgs e)
        {
            _dependencyContainer.GetDependency<ContentNavModel>().RequestContentNavigation(ContentNavMode.Spa);
        }

        public void OnMusicClick(object sender, RoutedEventArgs e)
        {
            _dependencyContainer.GetDependency<ContentNavModel>().RequestContentNavigation(ContentNavMode.Music);
        }
    }
}
