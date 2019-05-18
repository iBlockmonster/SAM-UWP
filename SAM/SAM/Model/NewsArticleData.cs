using SAM.DependencyContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace SAM.Model
{
    public class NewsArticleData
    {
        #region Parsing JSON

        public static NewsArticleData Parse(JsonObject data)
        {
            try
            {
                string source = data.GetNamedObject("source")?.GetOptionalString("name");
                return new NewsArticleData(source, data.GetOptionalString("author"), data.GetOptionalString("title"), data.GetOptionalString("description"), data.GetOptionalString("url"), data.GetOptionalString("urlToImage"), data.GetOptionalString("publishedAt"), data.GetOptionalString("content"));
            }
            catch
            {
                return null;
            }
        }

        public static List<NewsArticleData> ParseList(JsonArray data)
        {
            if (data == null || data.Count == 0)
            {
                return new List<NewsArticleData>();
            }
            var retVal = new List<NewsArticleData>(data.Count);
            for (int i = 0; i < data.Count; i++)
            {
                var item = NewsArticleData.Parse(data[i].GetObject());
                if (item != null)
                {
                    retVal.Add(item);
                }
            }
            return retVal;
        }

        #endregion

        public NewsArticleData(string source, string author, string title, string description, string url, string imageUrl, string timestamp, string content)
        {
            Source = source;
            Author = author;
            Title = title;
            Description = description;
            Url = url;
            ImageUrl = imageUrl;
            Timestamp = timestamp;
            Content = content;
        }

        public string Source { get; }
        public string Author { get; }
        public string Title { get; }
        public string Description { get; }
        public string Url { get; }
        public string ImageUrl { get; }
        public string Timestamp { get; }
        public string Content { get; }
    }
}
