using MongoDB.Driver;

namespace ArticleWeb.DataAccess.ArticleDAO
{
    public interface IArticleContext
    {
        IMongoCollection<Article> Articles { get; }
    }
}