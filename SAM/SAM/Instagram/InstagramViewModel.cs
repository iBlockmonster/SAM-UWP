using SAM.DependencyContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace SAM.Instagram
{ 
    public class InstagramViewModel : ViewModelBase
    {
        public InstagramViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer) { }

        public event Action<InstagramViewModel> InstagramActivated;

        public void OnActivate(object sender, RoutedEventArgs e)
        {
            InstagramActivated?.Invoke(this);
        }

        public event Action<InstagramViewModel> InstagramDeactivated;

        public void onDeactivate(object sender, RoutedEventArgs e)
        {
            InstagramDeactivated?.Invoke(this);
        }

        public string InfoUrl
        {
            get { return "https://www.instagram.com"; }
        }
    }
}
