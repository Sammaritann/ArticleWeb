using MongoDB.Driver;

namespace ArticleWeb.DataAccess.ArticleDAO
{
    internal class ArticleContext : IArticleContext
    {
        private readonly MongoContext context;

        public ArticleContext(MongoContext context)
        {
            this.context = context;
        }

        public IMongoCollection<Article> Articles => context.Articles;
    }
}