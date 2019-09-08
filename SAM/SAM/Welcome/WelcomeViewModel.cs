using SAM.DependencyContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace SAM.Welcome
{
    public class WelcomeViewModel : ViewModelBase
    {
        public WelcomeViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer) { }

        public event Action<WelcomeViewModel> WelcomeActivated;

        public void OnActivate(object sender, RoutedEventArgs e)
        {
            WelcomeActivated?.Invoke(this);
        }

        public event Action<WelcomeViewModel> WelcomeDeactivated;

        public void onDeactivate(object sender, RoutedEventArgs e)
        {
            WelcomeDeactivated?.Invoke(this);
        }

        public string CurrentDate
        {
            get
            {
                return DateTime.Now.ToString("MMMM dd yyyy");
            }
        }

        public string CurrentDay
        {
            get
            {
                return string.Format("It's {0}", DateTime.Now.ToString("dddd"));
            }
        }
    }
}
