﻿using SAM.DependencyContainer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SAM
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public ViewModelBase(IDependencyContainer dependencyContainer)
        {
            if(dependencyContainer == null)
            {
                throw new ArgumentNullException("dependencyContainer");
            }
            _dependencyContainer = dependencyContainer;
        }

        protected IDependencyContainer _dependencyContainer;

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        protected void RaisePropertyChangedFromSource([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }

    // This is to work around the bug in ContentControl where a data bound value that gets set to null will not call SelectTemplateCore after the iniital load
    public class NullViewModel : ViewModelBase
    {
        public NullViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer) { }
    }
}
