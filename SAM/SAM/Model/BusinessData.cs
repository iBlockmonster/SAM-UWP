

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.UI.Xaml;

namespace SAM.Model
{
    public class BusinessData
    {
        #region Parsing JSON

        public static BusinessData Parse(JsonObject data)
        {
            try
            {
                return new BusinessData(data.GetNamedString("id"), data.GetNamedString("name"), data.GetNamedString("image_url"), data.GetNamedString("url"));
            }
            catch
            {
                return null;
            }
        }

        public static List<BusinessData> ParseList(JsonArray data)
        {
            if (data == null || data.Count == 0)
            {
                return new List<BusinessData>();
            }
            var retVal = new List<BusinessData>(data.Count);
            for (int i = 0; i < data.Count; i++)
            {
                var item = BusinessData.Parse(data[i].GetObject());
                if (item != null)
                {
                    retVal.Add(item);
                }
            }
            return retVal;
        }

        #endregion

        public BusinessData(string id, string name, string imageUrl, string url)
        {
            Id = id;
            Name = name;
            ImageUrl = imageUrl;
            Url = url;
        }

        public string Id { get; }
        public string Name { get; }
        public string ImageUrl { get; }
        public string Url { get; }

        public void OnActivate(object sender, RoutedEventArgs e)
        {
            // TODO think about a better way to do this
            Activated?.Invoke(this);
        }

        public event Action<BusinessData> Activated;
    }
}
