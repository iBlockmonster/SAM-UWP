using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAM.DependencyContainer;
using SAM.Model;

namespace SAM.Yelp
{
    public class YelpViewModel : ViewModelBase
    {
        public YelpViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        { }

        public void RequestDisplayBusinessData(BusinessData data)
        {
            if(data == null)
            {
                BusinessUrl = null;
            }
            else
            {
                BusinessUrl = data.Url;
            }
        }

        private string _businessUrl;
        public string BusinessUrl
        {
            get { return _businessUrl; }
            set
            {
                if(_businessUrl != value)
                {
                    _businessUrl = value;
                    RaisePropertyChangedFromSource();
                }
            }
        }
    }
}
