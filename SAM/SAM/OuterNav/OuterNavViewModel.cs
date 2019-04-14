using SAM.DependencyContainer;
using SAM.Desktop;
using System;

namespace SAM.OuterNav
{
    public class OuterNavViewModel : ViewModelBase
    {
        public OuterNavViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            _dependencyContainer.StateChanged += _dependencyContainer_StateChanged;
        }

        private void _dependencyContainer_StateChanged(IDependencyContainer source, DependencyContainerState state)
        {
            if (state == DependencyContainerState.Initialized)
            {
                _dependencyContainer.StateChanged -= _dependencyContainer_StateChanged;
                _contentViewModel = _dependencyContainer.GetDependency<DesktopViewModel>();
            }
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
