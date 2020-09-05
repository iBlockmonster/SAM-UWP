using SAM.DependencyContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;


namespace SAM.Redit
{
    public class ReditViewModel : ViewModelBase
    {
        public ReditViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer) { }

        public event Action<ReditViewModel> ReditActivated;

        public void OnActivate(object sender, RoutedEventArgs e)
        {
            ReditActivated?.Invoke(this);
        }

        public event Action<ReditViewModel> ReditDeactivated;

        public void onDeactivate(object sender, RoutedEventArgs e)
        {
            ReditDeactivated?.Invoke(this);
        }

        public string InfoUrl
        {
            get { return "https://www.reddit.com/"; }
        }
    }
}
