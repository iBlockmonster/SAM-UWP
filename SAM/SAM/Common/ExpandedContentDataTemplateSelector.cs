﻿using SAM.Keypad;
using SAM.News;
using SAM.Yelp;
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
                default:
                    return null;
            }
        }
    }
}