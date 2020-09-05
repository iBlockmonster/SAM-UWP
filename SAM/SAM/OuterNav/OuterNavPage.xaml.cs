using SAM.Desktop;
using System;
using Windows.ApplicationModel.Core;
using Windows.UI.Xaml.Controls;

namespace SAM.OuterNav
{
    public sealed partial class OuterNavPage : Page
    {
        public OuterNavPage(OuterNavViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException("viewModel");
            }
            _viewModel = viewModel;
            _viewModel.ContentViewModelChanged += _viewModel_ContentViewModelChanged;

            this.InitializeComponent();

            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;

            NavigateToViewModel(_viewModel.ContentViewModel);
        }

        private void _viewModel_ContentViewModelChanged(object contentViewModel)
        {
            NavigateToViewModel(contentViewModel);
        }

        private void NavigateToViewModel(object contentViewModel)
        {
            Type pageType = null;

            switch (contentViewModel)
            {
                case DesktopViewModel desktopViewModel:
                    pageType = typeof(DesktopView);
                    break;
            }

            if (pageType == null)
            {
                return;
            }

            NavigationFrame.Navigate(pageType, contentViewModel);
        }

        private OuterNavViewModel _viewModel;
        public OuterNavViewModel ViewModel
        {
            get { return _viewModel; }
        }
    }
}
