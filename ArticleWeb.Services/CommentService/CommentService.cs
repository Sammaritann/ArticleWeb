using ArticleWeb.DataAccess.CommentDAO;
using ArticleWeb.Services.Exceptions;
using ArticleWeb.Services.Models;
using ArticleWeb.Services.Models.Comment;

using AutoMapper;

using MongoDB.Bson;
using MongoDB.Driver;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArticleWeb.Services.CommentService
{
    internal class CommentService : ICommentService
    {
        private ICommentContext commentContext;

        private IMapper mapper;

        public CommentService(IMapper mapper, ICommentContext commentContext)
        {
            this.commentContext = commentContext ?? throw new ArgumentNullException(nameof(commentContext));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<ViewComment>> GetCommentsBelongArticleAsync(string articleId)
        {
            var collection = commentContext[articleId];
            List<ViewComment> comments = new List<ViewComment>();
            using (var commentsDb = await collection.FindAsync(new BsonDocument()))
            {
                while (await commentsDb.MoveNextAsync())
                {
                    foreach (var comment in commentsDb.Current)
                    {
                        comments.Add(mapper.Map<ViewComment>(comment));
                    }
                }
            }

            return comments;
        }

        public async Task<ViewComment> GetCommentBelongArticleAsync(string articleId, string commentId)
        {
            var objectId = ObjectId.Parse(commentId);
            var commentDb = await commentContext[articleId].Find(x => x.CommentId == objectId).FirstOrDefaultAsync();

            if (commentDb is null)
            {
                throw new RequestedResourceNotFoundException("comment");
            }

            return mapper.Map<ViewComment>(commentDb);
        }

        public async Task UpdateCommentBelongArticleAsync(string articleId, string commentId, UpdateComment updateComment)
        {
            var objectId = ObjectId.Parse(commentId);

            var articleDb = await commentContext[articleId].Find(x => x.CommentId == objectId).FirstOrDefaultAsync();

            if (articleDb is null)
            {
                throw new RequestedResourceNotFoundException("comment");
            }

            var updateDocument = Builders<Comment>.Update
                .Set(u => u.CommentText, updateComment.CommentText);

            await commentContext[articleId].UpdateManyAsync(c => c.CommentId == objectId, updateDocument);
        }

        public async Task<ViewComment> AddCommentBelongArticleAsync(string articleId, UpdateComment updateComment, string userName)
        {
            var commentDb = mapper.Map<Comment>(updateComment);
            commentDb.CreatedDate = DateTime.UtcNow;
            commentDb.CreatedUser = userName;
            await commentContext[articleId].InsertOneAsync(commentDb);
            return mapper.Map<ViewComment>(commentDb);
        }

        public async Task DeleteCommentBelongArticleAsync(string articleId, string commentId)
        {
            var objectId = ObjectId.Parse(commentId);

            await commentContext[articleId].DeleteOneAsync(a => a.CommentId == objectId);
        }

        public void CreateCommentsCollection(string id)
        {
            commentContext.CreateCommentCollection(id);
        }

        public void DeleteCommentCollection(string id)
        {
            commentContext.DeleteCommentCollection(id);
        }
    }
}