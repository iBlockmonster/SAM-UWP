using SAM.Menu;
using SAM.Taskbar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SAM.Desktop
{
    public class DesktopViewModel : INotifyPropertyChanged
    {
        public DesktopViewModel(TaskbarViewModel taskbar, MenuViewModel menu)
        {
            if (taskbar == null)
            {
                throw new ArgumentNullException("taskbar");
            }
            _taskbarViewModel = taskbar;
            _taskbarViewModel.MenuRequested += _taskbarViewModel_MenuRequested;

            _menuViewModel = menu;
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
