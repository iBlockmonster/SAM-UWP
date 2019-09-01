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

namespace SAM.Music
{
    public sealed partial class MusicView : UserControl
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

        //private WebView _webView = null;

        //private void ControlLoaded(object sender, RoutedEventArgs e)
        //{
        //    _webView = new WebView(WebViewExecutionMode.SeparateThread);
        //    _webView.Visibility = Visibility.Collapsed;
        //    _webView.HorizontalAlignment = HorizontalAlignment.Stretch;
        //    _webView.VerticalAlignment = VerticalAlignment.Stretch;
        //    _webView.ContentLoading += WebView_ContentLoading;
        //    _webView.NavigationStarting += WebView_NavigationStarting;
        //    _webView.Source = new Uri(ViewModel.InfoUrl);

        //    ContentContainer.Children.Add(_webView);
        //}

        //private void ControlUnloaded(object sender, RoutedEventArgs e)
        //{

        //}

        //private void WebView_ContentLoading(WebView sender, WebViewContentLoadingEventArgs args)
        //{
        //    Progress.Visibility = Visibility.Collapsed;
        //    _webView.Visibility = Visibility.Visible;
        //}

        //private void WebView_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        //{
        //    _webView.Visibility = Visibility.Collapsed;
        //    Progress.Visibility = Visibility.Visible;
        //}
    }
}
