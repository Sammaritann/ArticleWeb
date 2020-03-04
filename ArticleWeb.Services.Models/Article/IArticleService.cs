using ArticleWeb.Services.Models.Article;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArticleWeb.Services.Models
{
    public interface IArticleService
    {
        Task<ViewArticle> CreateArticleAsync(UpdateArticle updateArticle, string userName);

        Task DeleteArticleAsync(string id);

        Task<ViewArticle> GetArticleAsync(string id);

        Task<List<ViewArticleListItem>> GetArticlesAsync();

        Task UpdateArticleAsync(string id, UpdateArticle updateArticle);
    }
}