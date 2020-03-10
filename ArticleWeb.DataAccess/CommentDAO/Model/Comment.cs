using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using System;

namespace ArticleWeb.DataAccess.CommentDAO
{
    /// <summary>
    /// Represents comment.
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// Gets or sets the comment identifier.
        /// </summary>
        /// <value>
        /// The comment identifier.
        /// </value>
        [BsonId]
        public ObjectId CommentId { get; set; }

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
        /// Gets or sets the comment text.
        /// </summary>
        /// <value>
        /// The comment text.
        /// </value>
        [BsonRequired]
        public string CommentText { get; set; }
    }
}