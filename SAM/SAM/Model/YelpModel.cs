using SAM.DependencyContainer;
using SAM.Yelp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Web.Http;

namespace SAM.Model
{
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

        private readonly static string _hotelServicesContentUrl = "https://api.yelp.com/v3/transactions/delivery/search";
        private readonly static string _hotelServicesLocationContentUrl = "https://api.yelp.com/v3/transactions/delivery/search?latitude={0}&longitude={1}";
        private readonly static string _authHeaderKey = "Authorization";
        private readonly static string _authHeaderValue = "Bearer {0}";
        // TODO put this in app config
        private readonly static string _apiKey = "JT__i462fvWquQJxKgDyetDsyPN7vByt0GX6JKFfeEpxOJ-qtkC2fGCWhwsj3a-GMSvn4O2OQRpi3FJ807ZyNwqmbaPDbn_opAL6hkMs_hRAS4qdm1JNTP0TFMLlW3Yx";

        private List<BusinessData> ParseYelpBusinesses(JsonObject root)
        {
            if (root == null)
            {
                return new List<BusinessData>();
            }
            var businesses = root.GetNamedArray("businesses");
            return BusinessData.ParseList(businesses);
        }

        private List<BusinessData> _cachedLocalDelivery = null;
        public async Task<IReadOnlyList<BusinessData>> GetLocalDelivery()
        {
            lock (_lock)
            {
                if (_cachedLocalDelivery != null)
                {
                    return _cachedLocalDelivery;
                }
            }

            LocationModel locationModel = _dependencyContainer.GetDependency<LocationModel>();
            LocationState locationState = await locationModel.WaitForInitComplete();

            HttpClient httpClient = new HttpClient();
            var headers = httpClient.DefaultRequestHeaders;
            headers.Add(_authHeaderKey, string.Format(_authHeaderValue, _apiKey));
            Uri uri;
            if (locationState == LocationState.Initialized && locationModel.Position != null)
            {
                uri = new Uri(string.Format(_hotelServicesLocationContentUrl, locationModel.Position.Coordinate.Point.Position.Latitude.ToString(), locationModel.Position.Coordinate.Point.Position.Longitude.ToString()));
            }
            else
            {
                uri = new Uri(_hotelServicesContentUrl);
            }

            HttpResponseMessage httpResponse = await httpClient.GetAsync(uri);
            string rawData = await httpResponse.Content.ReadAsStringAsync();

            if (httpResponse.IsSuccessStatusCode)
            {
                lock (_lock)
                {
                    _cachedLocalDelivery = ParseYelpBusinesses(JsonObject.Parse(rawData));
                    return _cachedLocalDelivery;
                }
            }
            else
            {
                return new List<BusinessData>();
            }
        }
    }
}
