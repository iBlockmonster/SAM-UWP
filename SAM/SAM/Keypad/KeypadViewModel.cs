using SAM.DependencyContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SAM.Keypad
{
    public class KeypadViewModel : ViewModelBase
    {
        public KeypadViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer) { }

        public event Action<KeypadViewModel> KeypadActivated;

        public void OnActivate(object sender, RoutedEventArgs e)
        {
            KeypadActivated?.Invoke(this);
        }

        public event Action<KeypadViewModel> KeypadDeactivated;

        public void onDeactivate(object sender, RoutedEventArgs e)
        {
            KeypadDeactivated?.Invoke(this);
        }

        private const string _placeholder = "-";
        private string[] _digits = new string[] { _placeholder, _placeholder, _placeholder, _placeholder, _placeholder, _placeholder };
        private int _currentDigit = 0;

        public void onNumberKeyPressed(object sender, RoutedEventArgs e)
        {
            if (_currentDigit >= _digits.Length)
            {
                return;
            }
            if (sender is Button sourceButton)
            {
                if (sourceButton.Tag is string digit)
                {
                    _digits[_currentDigit] = digit;
                    _currentDigit++;
                    UpdateReadout();
                }
            }
        }

        public void onBackspacePressed(object sender, RoutedEventArgs e)
        {
            if (_currentDigit == 0)
            {
                return;
            }
            _currentDigit--;
            _digits[_currentDigit] = _placeholder;
            UpdateReadout();
        }

        private void UpdateReadout()
        {
            RaisePropertyChanged("FirstUnit");
            RaisePropertyChanged("SecondUnit");
            RaisePropertyChanged("ThirdUnit");
            RaisePropertyChanged("AllowLock");
            RaisePropertyChanged("AllowUnlock");
        }

        public string FirstUnit
        {
            get
            {
                return _digits[0] + _digits[1];
            }
        }

        public string SecondUnit
        {
            get
            {
                return _digits[2] + _digits[3];
            }
        }

        public string ThirdUnit
        {
            get
            {
                return _digits[4] + _digits[5];
            }
        }

        public bool AllowLock
        {
            get
            {
                return _currentDigit == _digits.Length;
            }
        }

        public bool AllowUnlock
        {
            get
            {
                return _currentDigit == _digits.Length;
            }
        }
    }
}
