using MongoDB.Driver;

namespace ArticleWeb.DataAccess.CommentDAO
{
    /// <summary>
    /// Represents comment context.
    /// </summary>
    /// <seealso cref="ArticleWeb.DataAccess.CommentDAO.ICommentContext" />
    internal class CommentContext : ICommentContext
    {
        private readonly MongoContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentContext"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CommentContext(MongoContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets the <see cref="IMongoCollection{Comment}"/> with the specified article identifier.
        /// </summary>
        /// <value>
        /// The <see cref="IMongoCollection{Comment}"/>.
        /// </value>
        /// <param name="articleId">The article identifier.</param>
        /// <returns></returns>
        public IMongoCollection<Comment> this[string articleId]
        {
            get => context.GetCollectionByArticalId(articleId);
        }

        /// <summary>
        /// Creates the comment collection.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void CreateCommentCollection(string id)
        {
            context.CreateCommentCollection(id);
        }

        /// <summary>
        /// Deletes the comment collection.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteCommentCollection(string id)
        {
            context.DeleteCommentCollection(id);
        }
    }
}