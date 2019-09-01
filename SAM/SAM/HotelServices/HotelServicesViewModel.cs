using SAM.DependencyContainer;
using SAM.Keypad;
using SAM.Model;
using SAM.News;
using SAM.Yelp;
using SAM.Spa;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace SAM.HotelServices
{
    public class HotelServicesViewModel : ViewModelBase
    {
        public HotelServicesViewModel(IDependencyContainer depdendencyContainer) : base(depdendencyContainer)
        {
            _ = WaitForInit();
        }

        private async Task WaitForInit()
        {
            await _dependencyContainer.WaitForInitComplete();
            YelpViewModel = _dependencyContainer.GetDependency<YelpViewModel>();
            NewsViewModel = _dependencyContainer.GetDependency<NewsViewModel>();
            KeypadViewModel = _dependencyContainer.GetDependency<KeypadViewModel>();
            SpaViewModel = _dependencyContainer.GetDependency<SpaViewModel>();
        }

        private NewsViewModel _newsViewModel;
        public NewsViewModel NewsViewModel
        {
            get { return _newsViewModel; }
            private set
            {
                if (_newsViewModel != value)
                {
                    if (_newsViewModel != null)
                    {
                        _newsViewModel.NewsArticleActivated -= _newsViewModel_NewsArticleActivated;
                    }
                    _newsViewModel = value;
                    if (_newsViewModel != null)
                    {
                        _newsViewModel.NewsArticleActivated += _newsViewModel_NewsArticleActivated;
                    }
                    RaisePropertyChangedFromSource();
                }
            }
        }

        private void _newsViewModel_NewsArticleActivated(NewsViewModel source, NewsArticleData article)
        {
            FocusedContentViewModel = _newsViewModel;
        }

        private YelpViewModel _yelpViewModel;
        public YelpViewModel YelpViewModel
        {
            get { return _yelpViewModel; }
            set
            {
                if (_yelpViewModel != value)
                {
                    if (_yelpViewModel != null)
                    {
                        _yelpViewModel.BusinessActivated -= _yelpViewModel_BusinessActivated;
                    }
                    _yelpViewModel = value;
                    if (_yelpViewModel != null)
                    {
                        _yelpViewModel.BusinessActivated += _yelpViewModel_BusinessActivated;
                    }
                    RaisePropertyChangedFromSource();
                }
            }
        }

        private void _yelpViewModel_BusinessActivated(YelpViewModel source, BusinessData business)
        {
            FocusedContentViewModel = _yelpViewModel;
        }

        private SpaViewModel _spaViewModel;
        public SpaViewModel SpaViewModel
        {
            get { return _spaViewModel; }
            set
            {
                if (_spaViewModel != value)
                {
                    if (_spaViewModel != null)
                    {
                        _spaViewModel.SpaActivated -= _spaViewModel_SpaActivated;
                    }
                    _spaViewModel = value;
                    if (_spaViewModel != null)
                    {
                        _spaViewModel.SpaActivated += _spaViewModel_SpaActivated;
                    }
                    RaisePropertyChangedFromSource();
                }
            }
        }

        private void _spaViewModel_SpaActivated(SpaViewModel source)
        {
            FocusedContentViewModel = _spaViewModel;
        }

        private KeypadViewModel _keypadViewModel;
        public KeypadViewModel KeypadViewModel
        {
            get { return _keypadViewModel; }
            private set
            {
                if (_keypadViewModel != value)
                {
                    if (_keypadViewModel != null)
                    {
                        _keypadViewModel.KeypadActivated -= _keypadViewModel_KeypadActivated;
                    }
                    _keypadViewModel = value;
                    if (_keypadViewModel != null)
                    {
                        _keypadViewModel.KeypadActivated += _keypadViewModel_KeypadActivated;
                    }
                    RaisePropertyChangedFromSource();
                }
            }
        }

        private void _keypadViewModel_KeypadActivated(KeypadViewModel obj)
        {
            FocusedKeypadViewModel = _keypadViewModel;
        }

        private ViewModelBase _focusedContentViewModel;
        public ViewModelBase FocusedContentViewModel
        {
            get { return _focusedContentViewModel; }
            private set
            {
                if (_focusedContentViewModel != value)
                {
                    _focusedContentViewModel = value;
                    RaisePropertyChangedFromSource();
                }
            }
        }

        private ViewModelBase _focusedKeypadViewModel;
        public ViewModelBase FocusedKeypadViewModel
        {
            get { return _focusedKeypadViewModel; }
            private set
            {
                if (_focusedKeypadViewModel != value)
                {
                    _focusedKeypadViewModel = value;
                    RaisePropertyChangedFromSource();
                }
            }
        }

        public void OnMirrorHomeClick(object sender, RoutedEventArgs e)
        {
            _dependencyContainer.GetDependency<ContentNavModel>().RequestContentNavigation(ContentNavMode.MirrorHome);
        }

        public void OnRoomServiceClick(object sender, RoutedEventArgs e)
        {
            _dependencyContainer.GetDependency<ContentNavModel>().RequestContentNavigation(ContentNavMode.RoomService);
        }

        public void OnMusicClick(object sender, RoutedEventArgs e)
        {
            _dependencyContainer.GetDependency<ContentNavModel>().RequestContentNavigation(ContentNavMode.Music);
        }

        public void OnKeypadClick(object sender, RoutedEventArgs e)
        {
            FocusedKeypadViewModel = _keypadViewModel;
        }
    }
}
