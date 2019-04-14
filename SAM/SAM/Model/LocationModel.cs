using SAM.DependencyContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace SAM.Model
{
    public enum LocationState { Initializing, Ready, Error }

    public class LocationModel
    {
        public LocationModel(IDependencyContainer dependencyContainer)
        {
            _dependencyContainer = dependencyContainer;
        }

        private object _lock = new object();
        private IDependencyContainer _dependencyContainer;

        private LocationState _state = LocationState.Initializing;
        public LocationState State
        {
            get
            {
                lock (_lock)
                {
                    return _state;
                }
            }
        }

        public event Action<LocationModel, LocationState> StateChanged;

        public async Task Initialize()
        {
            var accessStatus = await Geolocator.RequestAccessAsync();

            Geoposition position = null;
            if (accessStatus == GeolocationAccessStatus.Allowed)
            {
                var locator = new Geolocator();
                position = await locator.GetGeopositionAsync();
            }

            lock (_lock)
            {
                if (accessStatus == GeolocationAccessStatus.Allowed)
                {
                    _position = position;
                    _state = LocationState.Ready;
                }
                else
                {
                    _state = LocationState.Error;
                }
            }

            StateChanged?.Invoke(this, _state);
        }

        private Geoposition _position = null;
        public Geoposition Position
        {
            get
            {
                lock (_lock)
                {
                    return _position;
                }
            }
        }
    }
}
