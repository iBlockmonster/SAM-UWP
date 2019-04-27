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
