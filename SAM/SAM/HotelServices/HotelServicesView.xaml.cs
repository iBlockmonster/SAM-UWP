using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace SAM.HotelServices
{
    public sealed partial class HotelServicesView : Page
    {
        public HotelServicesView()
        {
            this.InitializeComponent();
        }

        #region ViewModelProperty

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register("ViewModel", typeof(HotelServicesViewModel), typeof(HotelServicesView), new PropertyMetadata(null));

        public HotelServicesViewModel ViewModel
        {
            get { return GetValue(ViewModelProperty) as HotelServicesViewModel; }
            set { SetValue(ViewModelProperty, value); }
        }

        #endregion

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            ViewModel = e.Parameter as HotelServicesViewModel;

            ViewModel.PropertyChanged -= ViewModel_PropertyChanged;
            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "FocusedContentViewModel")
            {
                if(ViewModel != null && ViewModel.FocusedContentViewModel != null)
                {
                    var transform = FocusedContentElement.TransformToVisual(OuterScrollView.Content as UIElement);
                    var focusedContentElementPosition = transform.TransformPoint(new Point(0, 0));
                    System.Diagnostics.Debug.WriteLine(focusedContentElementPosition.Y);
                    OuterScrollView.ChangeView(null, focusedContentElementPosition.Y, null);
                }
            }
        }
    }
}
