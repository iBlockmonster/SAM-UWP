using SAM.DependencyContainer;
using SAM.Desktop;
using System;
using System.Threading.Tasks;

namespace SAM.OuterNav
{
    public class OuterNavViewModel : ViewModelBase
    {
        public OuterNavViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            _ = WaitForInit();
        }

        private async Task WaitForInit()
        {
            await _dependencyContainer.WaitForInitComplete();
            ContentViewModel = _dependencyContainer.GetDependency<DesktopViewModel>();
        }

        private object _contentViewModel;
        public object ContentViewModel
        {
            get { return _contentViewModel; }
            set
            {
                if (_contentViewModel != value)
                {
                    _contentViewModel = value;
                    RaisePropertyChangedFromSource();

                    ContentViewModelChanged?.Invoke(_contentViewModel);
                }
            }
        }

        public event Action<object> ContentViewModelChanged;
    }
}
