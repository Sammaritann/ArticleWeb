using ArticleWeb.DataAccess.ArticleDAO;
using ArticleWeb.Services.Models;
using ArticleWeb.Services.Models.Article;

using MongoDB.Bson;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArticleWeb.Services.Test.AericleService
{
    internal class FakeArticleService : IArticleService
    {
        private readonly IArticleContext context;

        public FakeArticleService(IArticleContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<ViewArticle> CreateArticleAsync(UpdateArticle updateArticle)
        {
            throw new NotImplementedException();
        }

        public Task DeleteArticleAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ViewArticle> GetArticleAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ViewArticleListItem>> GetArticlesAsync()
        {
            List<ViewArticleListItem> items = new List<ViewArticleListItem>();
            var article = context.Articles;
            var viewArticle = await article.FindAsync<Article>(new BsonDocument());
            foreach (var item in viewArticle.Current)
            {
                items.Add(new ViewArticleListItem()
                {
                    ArticleId = item.ArticleId.ToString(),
                    CreatedDate = item.CreatedDate,
                    CreatedUser = item.CreatedUser,
                    Title = item.Title
                }); ;
            }

            return items;
        }

        public Task UpdateArticleAsync(string id, UpdateArticle updateArticle)
        {
            throw new NotImplementedException();
        }
    }
}