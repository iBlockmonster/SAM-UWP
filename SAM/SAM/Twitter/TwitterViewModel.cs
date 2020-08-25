using SAM.DependencyContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace SAM.Twitter
{
    public class TwitterViewModel : ViewModelBase
    {
        public TwitterViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer) { }

        public event Action<TwitterViewModel> TwitterActivated;

        public void OnActivate(object sender, RoutedEventArgs e)
        {
            TwitterActivated?.Invoke(this);
        }

        public event Action<TwitterViewModel> TwitterDeactivated;

        public void onDeactivate(object sender, RoutedEventArgs e)
        {
            TwitterDeactivated?.Invoke(this);
        }

        public string InfoUrl
        {
            get { return "https://www.twitter.com"; }
        }
    }
}
