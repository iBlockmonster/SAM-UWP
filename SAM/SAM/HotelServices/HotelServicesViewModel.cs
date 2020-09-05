using SAM.DependencyContainer;
using SAM.Keypad;
using SAM.Model;
using SAM.News;
using SAM.Yelp;
using SAM.Spa;
using SAM.Music;
using SAM.O365;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using SAM.RoomService;
using System;
using SAM.Welcome;
using SAM.Instagram;
using SAM.Twitter;
using SAM.LinkedIn;
using SAM.MSNBC;

namespace SAM.HotelServices
{
    public class HotelServicesViewModel : ViewModelBase
    {
        public HotelServicesViewModel(IDependencyContainer depdendencyContainer) : base(depdendencyContainer)
        {
            _nullViewModel = new NullViewModel(depdendencyContainer);
            _focusedContentViewModel = _nullViewModel;
            _focusedKeypadViewModel = _nullViewModel;
            _ = WaitForInit();
        }

        // This is to work around the bug in ContentControl where a data bound value that gets set to null will not call SelectTemplateCore after the iniital load
        private NullViewModel _nullViewModel;

        private async Task WaitForInit()
        {
            await _dependencyContainer.WaitForInitComplete();
            WelcomeViewModel = _dependencyContainer.GetDependency<WelcomeViewModel>();
            YelpViewModel = _dependencyContainer.GetDependency<YelpViewModel>();
            NewsViewModel = _dependencyContainer.GetDependency<NewsViewModel>();
            KeypadViewModel = _dependencyContainer.GetDependency<KeypadViewModel>();
            SpaViewModel = _dependencyContainer.GetDependency<SpaViewModel>();
            TwitterViewModel = _dependencyContainer.GetDependency<TwitterViewModel>();
            MsNbcViewModel = _dependencyContainer.GetDependency<MsNbcViewModel>();
            InstagramViewModel = _dependencyContainer.GetDependency<InstagramViewModel>();
            O365ViewModel = _dependencyContainer.GetDependency<O365ViewModel>();
            LinkedInViewModel = _dependencyContainer.GetDependency<LinkedInViewModel>();
            MusicViewModel = _dependencyContainer.GetDependency<MusicViewModel>();
            RoomServiceViewModel = _dependencyContainer.GetDependency<RoomServiceViewModel>();
        }

        private WelcomeViewModel _welcomeViewModel;
        public WelcomeViewModel WelcomeViewModel
        {
            get { return _welcomeViewModel; }
            set
            {
                if(_welcomeViewModel != value)
                {
                    _welcomeViewModel = value;
                    RaisePropertyChangedFromSource();
                }
            }
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
                        _newsViewModel.NewsDeactivated -= _newsViewModel_NewsDeactivated;
                    }
                    _newsViewModel = value;
                    if (_newsViewModel != null)
                    {
                        _newsViewModel.NewsArticleActivated += _newsViewModel_NewsArticleActivated;
                        _newsViewModel.NewsDeactivated += _newsViewModel_NewsDeactivated;
                    }
                    RaisePropertyChangedFromSource();
                }
            }
        }

        private void _newsViewModel_NewsArticleActivated(NewsViewModel source, NewsArticleData article)
        {
            FocusedContentViewModel = _newsViewModel;
        }
        private void _newsViewModel_NewsDeactivated(NewsViewModel obj)
        {
            FocusedContentViewModel = _nullViewModel;
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
                        _yelpViewModel.YelpDeactivated -= _yelpViewModel_YelpDeactivated;
                    }
                    _yelpViewModel = value;
                    if (_yelpViewModel != null)
                    {
                        _yelpViewModel.BusinessActivated += _yelpViewModel_BusinessActivated;
                        _yelpViewModel.YelpDeactivated += _yelpViewModel_YelpDeactivated;
                    }
                    RaisePropertyChangedFromSource();
                }
            }
        }

        private void _yelpViewModel_BusinessActivated(YelpViewModel source, BusinessData business)
        {
            FocusedContentViewModel = _yelpViewModel;
        }
        private void _yelpViewModel_YelpDeactivated(YelpViewModel obj)
        {
            FocusedContentViewModel = _nullViewModel;
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
                        _spaViewModel.SpaDeactivated -= _spaViewModel_SpaDeactivated;
                    }
                    _spaViewModel = value;
                    if (_spaViewModel != null)
                    {
                        _spaViewModel.SpaActivated += _spaViewModel_SpaActivated;
                        _spaViewModel.SpaDeactivated += _spaViewModel_SpaDeactivated;
                    }
                    RaisePropertyChangedFromSource();
                }
            }
        }

        private MsNbcViewModel _msNbcViewModel;
        public MsNbcViewModel MsNbcViewModel
        {
            get { return _msNbcViewModel; }
            set
            {
                if (_msNbcViewModel != value)
                {
                    if (_msNbcViewModel != null)
                    {
                        _msNbcViewModel.MsNbcActivated -= _msNbcViewModel_MsNbcActivated;
                        _msNbcViewModel.MsNbcDeactivated -= _msNbcViewModel_MsNbcDeactivated;
                    }
                    _msNbcViewModel = value;
                    if (_msNbcViewModel != null)
                    {
                        _msNbcViewModel.MsNbcActivated += _msNbcViewModel_MsNbcActivated;
                        _msNbcViewModel.MsNbcDeactivated += _msNbcViewModel_MsNbcDeactivated;
                    }
                    RaisePropertyChangedFromSource();
                }
            }
        }

        private InstagramViewModel _instagramViewModel;
        public InstagramViewModel InstagramViewModel
        {
            get { return _instagramViewModel; }
            set
            {
                if (_instagramViewModel != value)
                {
                    if (_instagramViewModel != null)
                    {
                        _instagramViewModel.InstagramActivated -= _instagramViewModel_InstagramActivated;
                        _instagramViewModel.InstagramDeactivated -= _instagramViewModel_InstagramDeactivated;
                    }
                    _instagramViewModel = value;
                    if (_instagramViewModel != null)
                    {
                        _instagramViewModel.InstagramActivated += _instagramViewModel_InstagramActivated;
                        _instagramViewModel.InstagramDeactivated += _instagramViewModel_InstagramDeactivated;
                    }
                    RaisePropertyChangedFromSource();
                }
            }
        }

        private O365ViewModel _o365ViewModel;
        public O365ViewModel O365ViewModel
        {
            get { return _o365ViewModel; }
            set
            {
                if (_o365ViewModel != value)
                {
                    if (_o365ViewModel != null)
                    {
                        _o365ViewModel.O365Activated -= _o365ViewModel_O365Activated;
                        _o365ViewModel.O365Deactivated -= _o365ViewModel_O365Deactivated;
                    }
                    _o365ViewModel = value;
                    if (_o365ViewModel != null)
                    {
                        _o365ViewModel.O365Activated += _o365ViewModel_O365Activated;
                        _o365ViewModel.O365Deactivated += _o365ViewModel_O365Deactivated;
                    }
                    RaisePropertyChangedFromSource();
                }
            }
        }

        private TwitterViewModel _twitterViewModel;
        public TwitterViewModel TwitterViewModel
        {
            get { return _twitterViewModel; }
            set
            {
                if (_twitterViewModel != value)
                {
                    if (_twitterViewModel != null)
                    {
                        _twitterViewModel.TwitterActivated -= _twitterViewModel_TwitterActivated;
                        _twitterViewModel.TwitterDeactivated -= _twitterViewModel_TwitterDeactivated;
                    }
                    _twitterViewModel = value;
                    if (_twitterViewModel != null)
                    {
                        _twitterViewModel.TwitterActivated += _twitterViewModel_TwitterActivated;
                        _twitterViewModel.TwitterDeactivated += _twitterViewModel_TwitterDeactivated;
                    }
                    RaisePropertyChangedFromSource();
                }
            }
        }

        private LinkedInViewModel _linkedInViewModel;
        public LinkedInViewModel LinkedInViewModel
        {
            get { return _linkedInViewModel; }
            set
            {
                if (_linkedInViewModel != value)
                {
                    if (_linkedInViewModel != null)
                    {
                        _linkedInViewModel.LinkedInActivated -= _linkedInViewModel_LinkedInActivated;
                        _linkedInViewModel.LinkedInDeactivated -= _linkedInViewModel_LinkedInDeactivated;
                    }
                    _linkedInViewModel = value;
                    if (_linkedInViewModel != null)
                    {
                        _linkedInViewModel.LinkedInActivated += _linkedInViewModel_LinkedInActivated;
                        _linkedInViewModel.LinkedInDeactivated += _linkedInViewModel_LinkedInDeactivated;
                    }
                    RaisePropertyChangedFromSource();
                }
            }
        }

        private void _spaViewModel_SpaActivated(SpaViewModel source)
        {
            FocusedContentViewModel = _spaViewModel;
        }

        private void _spaViewModel_SpaDeactivated(SpaViewModel obj)
        {
            FocusedContentViewModel = _nullViewModel;
        }

        private void _linkedInViewModel_LinkedInActivated(LinkedInViewModel source)
        {
            FocusedContentViewModel = _linkedInViewModel;
        }

        private void _linkedInViewModel_LinkedInDeactivated(LinkedInViewModel obj)
        {
            FocusedContentViewModel = _nullViewModel;
        }

        private void _msNbcViewModel_MsNbcActivated(MsNbcViewModel source)
        {
            FocusedContentViewModel = _msNbcViewModel;
        }

        private void _msNbcViewModel_MsNbcDeactivated(MsNbcViewModel obj)
        {
            FocusedContentViewModel = _nullViewModel;
        }

        private void _instagramViewModel_InstagramActivated(InstagramViewModel source)
        {
            FocusedContentViewModel = _instagramViewModel;
        }

        private void _instagramViewModel_InstagramDeactivated(InstagramViewModel obj)
        {
            FocusedContentViewModel = _nullViewModel;
        }

        private void _o365ViewModel_O365Activated(O365ViewModel source)
        {
            FocusedContentViewModel = _o365ViewModel;
        }

        private void _o365ViewModel_O365Deactivated(O365ViewModel obj)
        {
            FocusedContentViewModel = _nullViewModel;
        }

        private void _twitterViewModel_TwitterActivated(TwitterViewModel source)
        {
            FocusedContentViewModel = _twitterViewModel;
        }

        private void _twitterViewModel_TwitterDeactivated(TwitterViewModel obj)
        {
            FocusedContentViewModel = _nullViewModel;
        }

     

        private MusicViewModel _musicViewModel;
        public MusicViewModel MusicViewModel
        {
            get { return _musicViewModel; }
            set
            {
                if (_musicViewModel != value)
                {
                    if (_musicViewModel != null)
                    {
                        _musicViewModel.MusicActivated -= _musicViewModel_MusicActivated;
                        _musicViewModel.MusicDeactivated -= _musicViewModel_MusicDeactivated;
                    }
                    _musicViewModel = value;
                    if (_musicViewModel != null)
                    {
                        _musicViewModel.MusicActivated += _musicViewModel_MusicActivated;
                        _musicViewModel.MusicDeactivated += _musicViewModel_MusicDeactivated;
                    }
                    RaisePropertyChangedFromSource();
                }
            }
        }

        private void _musicViewModel_MusicActivated(MusicViewModel source)
        {
            FocusedContentViewModel = _musicViewModel;
        }

        private void _musicViewModel_MusicDeactivated(MusicViewModel obj)
        {
            FocusedContentViewModel = _nullViewModel;
        }

        private RoomServiceViewModel _roomServiceViewModel;
        public RoomServiceViewModel RoomServiceViewModel
        {
            get { return _roomServiceViewModel; }
            set
            {
                if (_roomServiceViewModel != value)
                {
                    if (_roomServiceViewModel != null)
                    {
                        _roomServiceViewModel.RoomServiceActivated -= _roomServiceViewModel_SpaActivated;
                        _roomServiceViewModel.RoomServiceDeactivated -= _roomServiceViewModel_RoomServiceDeactivated;
                    }
                    _roomServiceViewModel = value;
                    if (_roomServiceViewModel != null)
                    {
                        _roomServiceViewModel.RoomServiceActivated += _roomServiceViewModel_SpaActivated;
                        _roomServiceViewModel.RoomServiceDeactivated += _roomServiceViewModel_RoomServiceDeactivated;
                    }
                    RaisePropertyChangedFromSource();
                }
            }
        }

        private void _roomServiceViewModel_SpaActivated(RoomServiceViewModel source)
        {
            FocusedContentViewModel = _roomServiceViewModel;
        }

        private void _roomServiceViewModel_RoomServiceDeactivated(RoomServiceViewModel obj)
        {
            FocusedContentViewModel = _nullViewModel;
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
                        _keypadViewModel.KeypadDeactivated -= _keypadViewModel_KeypadDeactivated;
                    }
                    _keypadViewModel = value;
                    if (_keypadViewModel != null)
                    {
                        _keypadViewModel.KeypadActivated += _keypadViewModel_KeypadActivated;
                        _keypadViewModel.KeypadDeactivated += _keypadViewModel_KeypadDeactivated;
                    }
                    RaisePropertyChangedFromSource();
                }
            }
        }

        private void _keypadViewModel_KeypadActivated(KeypadViewModel obj)
        {
            FocusedKeypadViewModel = _keypadViewModel;
        }

        private void _keypadViewModel_KeypadDeactivated(KeypadViewModel obj)
        {
            FocusedKeypadViewModel = _nullViewModel;
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
    }
}
