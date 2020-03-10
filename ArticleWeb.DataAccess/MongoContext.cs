using ArticleWeb.DataAccess.ArticleDAO;
using ArticleWeb.DataAccess.CommentDAO;

using Microsoft.Extensions.Configuration;

using MongoDB.Driver;

using System;

namespace ArticleWeb.DataAccess
{
    /// <summary>
    /// Repreesents mongo context.
    /// </summary>
    internal sealed class MongoContext
    {
        private const string CommentsCollectionPrefix = "Comments";

        private readonly IMongoDatabase database;

        private readonly IConfiguration configuration;

        /// <summary>
        /// Gets the articles.
        /// </summary>
        /// <value>
        /// The articles.
        /// </value>
        public IMongoCollection<Article> Articles => database.GetCollection<Article>("Article");

        /// <summary>
        /// Gets the collection by artical identifier.
        /// </summary>
        /// <param name="articleId">The article identifier.</param>
        /// <returns></returns>
        public IMongoCollection<Comment> GetCollectionByArticalId(string articleId)
        {
            return database.GetCollection<Comment>(GetCollectionName(articleId));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoContext"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <exception cref="ArgumentNullException">configuration</exception>
        public MongoContext(IConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            MongoClient client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            database = client.GetDatabase("ArticleDB");
        }

        /// <summary>
        /// Creates the comment collection.
        /// </summary>
        /// <param name="articleId">The article identifier.</param>
        public void CreateCommentCollection(string articleId)
        {
            database.CreateCollectionAsync(GetCollectionName(articleId));
        }

        /// <summary>
        /// Deletes the comment collection.
        /// </summary>
        /// <param name="articleId">The article identifier.</param>
        public void DeleteCommentCollection(string articleId)
        {
            database.DropCollectionAsync(GetCollectionName(articleId));
        }

        /// <summary>
        /// Gets the name of the collection.
        /// </summary>
        /// <param name="articleId">The article identifier.</param>
        /// <returns></returns>
        private static string GetCollectionName(string articleId)
        {
            return CommentsCollectionPrefix + articleId;
        }
    }
}