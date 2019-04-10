using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using SAM.OuterNav;
using SAM.Desktop;
using SAM.Taskbar;
using SAM.Menu;

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

            Window.Current.Content = new OuterNavPage(_outerNavViewModel);

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
            await Task.Delay(100);
            // TODO
            lock (_initLock)
            {
                _menuViewModel = new MenuViewModel();
                _taskbarViewModel = new TaskbarViewModel();
                _desktopViewModel = new DesktopViewModel(_taskbarViewModel, _menuViewModel);
                _outerNavViewModel = new OuterNavViewModel(_desktopViewModel);
            }
        }

        private object _initLock = new object();
        private enum AppState { FirstLaunch, Initializing, Running }
        private AppState _state = AppState.FirstLaunch;

        private OuterNavViewModel _outerNavViewModel;
        private DesktopViewModel _desktopViewModel;
        private TaskbarViewModel _taskbarViewModel;
        private MenuViewModel _menuViewModel;
    }
}
