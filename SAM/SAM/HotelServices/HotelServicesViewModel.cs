using SAM.DependencyContainer;
using SAM.Model;
using Windows.UI.Xaml;

namespace SAM.HotelServices
{
    public class HotelServicesViewModel : ViewModelBase
    {
        public HotelServicesViewModel(IDependencyContainer depdendencyContainer) : base(depdendencyContainer)
        { }

        public void OnMirrorHomeClick(object sender, RoutedEventArgs e)
        {
            _dependencyContainer.GetDependency<ContentNavModel>().RequestContentNavigation(ContentNavMode.MirrorHome);
        }

        public void OnYelpClick(object sender, RoutedEventArgs e)
        {
            _dependencyContainer.GetDependency<ContentNavModel>().RequestContentNavigation(ContentNavMode.Yelp);
        }

        public void OnRoomServiceClick(object sender, RoutedEventArgs e)
        {
            _dependencyContainer.GetDependency<ContentNavModel>().RequestContentNavigation(ContentNavMode.RoomService);
        }

        public void OnSpaClick(object sender, RoutedEventArgs e)
        {
            _dependencyContainer.GetDependency<ContentNavModel>().RequestContentNavigation(ContentNavMode.Spa);
        }
    }
}
