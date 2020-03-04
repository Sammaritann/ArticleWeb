using MongoDB.Driver;

namespace ArticleWeb.DataAccess.CommentDAO
{
    internal class CommentContext : ICommentContext
    {
        private readonly MongoContext context;

        public CommentContext(MongoContext context)
        {
            this.context = context;
        }

        public IMongoCollection<Comment> this[string articleId]
        {
            get => context.GetCollectionByArticalId(articleId);
        }

        public void CreateCommentCollection(string id)
        {
            context.CreateCommentCollection(id);
        }

        public void DeleteCommentCollection(string id)
        {
            context.DeleteCommentCollection(id);
        }
    }
}