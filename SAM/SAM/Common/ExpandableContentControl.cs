using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SAM.Common
{
    public class ExpandableContentControl : ContentControl
    {
        public ExpandableContentControl()
        {
            DefaultStyleKey = typeof(ExpandableContentControl);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _contentPresenter = GetTemplateChild("ContentPresenter") as ContentPresenter;

            SetupLayout();
        }
   

        private ContentPresenter _contentPresenter;

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);

            SetupLayout();
        }

        private void SetupLayout()
        {
            if (_contentPresenter == null)
            {
                return;
            }
            var vm = Content;
            if (vm == null)
            {
                VisualStateManager.GoToState(this, "ExpansionCollapsed", true);
                // TODO
            }
            else
            {
                VisualStateManager.GoToState(this, "ExpansionExpanded", true);
                // TODO
            }
        }
    }
}
