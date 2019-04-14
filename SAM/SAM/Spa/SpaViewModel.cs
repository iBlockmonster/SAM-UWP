using SAM.DependencyContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.Spa
{
    public class SpaViewModel : ViewModelBase
    {
        public SpaViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        { }
    }
}
