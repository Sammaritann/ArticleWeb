using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using System;

namespace ArticleWeb.DataAccess.ArticleDAO
{
    /// <summary>
    /// Represents article.
    /// </summary>
    public class Article
    {
        /// <summary>
        /// Gets or sets the article identifier.
        /// </summary>
        /// <value>
        /// The article identifier.
        /// </value>
        [BsonId]
        public ObjectId ArticleId { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [BsonRequired]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the created user.
        /// </summary>
        /// <value>
        /// The created user.
        /// </value>
        [BsonRequired]
        public string CreatedUser { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        [BsonRequired]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the article text.
        /// </summary>
        /// <value>
        /// The article text.
        /// </value>
        public string ArticleText { get; set; }
    }
}