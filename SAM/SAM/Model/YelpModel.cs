using SAM.DependencyContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Web.Http;

namespace SAM.Model
{
    public enum YelpState { Initializing, Ready, Error }

    public class YelpModel
    {
        public YelpModel(IDependencyContainer dependencyContainer)
        {
            if (dependencyContainer == null)
            {
                throw new ArgumentNullException("dependencyContainer");
            }
            _dependencyContainer = dependencyContainer;
        }

        private object _lock = new object();
        private IDependencyContainer _dependencyContainer;

        private YelpState _state = YelpState.Initializing;
        public YelpState State
        {
            get
            {
                lock (_lock)
                {
                    return _state;
                }
            }
        }

        public event Action<YelpModel, YelpState> StateChanged;

        private Task<LocationState> WaitForLocation(LocationModel locationModel)
        {
            if (locationModel.State != LocationState.Initializing)
            {
                return Task.FromResult(locationModel.State);
            }
            var completionSource = new TaskCompletionSource<LocationState>();

            Action<LocationModel, LocationState> stateChangedHandler = null;
            stateChangedHandler = (LocationModel source, LocationState state) =>
            {
                if (state != LocationState.Initializing)
                {
                    locationModel.StateChanged -= stateChangedHandler;
                    completionSource.SetResult(state);
                }
            };
            locationModel.StateChanged += stateChangedHandler;

            return completionSource.Task;
        }

        public async Task Initialize()
        {
            LocationModel locationModel = _dependencyContainer.GetDependency<LocationModel>();
            LocationState locationState = await WaitForLocation(locationModel);

            Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();
            var headers = httpClient.DefaultRequestHeaders;
            headers.Add(_authHeaderKey, string.Format(_authHeaderValue, _apiKey));
            Uri uri;
            if (locationState == LocationState.Ready && locationModel.Position != null)
            {
                uri = new Uri(string.Format(_hotelServicesLocationContentUrl, locationModel.Position.Coordinate.Point.Position.Latitude.ToString(), locationModel.Position.Coordinate.Point.Position.Longitude.ToString()));
            }
            else
            {
                uri = new Uri(_hotelServicesContentUrl);
            }

            HttpResponseMessage httpResponse = await httpClient.GetAsync(uri);
            string rawData = await httpResponse.Content.ReadAsStringAsync();

            lock (_lock)
            {
                if (httpResponse.IsSuccessStatusCode)
                {
                    ParseYelpData(JsonObject.Parse(rawData));
                }
                _state = YelpState.Ready;
            }

            StateChanged?.Invoke(this, _state);
        }

        private readonly static string _hotelServicesContentUrl = "https://api.yelp.com/v3/transactions/delivery/search";
        private readonly static string _hotelServicesLocationContentUrl = "https://api.yelp.com/v3/transactions/delivery/search?latitude={0}&longitude={1}";
        private readonly static string _authHeaderKey = "Authorization";
        private readonly static string _authHeaderValue = "Bearer {0}";
        // TODO put this in app config
        private readonly static string _apiKey = "JT__i462fvWquQJxKgDyetDsyPN7vByt0GX6JKFfeEpxOJ-qtkC2fGCWhwsj3a-GMSvn4O2OQRpi3FJ807ZyNwqmbaPDbn_opAL6hkMs_hRAS4qdm1JNTP0TFMLlW3Yx";

        private void ParseYelpData(JsonObject root)
        {
            if (root == null)
            {
                return;
            }
            var businesses = root.GetNamedArray("businesses");
            _localDelivery = BusinessData.ParseList(businesses);
        }

        private List<BusinessData> _localDelivery;
        public List<BusinessData> LocalDelivery
        {
            get { return _localDelivery; }
        }
    }
}
