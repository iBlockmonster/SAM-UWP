﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace SAM.Instagram
{
    public sealed partial class InstgramView : UserControl
    {
        public InstgramView()
        {
            this.InitializeComponent();
        }

        #region ViewModelProperty

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register("ViewModel", typeof(InstagramViewModel), typeof(InstgramView), new PropertyMetadata(null));

        public InstagramViewModel ViewModel
        {
            get { return GetValue(ViewModelProperty) as InstagramViewModel; }
            set { SetValue(ViewModelProperty, value); }
        }

        #endregion

    }
}