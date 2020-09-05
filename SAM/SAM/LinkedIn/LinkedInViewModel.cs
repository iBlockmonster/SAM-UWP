using SAM.DependencyContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace SAM.LinkedIn
{
    public class LinkedInViewModel : ViewModelBase
    {
        public LinkedInViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer) { }

        public event Action<LinkedInViewModel> LinkedInActivated;

        public void OnActivate(object sender, RoutedEventArgs e)
        {
            LinkedInActivated?.Invoke(this);
        }

        public event Action<LinkedInViewModel> LinkedInDeactivated;

        public void onDeactivate(object sender, RoutedEventArgs e)
        {
            LinkedInDeactivated?.Invoke(this);
        }

        public string InfoUrl
        {
            get { return "https://www.linkedin.com"; }
        }
    }
}
