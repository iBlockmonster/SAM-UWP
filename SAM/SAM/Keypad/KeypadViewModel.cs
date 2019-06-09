using SAM.DependencyContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.Keypad
{
    public class KeypadViewModel : ViewModelBase
    {
        public KeypadViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            _ = WaitForInit();
        }

        private async Task WaitForInit()
        {
            await _dependencyContainer.WaitForInitComplete();
            // TODO
        }

        public event Action<KeypadViewModel> KeypadActivated;
    }
}
