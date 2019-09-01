using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAM.DependencyContainer;
using SAM.Model;
using Windows.UI.Xaml;

namespace SAM.Yelp
{
    public class YelpViewModel : ViewModelBase
    {
        public YelpViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            _ = WaitForInit();
        }

        private async Task WaitForInit()
        {
            await _dependencyContainer.WaitForInitComplete();
            _yelpModel = _dependencyContainer.GetDependency<YelpModel>();
            _ = LoadYelpData();
        }

        private YelpModel _yelpModel;

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

        public event Action<YelpViewModel, BusinessData> BusinessActivated;

        private async Task LoadYelpData()
        {
            if (_localBusinesses != null)
            {
                foreach (var business in _localBusinesses)
                {
                    business.Activated -= Business_Activated;
                }
            }
            var localBusinesses = await _yelpModel.GetLocalDelivery();
            foreach (var business in localBusinesses)
            {
                business.Activated += Business_Activated;
            }

            LocalBusinesses = localBusinesses;
        }

        private IReadOnlyList<BusinessData> _localBusinesses;
        public IReadOnlyList<BusinessData> LocalBusinesses
        {
            get { return _localBusinesses; }
            private set
            {
                if (_localBusinesses != value)
                {
                    _localBusinesses = value;
                    RaisePropertyChangedFromSource();
                    RaisePropertyChanged("IsYelpDataLoading");
                }
            }
        }

        private void Business_Activated(BusinessData obj)
        {
            ActiveBusiness = obj;
            BusinessActivated?.Invoke(this, ActiveBusiness);
        }

        public bool IsYelpDataLoading
        {
            get { return _localBusinesses == null || _localBusinesses.Count == 0; }
        }

        public event Action<YelpViewModel> YelpDeactivated;

        public void onDeactivate(object sender, RoutedEventArgs e)
        {
            YelpDeactivated?.Invoke(this);
        }
    }
}
