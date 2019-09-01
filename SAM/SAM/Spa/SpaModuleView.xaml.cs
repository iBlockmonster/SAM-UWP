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

namespace SAM.Spa
{
    public sealed partial class SpaModuleView : UserControl
    {
        public SpaModuleView()
        {
            this.InitializeComponent();
        }

        #region ViewModelProperty

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register("ViewModel", typeof(SpaViewModel), typeof(SpaModuleView), new PropertyMetadata(null));

        public SpaViewModel ViewModel
        {
            get { return GetValue(ViewModelProperty) as SpaViewModel; }
            set { SetValue(ViewModelProperty, value); }
        }

        #endregion
    }
}
