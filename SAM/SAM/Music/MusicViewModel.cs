using SAM.DependencyContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace SAM.Music
{
    public class MusicViewModel : ViewModelBase
    {
        public MusicViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer) { }

        public event Action<MusicViewModel> MusicActivated;

        public void OnActivate(object sender, RoutedEventArgs e)
        {
            MusicActivated?.Invoke(this);
        }

        public event Action<MusicViewModel> MusicDeactivated;

        public void onDeactivate(object sender, RoutedEventArgs e)
        {
            MusicDeactivated?.Invoke(this);
        }

        public string InfoUrl
        {
            get { return "http://open.spotify.com/browse/featured"; }
        }
    }
}
