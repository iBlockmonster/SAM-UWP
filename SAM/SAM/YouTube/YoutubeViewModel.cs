using SAM.DependencyContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;


namespace SAM.YouTube
{
    public class YoutubeViewModel : ViewModelBase
    {
        public YoutubeViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer) { }

        public event Action<YoutubeViewModel> YoutubeActivated;

        public void OnActivate(object sender, RoutedEventArgs e)
        {
            YoutubeActivated?.Invoke(this);
        }

        public event Action<YoutubeViewModel> YoutubeDeactivated;

        public void onDeactivate(object sender, RoutedEventArgs e)
        {
            YoutubeDeactivated?.Invoke(this);
        }

        public string InfoUrl
        {
            get { return "https://www.youtube.com/"; }
        }
    }
}
