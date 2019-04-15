using SAM.Menu;
using SAM.Taskbar;
using SAM.Header;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SAM.Model;
using SAM.DependencyContainer;

namespace SAM.Desktop
{
    public class DesktopViewModel : ViewModelBase
    {
        public DesktopViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            _dependencyContainer.StateChanged += _dependencyContainer_StateChanged;
        }

        private void _dependencyContainer_StateChanged(IDependencyContainer source, DependencyContainerState state)
        {
            if (state == DependencyContainerState.Initialized)
            {
                _dependencyContainer.StateChanged -= _dependencyContainer_StateChanged;

                _contentNavModel = _dependencyContainer.GetDependency<ContentNavModel>();
                _contentNavModel.ContentChanged += _contentNavModel_ContentChanged;

                _headerViewModel = _dependencyContainer.GetDependency<HeaderViewModel>();

                _taskbarViewModel = _dependencyContainer.GetDependency<TaskbarViewModel>();
                _taskbarViewModel.MenuRequested += _taskbarViewModel_MenuRequested;

                _menuViewModel = _dependencyContainer.GetDependency<MenuViewModel>();
            }
        }

        private ContentNavModel _contentNavModel;

        private void _contentNavModel_ContentChanged(ContentNavMode obj)
        {
            ContentViewModelChanged?.Invoke(_contentNavModel.CurrentViewModel);
        }

        public object ContentViewModel
        {
            get { return _contentNavModel.CurrentViewModel; }
        }

        public event Action<object> ContentViewModelChanged;

        private HeaderViewModel _headerViewModel;
        public HeaderViewModel HeaderViewModel
        {
            get { return _headerViewModel; }
        }

        private TaskbarViewModel _taskbarViewModel;
        public TaskbarViewModel TaskbarViewModel
        {
            get { return _taskbarViewModel; }
        }

        private void _taskbarViewModel_MenuRequested()
        {
            ShowMenu = !_showMenu;
        }

        private MenuViewModel _menuViewModel;
        public MenuViewModel MenuViewModel
        {
            get { return _menuViewModel; }
        }

        private bool _showMenu = false;
        public bool ShowMenu
        {
            get { return _showMenu; }
            set
            {
                if (_showMenu != value)
                {
                    _showMenu = value;
                    RaisePropertyChangedFromSource();

                    ShowMenuChanged?.Invoke(_showMenu);
                }
            }
        }

        public event Action<bool> ShowMenuChanged;
    }
}
