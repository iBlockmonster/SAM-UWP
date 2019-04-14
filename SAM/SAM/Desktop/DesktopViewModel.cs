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
            _contentNavModel = _dependencyContainer.GetDependency<ContentNavModel>();
            _contentNavModel.ContentChanged += _contentNavModel_ContentChanged;

            _headerViewModel = _dependencyContainer.GetDependency<HeaderViewModel>();

            _taskbarViewModel = _dependencyContainer.GetDependency<TaskbarViewModel>();
            _taskbarViewModel.MenuRequested += _taskbarViewModel_MenuRequested;

            _menuViewModel = _dependencyContainer.GetDependency<MenuViewModel>();
        }

        private readonly ContentNavModel _contentNavModel;

        private void _contentNavModel_ContentChanged(ContentNavMode obj)
        {
            ContentViewModelChanged?.Invoke(_contentNavModel.CurrentViewModel);
        }

        public object ContentViewModel
        {
            get { return _contentNavModel.CurrentViewModel; }
        }

        public event Action<object> ContentViewModelChanged;

        private readonly HeaderViewModel _headerViewModel;
        public HeaderViewModel HeaderViewModel
        {
            get { return _headerViewModel; }
        }

        private readonly TaskbarViewModel _taskbarViewModel;
        public TaskbarViewModel TaskbarViewModel
        {
            get { return _taskbarViewModel; }
        }

        private void _taskbarViewModel_MenuRequested()
        {
            ShowMenu = !_showMenu;
        }

        private readonly MenuViewModel _menuViewModel;
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
