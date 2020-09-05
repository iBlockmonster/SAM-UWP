using SAM.DependencyContainer;
using SAM.Desktop;
using SAM.Model;
using SAM.Twitter;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace SAM.Menu
{
    public class MenuViewModel : ViewModelBase
    {
        public MenuViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
        }

        public void OnTwitterClick(object sender, RoutedEventArgs e)
        {
            _dependencyContainer.GetDependency<DesktopViewModel>().ShowMenu = false;
            _dependencyContainer.GetDependency<ContentNavModel>().RequestContentNavigation(ContentNavMode.HotelServices);
            _dependencyContainer.GetDependency<TwitterViewModel>().OnActivate(sender, e);
        }
    }
}
