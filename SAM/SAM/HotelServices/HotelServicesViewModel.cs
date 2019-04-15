using SAM.DependencyContainer;
using SAM.Model;
using System.Collections.Generic;
using Windows.UI.Xaml;

namespace SAM.HotelServices
{
    public class HotelServicesViewModel : ViewModelBase
    {
        public HotelServicesViewModel(IDependencyContainer depdendencyContainer) : base(depdendencyContainer)
        {
            _dependencyContainer.StateChanged += _dependencyContainer_StateChanged;
        }

        private void _dependencyContainer_StateChanged(IDependencyContainer source, DependencyContainerState state)
        {
            if (state == DependencyContainerState.Initialized)
            {
                _dependencyContainer.StateChanged -= _dependencyContainer_StateChanged;
                var yelpModel = _dependencyContainer.GetDependency<YelpModel>();
                LocalBusinesses = yelpModel.LocalDelivery;
                yelpModel.StateChanged += YelpModel_StateChanged;
            }
        }

        private void YelpModel_StateChanged(YelpModel source, YelpState state)
        {
            if (state == YelpState.Ready)
            {
                LocalBusinesses = source.LocalDelivery;
            }
        }

        private List<BusinessData> _localBusinesses;
        public List<BusinessData> LocalBusinesses
        {
            get { return _localBusinesses; }
            private set
            {
                if (_localBusinesses != value)
                {
                    _localBusinesses = value;
                    RaisePropertyChangedFromSource();
                }
            }
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
