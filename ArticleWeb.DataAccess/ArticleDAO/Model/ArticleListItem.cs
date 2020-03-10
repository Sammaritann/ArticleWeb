using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using System;

namespace ArticleWeb.DataAccess.ArticleDAO
{
    /// <summary>
    /// Represents article without text.
    /// </summary>
    public class ArticleListItem
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
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the created user.
        /// </summary>
        /// <value>
        /// The created user.
        /// </value>
        public string CreatedUser { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        public DateTime CreatedDate { get; set; }
    }
}