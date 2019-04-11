using SAM.HotelServices;
using System;
using System.Numerics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;
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

            var menuVisual = ElementCompositionPreview.GetElementVisual(Menu);
            menuVisual.Opacity = 0f;
            menuVisual.Scale = new Vector3(0f, 0f, 1f);
        }

        #region ViewModelProperty

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register("ViewModel", typeof(DesktopViewModel), typeof(DesktopView), new PropertyMetadata(null, OnDesktopViewModelPropertyChanged));

        private static void OnDesktopViewModelPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DesktopView target)
            {
                target.OnDesktopViewModelChanged(e.OldValue as DesktopViewModel, e.NewValue as DesktopViewModel);
            }
        }

        private void OnDesktopViewModelChanged(DesktopViewModel oldValue, DesktopViewModel newValue)
        {
            if(oldValue != null)
            {
                newValue.ShowMenuChanged -= ViewModel_ShowMenuChanged;
                newValue.ContentViewModelChanged -= ViewModel_ContentViewModelChanged;

                NavigateToViewModel(null);
            }
            if(newValue != null)
            {
                newValue.ShowMenuChanged += ViewModel_ShowMenuChanged;
                newValue.ContentViewModelChanged += ViewModel_ContentViewModelChanged;

                NavigateToViewModel(ViewModel.ContentViewModel);
            }
        }

        private void ViewModel_ShowMenuChanged(bool showMenu)
        {
            if(showMenu)
            {
                AnimateMenuShow();
            }
            else
            {
                AnimateMenuHide();
            }
        }

        private void ViewModel_ContentViewModelChanged(object contentViewModel)
        {
            NavigateToViewModel(contentViewModel);
        }

        private void AnimateMenuShow()
        {
            var compositor = Window.Current.Compositor;

            var easingFunction = compositor.CreateCubicBezierEasingFunction(new Vector2(0.1f, 0.9f), new Vector2(0.2f, 1f));
            var duration = TimeSpan.FromMilliseconds(300);

            var menuVisual = ElementCompositionPreview.GetElementVisual(Menu);

            var menuVisualOpacityAnim = compositor.CreateScalarKeyFrameAnimation();
            menuVisualOpacityAnim.Target = "Opacity";
            menuVisualOpacityAnim.Duration = duration;
            menuVisualOpacityAnim.InsertKeyFrame(1f, 1f, easingFunction);

            var menuVisualScaleAnim = compositor.CreateVector3KeyFrameAnimation();
            menuVisualScaleAnim.Target = "Scale";
            menuVisualScaleAnim.Duration = duration;
            menuVisualScaleAnim.InsertKeyFrame(1f, new Vector3(1f, 1f, 1f));

            menuVisual.StartAnimation(menuVisualOpacityAnim.Target, menuVisualOpacityAnim);
            menuVisual.StartAnimation(menuVisualScaleAnim.Target, menuVisualScaleAnim);

            Menu.Visibility = Visibility.Visible;
        }

        private void AnimateMenuHide()
        {
            var compositor = Window.Current.Compositor;

            var easingFunction = compositor.CreateCubicBezierEasingFunction(new Vector2(0.7f, 0.0f), new Vector2(1.0f, 0.5f));
            var duration = TimeSpan.FromMilliseconds(300);

            var menuVisual = ElementCompositionPreview.GetElementVisual(Menu);

            var menuVisualOpacityAnim = compositor.CreateScalarKeyFrameAnimation();
            menuVisualOpacityAnim.Target = "Opacity";
            menuVisualOpacityAnim.Duration = duration;
            menuVisualOpacityAnim.InsertKeyFrame(1f, 0f, easingFunction);

            var menuVisualScaleAnim = compositor.CreateVector3KeyFrameAnimation();
            menuVisualScaleAnim.Target = "Scale";
            menuVisualScaleAnim.Duration = duration;
            menuVisualScaleAnim.InsertKeyFrame(1f, new Vector3(0f, 0f, 1f));

            var scopedBatch = compositor.CreateScopedBatch(Windows.UI.Composition.CompositionBatchTypes.Animation);

            menuVisual.StartAnimation(menuVisualOpacityAnim.Target, menuVisualOpacityAnim);
            menuVisual.StartAnimation(menuVisualScaleAnim.Target, menuVisualScaleAnim);

            scopedBatch.End();

            scopedBatch.Completed += AnimMenuHideScopedBatch_Completed;
        }

        private void AnimMenuHideScopedBatch_Completed(object sender, Windows.UI.Composition.CompositionBatchCompletedEventArgs args)
        {
            Menu.Visibility = Visibility.Collapsed;
        }

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

        private void NavigateToViewModel(object contentViewModel)
        {
            Type pageType = null;

            switch (contentViewModel)
            {
                case HotelServicesViewModel hotelServicesViewModel:
                    pageType = typeof(HotelServicesView);
                    break;
            }

            if (pageType == null)
            {
                return;
            }

            ContentFrame.Navigate(pageType, contentViewModel);
        }
    }
}
