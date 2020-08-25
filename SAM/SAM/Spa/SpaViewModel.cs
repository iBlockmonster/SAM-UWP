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

        public event Action<SpaViewModel> SpaDeactivated;

        public void onDeactivate(object sender, RoutedEventArgs e)
        {
            SpaDeactivated?.Invoke(this);
        }

        public string InfoUrl
        {
            get { return "https://www.facebook.com"; }
        }
    }
}
