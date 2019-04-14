﻿using SAM.Desktop;
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
using SAM.LockConfig;

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
            await Task.Delay(10);
            // TODO

            var dc = new DependencyContainer.DependencyContainer();
            lock (_initLock)
            {
                _dependencyContainer = dc;
                _dependencyContainer.AddDependency(new ContentNavModel(_dependencyContainer, ContentNavMode.HotelServices));

                _dependencyContainer.AddDependency(new HotelServicesViewModel(_dependencyContainer));
                _dependencyContainer.AddDependency(new LockConfigViewModel(_dependencyContainer));
                _dependencyContainer.AddDependency(new HeaderViewModel(_dependencyContainer));
                _dependencyContainer.AddDependency(new MenuViewModel(_dependencyContainer));
                _dependencyContainer.AddDependency(new TaskbarViewModel(_dependencyContainer));
                _dependencyContainer.AddDependency(new DesktopViewModel(_dependencyContainer));
                _dependencyContainer.AddDependency(new OuterNavViewModel(_dependencyContainer));
            }

            dc.InitComplete();
        }

        private object _initLock = new object();
        private enum AppState { FirstLaunch, Initializing, Running }
        private AppState _state = AppState.FirstLaunch;

        private IDependencyContainer _dependencyContainer;
    }
}
