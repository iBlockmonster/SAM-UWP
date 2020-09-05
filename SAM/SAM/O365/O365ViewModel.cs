using SAM.DependencyContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace SAM.O365
{
    public class O365ViewModel : ViewModelBase
    {
        public O365ViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer) { }

        public event Action<O365ViewModel> O365Activated;

        public void OnActivate(object sender, RoutedEventArgs e)
        {
            O365Activated?.Invoke(this);
        }

        public event Action<O365ViewModel> O365Deactivated;

        public void onDeactivate(object sender, RoutedEventArgs e)
        {
            O365Deactivated?.Invoke(this);
        }

        public string InfoUrl
        {
            get { return "http://office.com"; }
        }
    }
}
