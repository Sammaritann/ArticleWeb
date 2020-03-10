using MongoDB.Driver;

namespace ArticleWeb.DataAccess.ArticleDAO
{
    /// <summary>
    /// Represents article context.
    /// </summary>
    public interface IArticleContext
    {
        /// <summary>
        /// Gets the articles.
        /// </summary>
        /// <value>
        /// The articles.
        /// </value>
        IMongoCollection<Article> Articles { get; }
    }
}