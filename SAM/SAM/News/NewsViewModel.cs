using SAM.DependencyContainer;
using SAM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

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

        private NewsArticleData _activeNewsArticle;
        public NewsArticleData ActiveNewsArticle
        {
            get { return _activeNewsArticle; }
            set
            {
                if (_activeNewsArticle != value)
                {
                    _activeNewsArticle = value;
                    RaisePropertyChangedFromSource();
                }
            }
        }

        public event Action<NewsViewModel, NewsArticleData> NewsArticleActivated;

        private async Task LoadNewsData()
        {
            if (_topNewsHeadlines != null)
            {
                foreach (var article in _topNewsHeadlines)
                {
                    article.Activated -= Article_Activated;
                }
            }
            var topNews = await _newsModel.GetTopHeadlines();
            foreach (var article in topNews)
            {
                article.Activated += Article_Activated;
            }
            TopNewsHeadlines = topNews;
        }

        private void Article_Activated(NewsArticleData obj)
        {
            ActiveNewsArticle = obj;
            NewsArticleActivated?.Invoke(this, obj);
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

        public event Action<NewsViewModel> NewsDeactivated;

        public void onDeactivate(object sender, RoutedEventArgs e)
        {
            NewsDeactivated?.Invoke(this);
        }
    }
}
