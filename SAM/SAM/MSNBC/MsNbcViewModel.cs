using SAM.DependencyContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace SAM.MSNBC
{
    public class MsNbcViewModel : ViewModelBase
    {
        public MsNbcViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer) { }

        public event Action<MsNbcViewModel> MsNbcActivated;

        public void OnActivate(object sender, RoutedEventArgs e)
        {
            MsNbcActivated?.Invoke(this);
        }

        public event Action<MsNbcViewModel> MsNbcDeactivated;

        public void onDeactivate(object sender, RoutedEventArgs e)
        {
            MsNbcDeactivated?.Invoke(this);
        }

        public string InfoUrl
        {
            get { return "https://www.msnbc.com/"; }
        }
    }
}
