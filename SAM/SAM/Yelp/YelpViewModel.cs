using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAM.DependencyContainer;

namespace SAM.Yelp
{
    public class YelpViewModel : ViewModelBase
    {
        public YelpViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        { }
    }
}
