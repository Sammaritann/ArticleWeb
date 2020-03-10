using MongoDB.Driver;

namespace ArticleWeb.DataAccess.CommentDAO
{
    /// <summary>
    /// Represents comment context.
    /// </summary>
    public interface ICommentContext
    {
        /// <summary>
        /// Gets the <see cref="IMongoCollection{Comment}"/> with the specified article identifier.
        /// </summary>
        /// <value>
        /// The <see cref="IMongoCollection{Comment}"/>.
        /// </value>
        /// <param name="articleId">The article identifier.</param>
        /// <returns></returns>
        IMongoCollection<Comment> this[string articleId] { get; }

        /// <summary>
        /// Creates the comment collection.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void CreateCommentCollection(string id);

        /// <summary>
        /// Deletes the comment collection.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteCommentCollection(string id);
    }
}