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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SAM.Desktop
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DesktopView : Page
    {
        public DesktopView()
        {
            this.InitializeComponent();
        }

        #region ViewModelProperty

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register("ViewModel", typeof(DesktopViewModel), typeof(DesktopView), new PropertyMetadata(null));

        public DesktopViewModel ViewModel
        {
            get { return GetValue(ViewModelProperty) as DesktopViewModel; }
            set { SetValue(ViewModelProperty, value); }
        }

        #endregion

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            ViewModel = e.Parameter as DesktopViewModel;
        }
    }
}
