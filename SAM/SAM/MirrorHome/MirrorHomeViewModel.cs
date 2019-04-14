using SAM.DependencyContainer;
using SAM.Model;
using Windows.UI.Xaml;

namespace SAM.MirrorHome
{
    public class MirrorHomeViewModel : ViewModelBase
    {
        public MirrorHomeViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        { }

        public void OnHotelServicesClick(object sender, RoutedEventArgs e)
        {
            _dependencyContainer.GetDependency<ContentNavModel>().RequestContentNavigation(ContentNavMode.HotelServices);
        }
    }
}
