using System;
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

namespace SAM.Yelp
{
    public sealed partial class YelpView : UserControl
    {
        public YelpView()
        {
            this.InitializeComponent();
        }

        #region ViewModelProperty

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register("ViewModel", typeof(YelpViewModel), typeof(YelpView), new PropertyMetadata(null));

        public YelpViewModel ViewModel
        {
            get { return GetValue(ViewModelProperty) as YelpViewModel; }
            set { SetValue(ViewModelProperty, value); }
        }

        #endregion
    }
}
