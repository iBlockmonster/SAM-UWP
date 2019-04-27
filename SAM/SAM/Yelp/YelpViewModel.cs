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

        private BusinessData _activeBusiness;
        public BusinessData ActiveBusiness
        {
            get { return _activeBusiness; }
            set
            {
                if (_activeBusiness != value)
                {
                    _activeBusiness = value;
                    RaisePropertyChangedFromSource();
                }
            }
        }
    }
}
