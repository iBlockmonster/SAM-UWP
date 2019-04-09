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
        public DesktopViewModel(TaskbarViewModel taskbar)
        {
            _taskbarViewModel = taskbar;
        }

        private TaskbarViewModel _taskbarViewModel;
        public TaskbarViewModel TaskbarViewModel
        {
            get { return _taskbarViewModel; }
        }

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
