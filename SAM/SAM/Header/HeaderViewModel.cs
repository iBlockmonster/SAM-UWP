using SAM.DependencyContainer;
using SAM.Model;
using System;
using Windows.UI.Xaml;

namespace SAM.Header
{
    public class HeaderViewModel : ViewModelBase
    {
        public HeaderViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        { }

        public void OnHomeClick(object sender, RoutedEventArgs e)
        {
            _dependencyContainer.GetDependency<ContentNavModel>().RequestContentNavigation(ContentNavMode.MirrorHome);
        }
    }
}
