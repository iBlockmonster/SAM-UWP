using SAM.Keypad;
using SAM.News;
using SAM.Spa;
using SAM.Yelp;
using SAM.Music;
using SAM.RoomService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SAM.Common
{
    public class ExpandedContentDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate YelpTemplate { get; set; }
        public DataTemplate NewsTemplate { get; set; }
        public DataTemplate KeypadTemplate { get; set; }
        public DataTemplate SpaTemplate { get; set; }
        public DataTemplate MusicTemplate { get; set; }
        public DataTemplate RoomServiceTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            return SelectTemplateCore(item, null);
        }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            switch (item)
            {
                case YelpViewModel yelpViewModel:
                    return YelpTemplate;
                case NewsViewModel newsViewModel:
                    return NewsTemplate;
                case KeypadViewModel keypadViewModel:
                    return KeypadTemplate;
                case SpaViewModel spaViewModel:
                    return SpaTemplate;
                case MusicViewModel musicViewModel:
                    return MusicTemplate;
                case RoomServiceViewModel roomServiceViewModel:
                    return RoomServiceTemplate;
                default:
                    return null;
            }
        }
    }
}
