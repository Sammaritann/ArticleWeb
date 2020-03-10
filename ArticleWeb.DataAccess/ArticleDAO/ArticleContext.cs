using MongoDB.Driver;

namespace ArticleWeb.DataAccess.ArticleDAO
{
    /// <summary>
    /// Represents article context.
    /// </summary>
    /// <seealso cref="ArticleWeb.DataAccess.ArticleDAO.IArticleContext" />
    internal class ArticleContext : IArticleContext
    {
        private readonly MongoContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleContext"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ArticleContext(MongoContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets the articles.
        /// </summary>
        /// <value>
        /// The articles.
        /// </value>
        public IMongoCollection<Article> Articles => context.Articles;
    }
}