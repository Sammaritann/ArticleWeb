using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ArticleWeb.DataAccess.CommentDAO
{
    public class Comment
    {
        [BsonId]
        public ObjectId CommentId { get; set; }

        [BsonRequired]
        public string CreatedUser { get; set; }

        [BsonRequired]
        public DateTime CreatedDate { get; set; }

        [BsonRequired]
        public string CommentText { get; set; }
    }
}
