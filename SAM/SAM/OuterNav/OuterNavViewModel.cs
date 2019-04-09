using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SAM.OuterNav
{
    public class OuterNavViewModel : INotifyPropertyChanged
    {
        public OuterNavViewModel(object currentContent)
        {
            _currentContentViewModel = currentContent;
        }

        private object _currentContentViewModel;
        public object CurrentContentViewModel
        {
            get { return _currentContentViewModel; }
            set
            {
                if(_currentContentViewModel != value)
                {
                    _currentContentViewModel = value;
                    RaisePropertyChangedFromSource();

                    ContentViewModelChanged?.Invoke(_currentContentViewModel);
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
