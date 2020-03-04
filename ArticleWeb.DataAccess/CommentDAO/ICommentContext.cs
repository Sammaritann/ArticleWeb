using MongoDB.Driver;

namespace ArticleWeb.DataAccess.CommentDAO
{
    public interface ICommentContext
    {
        IMongoCollection<Comment> this[string articleId] { get;}

        void CreateCommentCollection(string id);

        void DeleteCommentCollection(string id);
    }
}