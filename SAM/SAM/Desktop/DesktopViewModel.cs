using SAM.Menu;
using SAM.Taskbar;
using SAM.Header;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SAM.Desktop
{
    public class DesktopViewModel : INotifyPropertyChanged
    {
        public DesktopViewModel(HeaderViewModel header, TaskbarViewModel taskbar, MenuViewModel menu, object startingContentViewModel)
        {
            if (header == null)
            {
                throw new ArgumentNullException("header");
            }
            if (taskbar == null)
            {
                throw new ArgumentNullException("taskbar");
            }
            if (menu == null)
            {
                throw new ArgumentNullException("menu");
            }
            _headerViewModel = header;

            _taskbarViewModel = taskbar;
            _taskbarViewModel.MenuRequested += _taskbarViewModel_MenuRequested;

            _menuViewModel = menu;

            _contentViewModel = startingContentViewModel;
        }

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

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void RaisePropertyChangedFromSource([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
