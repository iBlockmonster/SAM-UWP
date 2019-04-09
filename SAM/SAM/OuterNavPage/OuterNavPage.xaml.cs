using System;
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

            this.InitializeComponent();
        }

        private OuterNavViewModel _viewModel;
        public OuterNavViewModel ViewModel
        {
            get { return _viewModel; }
        }
    }
}
