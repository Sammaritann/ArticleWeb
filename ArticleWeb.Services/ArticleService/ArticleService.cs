using ArticleWeb.DataAccess.ArticleDAO;
using ArticleWeb.Services.Exceptions;
using ArticleWeb.Services.Models;
using ArticleWeb.Services.Models.Article;
using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArticleWeb.Services.ArticleService
{
    internal class ArticleService : IArticleService
    {
        private IArticleContext articleContext;

        private IMapper mapper;

        public ArticleService(IArticleContext articleContext, IMapper mapper)
        {
            this.articleContext = articleContext ?? throw new ArgumentNullException(nameof(articleContext));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(articleContext));
        }

        public async Task<List<ViewArticleListItem>> GetArticlesAsync()
        {
            List<ViewArticleListItem> articles = new List<ViewArticleListItem>();

            FindOptions<Article, ArticleListItem> projectionOption = new FindOptions<Article, ArticleListItem>
            {
                Projection = Builders<Article>.Projection.Exclude(a => a.ArticleText)
            };

            using (var articlesDb = await articleContext.Articles.FindAsync(new BsonDocument(), projectionOption))
            {
                while (await articlesDb.MoveNextAsync())
                {
                    foreach (var article in articlesDb.Current)
                    {
                        articles.Add(mapper.Map<ViewArticleListItem>(article));
                    }
                }
            }

            return articles;
        }

        public async Task<ViewArticle> GetArticleAsync(string id)
        {
            var objectId = ObjectId.Parse(id);
            var articleDb = await articleContext.Articles.Find(x => x.ArticleId == objectId).FirstOrDefaultAsync();

            if (articleDb is null)
            {
                throw new RequestedResourceNotFoundException("article");
            }

            return mapper.Map<ViewArticle>(articleDb);
        }

        public async Task<ViewArticle> CreateArticleAsync(UpdateArticle updateArticle)
        {
            var articleCount = await articleContext.Articles.Find(x => x.Title == updateArticle.Title).CountDocumentsAsync();

            if (articleCount > 0)
            {
                throw new RequestedResourceHasConflictException("Title");
            }

            var articleDb = mapper.Map<Article>(updateArticle);
            articleDb.CreatedDate = DateTime.UtcNow;
            await articleContext.Articles.InsertOneAsync(articleDb);
            return mapper.Map<ViewArticle>(articleDb);
        }

        public async Task UpdateArticleAsync(string id, UpdateArticle updateArticle)
        {
            var objectId = ObjectId.Parse(id);

            var articleDb = await articleContext.Articles.Find(x => x.ArticleId == objectId).FirstOrDefaultAsync();

            if (articleDb is null)
            {
                throw new RequestedResourceNotFoundException("article");
            }

            var updateDocument = Builders<Article>.Update
                .Set(u => u.Title, updateArticle.Title)
                .Set(u => u.ArticleText, updateArticle.ArticleText);
            await articleContext.Articles.UpdateManyAsync(a => a.ArticleId == objectId, updateDocument);
        }

        public async Task DeleteArticleAsync(string id)
        {
            var objectId = ObjectId.Parse(id);

            await articleContext.Articles.DeleteOneAsync(a => a.ArticleId == objectId);
        }
    }
}
