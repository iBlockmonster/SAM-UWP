using SAM.DependencyContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace SAM.TikTok
{
    public class TikTokViewModel : ViewModelBase
    {
        public TikTokViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer) { }

        public event Action<TikTokViewModel> TikTokActivated;

        public void OnActivate(object sender, RoutedEventArgs e)
        {
            TikTokActivated?.Invoke(this);
        }

        public event Action<TikTokViewModel> TikTokDeactivated;

        public void onDeactivate(object sender, RoutedEventArgs e)
        {
            TikTokDeactivated?.Invoke(this);
        }

        public string InfoUrl
        {
            get { return "https://www.tiktok.com/"; }
        }
    }
}
