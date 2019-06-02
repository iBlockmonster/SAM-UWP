using SAM.DependencyContainer;
using SAM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.News
{
    public class NewsViewModel : ViewModelBase
    {
        public NewsViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            _ = WaitForInit();
        }

        private async Task WaitForInit()
        {
            await _dependencyContainer.WaitForInitComplete();
            _newsModel = _dependencyContainer.GetDependency<NewsModel>();
            _ = LoadNewsData();
        }

        private NewsModel _newsModel;

        private async Task LoadNewsData()
        {
            TopNewsHeadlines = await _newsModel.GetTopHeadlines();
        }

        private IReadOnlyList<NewsArticleData> _topNewsHeadlines;
        public IReadOnlyList<NewsArticleData> TopNewsHeadlines
        {
            get { return _topNewsHeadlines; }
            private set
            {
                if (_topNewsHeadlines != value)
                {
                    _topNewsHeadlines = value;
                    RaisePropertyChangedFromSource();
                    RaisePropertyChanged("IsNewsDataLoading");
                }
            }
        }

        public bool IsNewsDataLoading
        {
            get { return _topNewsHeadlines == null || _topNewsHeadlines.Count == 0; }
        }
    }
}
