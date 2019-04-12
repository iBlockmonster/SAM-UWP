using SAM.DependencyContainer;
using System;

namespace SAM.OuterNav
{
    public class OuterNavViewModel : ViewModelBase
    {
        public OuterNavViewModel(IDependencyContainer dependencyContainer, object startingContent) : base(dependencyContainer)
        {
            _contentViewModel = startingContent;
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
