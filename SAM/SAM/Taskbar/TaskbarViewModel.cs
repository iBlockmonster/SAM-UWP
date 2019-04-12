using SAM.DependencyContainer;
using System;
using Windows.UI.Xaml;

namespace SAM.Taskbar
{
    public class TaskbarViewModel : ViewModelBase
    {
        public TaskbarViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        { }

        public void OnClick(object sender, RoutedEventArgs e)
        {
            MenuRequested?.Invoke();
        }

        public event Action MenuRequested;
    }
}
