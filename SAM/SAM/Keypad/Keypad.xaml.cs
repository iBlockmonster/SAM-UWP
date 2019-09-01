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

namespace SAM.Keypad
{
    public sealed partial class Keypad : UserControl
    {
        public Keypad()
        {
            this.InitializeComponent();
        }

        #region ViewModelProperty

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register("ViewModel", typeof(KeypadViewModel), typeof(Keypad), new PropertyMetadata(null));

        public KeypadViewModel ViewModel
        {
            get { return GetValue(ViewModelProperty) as KeypadViewModel; }
            set { SetValue(ViewModelProperty, value); }
        }

        #endregion

        private void OneButton_Click(object sender, RoutedEventArgs e)
        {
            this.FirstDigit.Text = "1";
        }

        private void TwoButton_Click(object sender, RoutedEventArgs e)
        {
            this.SecondDigit.Text = "2";
        }

        private void ThreeButton_Click(object sender, RoutedEventArgs e)
        {
            this.ThirdDigit.Text = "3";
        }

        private void FourButton_Click(object sender, RoutedEventArgs e)
        {
            this.FourthDigit.Text = "4";
        }

        private void FiveButton_Click(object sender, RoutedEventArgs e)
        {
            this.FifthDigit.Text = "5";
        }

        private void SixButton_Click(object sender, RoutedEventArgs e)
        {
            this.SixthDigit.Text = "6";
        }
    }
}
