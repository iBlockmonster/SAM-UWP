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
using SAM.Welcome;
using SAM.Instagram;
using SAM.LinkedIn;
using SAM.O365;
using SAM.MSNBC;
using SAM.Twitter;
using SAM.TikTok;
using SAM.Redit;
using SAM.YouTube;
using SAM.Amazon;

namespace SAM.Common
{
    public class ExpandedContentDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate NullTemplate { get; set; }
        public DataTemplate WelcomeTemplate { get; set; }
        public DataTemplate YelpTemplate { get; set; }
        public DataTemplate NewsTemplate { get; set; }
        public DataTemplate KeypadTemplate { get; set; }
        public DataTemplate SpaTemplate { get; set; }
        public DataTemplate AmazonTemplate { get; set; }
        public DataTemplate YoutubeTemplate { get; set; }
        public DataTemplate TikTokTemplate { get; set; }
        public DataTemplate TwitterTemplate { get; set; }
        public DataTemplate ReditTemplate { get; set; }
        public DataTemplate MsNbcTemplate { get; set; }
        public DataTemplate LinkedInTemplate { get; set; }
        public DataTemplate O365Template { get; set; }
        public DataTemplate InstagramTemplate { get; set; }
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
                case NullViewModel nullViewModel:
                    return NullTemplate;
                case WelcomeViewModel welcomeViewModel:
                    return WelcomeTemplate;
                case YelpViewModel yelpViewModel:
                    return YelpTemplate;
                case NewsViewModel newsViewModel:
                    return NewsTemplate;
                case KeypadViewModel keypadViewModel:
                    return KeypadTemplate;
                case SpaViewModel spaViewModel:
                    return SpaTemplate;
                case AmazonViewModel amazonViewModel:
                    return AmazonTemplate;
                case YoutubeViewModel youtubeViewModel:
                    return YoutubeTemplate;
                case TikTokViewModel tiktokViewModel:
                    return TikTokTemplate;
                case MsNbcViewModel msNbcViewModel:
                    return MsNbcTemplate;
                case TwitterViewModel twitterViewModel:
                    return TwitterTemplate;
                case ReditViewModel reditViewModel:
                    return ReditTemplate;
                case LinkedInViewModel linkedInViewModel:
                    return LinkedInTemplate;
                case O365ViewModel o365ViewModel:
                    return O365Template;
                case InstagramViewModel instagramViewModel:
                    return InstagramTemplate;
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
