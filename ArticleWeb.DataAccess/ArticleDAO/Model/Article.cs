using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using System;

namespace ArticleWeb.DataAccess.ArticleDAO
{
    public class Article
    {
        [BsonId]
        public ObjectId ArticleId { get; set; }

        [BsonRequired]
        public string Title { get; set; }

        [BsonRequired]
        public string CreatedUser { get; set; }

        [BsonRequired]
        public DateTime CreatedDate { get; set; }

        public string ArticleText { get; set; }
    }
}