using SAM.DependencyContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.RoomService
{
    public class RoomServiceViewModel : ViewModelBase
    {
        public RoomServiceViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        { }
    }
}
