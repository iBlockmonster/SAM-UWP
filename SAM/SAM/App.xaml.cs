using SAM.Desktop;
using SAM.Menu;
using SAM.OuterNav;
using SAM.Taskbar;
using SAM.Header;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using SAM.HotelServices;
using SAM.Model;
using SAM.DependencyContainer;
using SAM.MirrorHome;
using SAM.Yelp;
using SAM.RoomService;
using SAM.Spa;
using SAM.Music;
using SAM.News;
using SAM.Keypad;
using SAM.Welcome;
using SAM.Instagram;

namespace SAM
{
    sealed partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            lock (_initLock)
            {
                if (_state != AppState.FirstLaunch)
                {
                    if (e.PrelaunchActivated == false)
                    {
                        Window.Current.Activate();
                    }
                }
                else
                {
                    _ = FirstTimeInit(e);
                }
            }
        }

        private async Task FirstTimeInit(LaunchActivatedEventArgs e)
        {
            lock (_initLock)
            {
                _state = AppState.Initializing;
            }

            await SetupDependencies();

            Window.Current.Content = new OuterNavPage(_dependencyContainer.GetDependency<OuterNavViewModel>());

            lock (_initLock)
            {
                _state = AppState.Running;
            }

            if (e.PrelaunchActivated == false)
            {
                Window.Current.Activate();
            }
        }

        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            lock (_initLock)
            {
                if (_state == AppState.Running)
                {
                    var deferral = e.SuspendingOperation.GetDeferral();
                    var suspendTask = SuspendApp();
                    suspendTask.ContinueWith((t) =>
                    {
                        deferral.Complete();
                    });
                }
            }
        }

        private async Task SuspendApp()
        {
            // TODO
            await Task.Delay(10);
        }

        private async Task SetupDependencies()
        {
            // TODO
            await Task.Delay(10);

            var dc = new DependencyContainer.DependencyContainer();
            var lm = new LocationModel(dc);
            var ym = new YelpModel(dc);
            var nm = new NewsModel(dc);

            lock (_initLock)
            {
                _dependencyContainer = dc;
                _dependencyContainer.AddDependency(lm);
                _dependencyContainer.AddDependency(ym);
                _dependencyContainer.AddDependency(nm);
                _dependencyContainer.AddDependency(new ContentNavModel(_dependencyContainer, ContentNavMode.MirrorHome));

                _dependencyContainer.AddDependency(new HotelServicesViewModel(_dependencyContainer));
                _dependencyContainer.AddDependency(new WelcomeViewModel(_dependencyContainer));
                _dependencyContainer.AddDependency(new MirrorHomeViewModel(_dependencyContainer));
                _dependencyContainer.AddDependency(new HeaderViewModel(_dependencyContainer));
                _dependencyContainer.AddDependency(new MenuViewModel(_dependencyContainer));
                _dependencyContainer.AddDependency(new TaskbarViewModel(_dependencyContainer));
                _dependencyContainer.AddDependency(new DesktopViewModel(_dependencyContainer));
                _dependencyContainer.AddDependency(new OuterNavViewModel(_dependencyContainer));
                _dependencyContainer.AddDependency(new YelpViewModel(_dependencyContainer));
                _dependencyContainer.AddDependency(new RoomServiceViewModel(_dependencyContainer));
                _dependencyContainer.AddDependency(new SpaViewModel(_dependencyContainer));
                _dependencyContainer.AddDependency(new InstagramViewModel(_dependencyContainer));
                _dependencyContainer.AddDependency(new MusicViewModel(_dependencyContainer));
                _dependencyContainer.AddDependency(new NewsViewModel(_dependencyContainer));
                _dependencyContainer.AddDependency(new KeypadViewModel(_dependencyContainer));
            }

            dc.InitComplete();

            _ = lm.Initialize();
        }

        private object _initLock = new object();
        private enum AppState { FirstLaunch, Initializing, Running }
        private AppState _state = AppState.FirstLaunch;

        private IDependencyContainer _dependencyContainer;
    }
}
