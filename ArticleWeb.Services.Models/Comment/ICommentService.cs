using ArticleWeb.Services.Models.Comment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArticleWeb.Services.Models
{
    public interface ICommentService
    {
        Task<ViewComment> AddCommentBelongArticleAsync(string articleId, UpdateComment updateComment);
        void CreateCommentsCollection(string id);
        Task DeleteCommentBelongArticleAsync(string articleId, string commentId);
        void DeleteCommentCollection(string id);
        Task<ViewComment> GetCommentBelongArticleAsync(string articleId, string commentId);
        Task<List<ViewComment>> GetCommentsBelongArticleAsync(string articleId);
        Task UpdateCommentBelongArticleAsync(string articleId, string commentId, UpdateComment updateComment);
    }
}