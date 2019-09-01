using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SAM.Common
{
    public class ThreadedWebView : Control
    {
        public ThreadedWebView()
        {
            this.DefaultStyleKey = typeof(ThreadedWebView);
        }

        #region SourceProperty

        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(string), typeof(ThreadedWebView), new PropertyMetadata(null, OnSourcePropertyChanged));

        private static void OnSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ThreadedWebView target)
            {
                target.OnSourceChanged(e.OldValue as string, e.NewValue as string);
            }
        }

        private void OnSourceChanged(string oldValue, string newValue)
        {
            if (_webView != null)
            {
                _webView.Source = new Uri(newValue);
            }
        }

        public string Source
        {
            get { return GetValue(SourceProperty) as string; }
            set { SetValue(SourceProperty, value); }
        }

        #endregion

        private Border _container = null;
        private WebView _webView = null;
        private ProgressRing _progressRing = null;

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _container = GetTemplateChild("WebViewContainer") as Border;
            _progressRing = GetTemplateChild("Progress") as ProgressRing;

            CreateWebView();
        }

        private void CreateWebView()
        {
            if (_container == null)
            {
                return;
            }
            _webView = new WebView(WebViewExecutionMode.SeparateThread);
            _webView.HorizontalAlignment = HorizontalAlignment.Stretch;
            _webView.VerticalAlignment = VerticalAlignment.Stretch;
            _webView.ContentLoading += WebView_ContentLoading;
            _webView.NavigationStarting += WebView_NavigationStarting;

            string s = Source;
            if (!string.IsNullOrEmpty(s))
            {
                _webView.Source = new Uri(s);
            }

            if (_progressRing != null)
            {
                _webView.Visibility = Visibility.Collapsed;
            }

            _container.Child = _webView;
        }

        private void WebView_ContentLoading(WebView sender, WebViewContentLoadingEventArgs args)
        {
            if (_progressRing != null)
            {
                _progressRing.Visibility = Visibility.Collapsed;
                _webView.Visibility = Visibility.Visible;
            }
        }

        private void WebView_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            if (_progressRing != null)
            {
                _webView.Visibility = Visibility.Collapsed;
                _progressRing.Visibility = Visibility.Visible;
            }
        }
    }
}
