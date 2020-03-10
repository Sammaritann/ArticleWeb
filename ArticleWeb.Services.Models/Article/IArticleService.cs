using ArticleWeb.Services.Models.Article;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArticleWeb.Services.Models
{
    /// <summary>
    /// Represents article service.
    /// </summary>
    public interface IArticleService
    {
        /// <summary>
        /// Creates the article asynchronous.
        /// </summary>
        /// <param name="updateArticle">The update article.</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        Task<ViewArticle> CreateArticleAsync(UpdateArticle updateArticle, string userName);

        /// <summary>
        /// Deletes the article asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task DeleteArticleAsync(string id);

        /// <summary>
        /// Gets the article asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<ViewArticle> GetArticleAsync(string id);

        /// <summary>
        /// Gets the articles asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<List<ViewArticleListItem>> GetArticlesAsync();

        /// <summary>
        /// Updates the article asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="updateArticle">The update article.</param>
        /// <returns></returns>
        Task UpdateArticleAsync(string id, UpdateArticle updateArticle);
    }
}