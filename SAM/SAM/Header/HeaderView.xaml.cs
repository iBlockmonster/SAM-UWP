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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace SAM.Header
{
    public sealed partial class HeaderView : UserControl
    {
        public HeaderView()
        {
            this.InitializeComponent();
        }

        #region ViewModelProperty

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register("ViewModel", typeof(HeaderViewModel), typeof(HeaderView), new PropertyMetadata(null));

        public HeaderViewModel ViewModel
        {
            get { return GetValue(ViewModelProperty) as HeaderViewModel; }
            set { SetValue(ViewModelProperty, value); }
        }

        #endregion
    }
}
