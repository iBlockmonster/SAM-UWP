using SAM.DependencyContainer;
using SAM.HotelServices;
using SAM.MirrorHome;
using SAM.Music;
using SAM.RoomService;
using SAM.Spa;
using SAM.Yelp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.Model
{
    public enum ContentNavMode { HotelServices, MirrorHome, RoomService, Yelp, Spa, Music };

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
                    case ContentNavMode.MirrorHome:
                        return _dependencyContainer.GetDependency<MirrorHomeViewModel>();
                    case ContentNavMode.Yelp:
                        return _dependencyContainer.GetDependency<YelpViewModel>();
                    case ContentNavMode.RoomService:
                        return _dependencyContainer.GetDependency<RoomServiceViewModel>();
                    case ContentNavMode.Spa:
                        return _dependencyContainer.GetDependency<SpaViewModel>();
                    case ContentNavMode.Music:
                        return _dependencyContainer.GetDependency<MusicViewModel>();
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
