using SAM.DependencyContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace SAM.Spa
{
    public class SpaViewModel : ViewModelBase
    {
        public SpaViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer) { }

        public event Action<SpaViewModel> SpaActivated;

        public void OnActivate(object sender, RoutedEventArgs e)
        {
            SpaActivated?.Invoke(this);
        }

        public string InfoUrl
        {
            get { return "https://www.marriott.com/hotel/vacation-packages/spa-getaways.mi"; }
        }
    }
}
