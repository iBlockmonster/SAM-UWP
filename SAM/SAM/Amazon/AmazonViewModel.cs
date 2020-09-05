using SAM.DependencyContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;


namespace SAM.Amazon
{

    public class AmazonViewModel : ViewModelBase
    {
        public AmazonViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer) { }

        public event Action<AmazonViewModel> AmazonActivated;

        public void OnActivate(object sender, RoutedEventArgs e)
        {
            AmazonActivated?.Invoke(this);
        }

        public event Action<AmazonViewModel> AmazonDeactivated;

        public void onDeactivate(object sender, RoutedEventArgs e)
        {
            AmazonDeactivated?.Invoke(this);
        }

        public string InfoUrl
        {
            get { return "https://www.amazon.com"; }
        }
    }
}
