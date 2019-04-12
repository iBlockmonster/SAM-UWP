using SAM.DependencyContainer;
using SAM.Model;
using Windows.UI.Xaml;

namespace SAM.HotelServices
{
    public class HotelServicesViewModel : ViewModelBase
    {
        public HotelServicesViewModel(IDependencyContainer depdendencyContainer) : base(depdendencyContainer)
        { }

        public void OnLockConfigClick(object sender, RoutedEventArgs e)
        {
            _dependencyContainer.GetDependency<ContentNavModel>("ContentNavModel").RequestContentNavigation(ContentNavMode.LockConfig);
        }
    }
}
