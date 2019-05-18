using SAM.DependencyContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace SAM.Model
{
    public class NewsModel
    {
        public NewsModel(IDependencyContainer dependencyContainer)
        {
            if (dependencyContainer == null)
            {
                throw new ArgumentNullException("dependencyContainer");
            }
            _dependencyContainer = dependencyContainer;
        }

        private object _lock = new object();
        private IDependencyContainer _dependencyContainer;

        private readonly static string _topHeadlinesUrl = "https://newsapi.org/v2/top-headlines?country={0}&apiKey={1}";
        // TODO put this in app config
        private readonly static string _apiKey = "e0041d486f6a40a09256ef3e3300a077";
        private readonly static string _countryCode = "us";

        private List<NewsArticleData> ParseNewsArticles(JsonObject root)
        {
            if (root == null)
            {
                return new List<NewsArticleData>();
            }

            var articles = root.GetNamedArray("articles");
            return NewsArticleData.ParseList(articles);
        }

        private List<NewsArticleData> _cachedTopHeadlines = null;
        public async Task<IReadOnlyList<NewsArticleData>> GetTopHeadlines()
        {
            lock (_lock)
            {
                if (_cachedTopHeadlines != null)
                {
                    return _cachedTopHeadlines;
                }
            }

            HttpClient httpClient = new HttpClient();
            Uri uri = new Uri(string.Format(_topHeadlinesUrl, _countryCode, _apiKey));

            HttpResponseMessage httpResponse = await httpClient.GetAsync(uri);
            string rawData = await httpResponse.Content.ReadAsStringAsync();

            if (httpResponse.IsSuccessStatusCode)
            {
                lock (_lock)
                {
                    _cachedTopHeadlines = ParseNewsArticles(JsonObject.Parse(rawData));
                    return _cachedTopHeadlines;
                }
            }
            else
            {
                return new List<NewsArticleData>();
            }
        }
    }
}
