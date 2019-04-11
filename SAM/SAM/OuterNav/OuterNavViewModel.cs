using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SAM.OuterNav
{
    public class OuterNavViewModel : INotifyPropertyChanged
    {
        public OuterNavViewModel(object startingContent)
        {
            contentViewModel = startingContent;
        }

        private object contentViewModel;
        public object ContentViewModel
        {
            get { return contentViewModel; }
            set
            {
                if (contentViewModel != value)
                {
                    contentViewModel = value;
                    RaisePropertyChangedFromSource();

                    ContentViewModelChanged?.Invoke(contentViewModel);
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
