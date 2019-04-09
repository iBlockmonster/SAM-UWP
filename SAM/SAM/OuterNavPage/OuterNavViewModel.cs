using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SAM.OuterNav
{
    public class OuterNavViewModel : INotifyPropertyChanged
    {
        public OuterNavViewModel()
        {
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
