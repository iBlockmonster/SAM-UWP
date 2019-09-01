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

namespace SAM.Music
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MusicView : Page
    {
        public MusicView()
        {
            this.InitializeComponent();
        }

        #region ViewModelProperty

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register("ViewModel", typeof(MusicViewModel), typeof(MusicView), new PropertyMetadata(null));

        public MusicViewModel ViewModel
        {
            get { return GetValue(ViewModelProperty) as MusicViewModel; }
            set { SetValue(ViewModelProperty, value); }
        }

        #endregion

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            ViewModel = e.Parameter as MusicViewModel;
        }

        private void WebView_ContentLoading(WebView sender, WebViewContentLoadingEventArgs args)
        {
            Progress.Visibility = Visibility.Collapsed;
            YelpContent.Visibility = Visibility.Visible;
        }

        private void WebView_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            YelpContent.Visibility = Visibility.Collapsed;
            Progress.Visibility = Visibility.Visible;
        }

        private void WebView_NavigationFailed(object sender, WebViewNavigationFailedEventArgs e)
        {
            // TODO
        }
    }
}
