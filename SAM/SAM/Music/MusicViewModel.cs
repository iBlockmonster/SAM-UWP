using SAM.DependencyContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.Music
{
    public class MusicViewModel : ViewModelBase
    {
        public MusicViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        { }
    }
}
