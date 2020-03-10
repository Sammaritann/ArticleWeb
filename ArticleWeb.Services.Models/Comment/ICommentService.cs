using ArticleWeb.Services.Models.Comment;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArticleWeb.Services.Models
{
    /// <summary>
    /// Represents comment service.
    /// </summary>
    public interface ICommentService
    {
        /// <summary>
        /// Adds the comment belong article asynchronous.
        /// </summary>
        /// <param name="articleId">The article identifier.</param>
        /// <param name="updateComment">The update comment.</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        Task<ViewComment> AddCommentBelongArticleAsync(string articleId, UpdateComment updateComment, string userName);

        /// <summary>
        /// Creates the comments collection.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void CreateCommentsCollection(string id);

        /// <summary>
        /// Deletes the comment belong article asynchronous.
        /// </summary>
        /// <param name="articleId">The article identifier.</param>
        /// <param name="commentId">The comment identifier.</param>
        /// <returns></returns>
        Task DeleteCommentBelongArticleAsync(string articleId, string commentId);

        /// <summary>
        /// Deletes the comment collection.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteCommentCollection(string id);

        /// <summary>
        /// Gets the comment belong article asynchronous.
        /// </summary>
        /// <param name="articleId">The article identifier.</param>
        /// <param name="commentId">The comment identifier.</param>
        /// <returns></returns>
        Task<ViewComment> GetCommentBelongArticleAsync(string articleId, string commentId);

        /// <summary>
        /// Gets the comments belong article asynchronous.
        /// </summary>
        /// <param name="articleId">The article identifier.</param>
        /// <returns></returns>
        Task<List<ViewComment>> GetCommentsBelongArticleAsync(string articleId);

        /// <summary>
        /// Updates the comment belong article asynchronous.
        /// </summary>
        /// <param name="articleId">The article identifier.</param>
        /// <param name="commentId">The comment identifier.</param>
        /// <param name="updateComment">The update comment.</param>
        /// <returns></returns>
        Task UpdateCommentBelongArticleAsync(string articleId, string commentId, UpdateComment updateComment);
    }
}