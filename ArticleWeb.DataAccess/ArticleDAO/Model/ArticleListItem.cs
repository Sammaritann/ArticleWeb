using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ArticleWeb.DataAccess.ArticleDAO
{
    public class ArticleListItem
    {
        [BsonId]
        public ObjectId ArticleId { get; set; }

        public string Title { get; set; }

        public string CreatedUser { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
