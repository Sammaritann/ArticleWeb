using ArticleWeb.DataAccess.ArticleDAO;
using ArticleWeb.Services.Exceptions;
using ArticleWeb.Services.Models;
using ArticleWeb.Services.Models.Article;

using AutoMapper;

using Microsoft.AspNet.Identity;

using MongoDB.Bson;
using MongoDB.Driver;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArticleWeb.Services.ArticleService
{
    /// <summary>
    /// Represents article service.
    /// </summary>
    /// <seealso cref="ArticleWeb.Services.Models.IArticleService" />
    internal class ArticleService : IArticleService
    {
        private IArticleContext articleContext;

        private IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleService"/> class.
        /// </summary>
        /// <param name="articleContext">The article context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <exception cref="ArgumentNullException">
        /// articleContext
        /// or
        /// articleContext
        /// </exception>
        public ArticleService(IArticleContext articleContext, IMapper mapper)
        {
            this.articleContext = articleContext ?? throw new ArgumentNullException(nameof(articleContext));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(articleContext));
        }

        /// <summary>
        /// Gets the articles asynchronous.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Gets the article asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="RequestedResourceNotFoundException">article</exception>
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

        /// <summary>
        /// Creates the article asynchronous.
        /// </summary>
        /// <param name="updateArticle">The update article.</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        /// <exception cref="RequestedResourceHasConflictException">Title</exception>
        public async Task<ViewArticle> CreateArticleAsync(UpdateArticle updateArticle, string userName)
        {
            var articleCount = await articleContext.Articles.Find(x => x.Title == updateArticle.Title).CountDocumentsAsync();

            if (articleCount > 0)
            {
                throw new RequestedResourceHasConflictException("Title");
            }

            var articleDb = mapper.Map<Article>(updateArticle);
            articleDb.CreatedDate = DateTime.UtcNow;
            articleDb.CreatedUser = userName;
            await articleContext.Articles.InsertOneAsync(articleDb);
            return mapper.Map<ViewArticle>(articleDb);
        }

        /// <summary>
        /// Updates the article asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="updateArticle">The update article.</param>
        /// <exception cref="RequestedResourceNotFoundException">article</exception>
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

        /// <summary>
        /// Deletes the article asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async Task DeleteArticleAsync(string id)
        {
            var objectId = ObjectId.Parse(id);

            await articleContext.Articles.DeleteOneAsync(a => a.ArticleId == objectId);
        }
    }
}