using ArticleWeb.DataAccess.ArticleDAO;
using ArticleWeb.DataAccess.CommentDAO;
using MongoDB.Driver;


namespace ArticleWeb.DataAccess
{
    internal sealed class MongoContext
    {
        private const string CommentsCollectionPrefix = "Comments";

        private readonly IMongoDatabase database;

        public IMongoCollection<Article> Articles => database.GetCollection<Article>("Article");

        public IMongoCollection<Comment> GetCollectionByArticalId(string articleId)
        {
            return database.GetCollection<Comment>(GetCollectionName(articleId));
        }

        public MongoContext()
        {
            MongoClient client = new MongoClient("mongodb+srv://admin:admin123@cluster0-gppub.azure.mongodb.net/test?retryWrites=true&w=majority");
            database = client.GetDatabase("ArticleDB");
        }

        public void CreateCommentCollection(string articleId)
        {
            database.CreateCollectionAsync(GetCollectionName(articleId));
        }

        public void DeleteCommentCollection(string articleId)
        {
            database.DropCollectionAsync(GetCollectionName(articleId));
        }

        private static string GetCollectionName(string articleId)
        {
            return CommentsCollectionPrefix + articleId;
        }

    }
}
