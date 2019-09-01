using SAM.DependencyContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace SAM.RoomService
{
    public class RoomServiceViewModel : ViewModelBase
    {
        public RoomServiceViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer) { }

        public event Action<RoomServiceViewModel> RoomServiceActivated;

        public void OnActivate(object sender, RoutedEventArgs e)
        {
            RoomServiceActivated?.Invoke(this);
        }
    }
}
