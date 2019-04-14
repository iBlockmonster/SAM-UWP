using SAM.DependencyContainer;
using SAM.HotelServices;
using SAM.LockConfig;
using SAM.Yelp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.Model
{
    public enum ContentNavMode { HotelServices, LockConfig, Yelp };

    public class ContentNavModel
    {
        public ContentNavModel(IDependencyContainer depdendencyContainer, ContentNavMode startingMode)
        {
            if(depdendencyContainer == null)
            {
                throw new ArgumentNullException("depdendencyContainer");
            }
            _dependencyContainer = depdendencyContainer;
            _currentMode = startingMode;
        }

        private IDependencyContainer _dependencyContainer;

        private ContentNavMode _currentMode = ContentNavMode.HotelServices;
        public ContentNavMode CurrentMode
        {
            get { return _currentMode; }
        }

        public object CurrentViewModel
        {
            get
            {
                switch (_currentMode)
                {
                    case ContentNavMode.HotelServices:
                        return _dependencyContainer.GetDependency<HotelServicesViewModel>();
                    case ContentNavMode.LockConfig:
                        return _dependencyContainer.GetDependency<LockConfigViewModel>();
                    case ContentNavMode.Yelp:
                        return _dependencyContainer.GetDependency<YelpViewModel>();
                }
                return null;
            }
        }

        public void RequestContentNavigation(ContentNavMode target)
        {
            if (_currentMode != target)
            {
                _currentMode = target;
                ContentChanged?.Invoke(_currentMode);
            }
        }

        public event Action<ContentNavMode> ContentChanged;
    }
}
