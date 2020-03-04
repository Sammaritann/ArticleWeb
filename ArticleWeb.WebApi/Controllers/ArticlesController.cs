using ArticleWeb.Services.Models;
using ArticleWeb.Services.Models.Article;
using ArticleWeb.Services.Models.Comment;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Threading.Tasks;

namespace ArticleWeb.WebApi.Controllers
{
    [Route("api/articles")]
    [EnableCors("Default")]
    public class ArticlesController : ControllerBase
    {
        private IArticleService articleService;

        private ICommentService commentService;

        public ArticlesController(IArticleService articleService, ICommentService commentService)
        {
            this.articleService = articleService ?? throw new ArgumentNullException(nameof(articleService));
            this.commentService = commentService ?? throw new ArgumentNullException(nameof(commentService));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetArticles()
        {
            var articles = await articleService.GetArticlesAsync();

            return Ok(articles);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetArticle(string id)
        {
            var article = await articleService.GetArticleAsync(id);

            return Ok(article);
        }

        [HttpPost]
        [Route("")]
        [Authorize]
        public async Task<IActionResult> AddArticle([FromBody] UpdateArticle updateArticle)
        {
            if (ModelState.IsValid)
            {
                var article = await articleService.CreateArticleAsync(updateArticle, User.Identity.Name);
                var location = string.Format("/api/articles/{0}", article.ArticleId);
                commentService.CreateCommentsCollection(article.ArticleId);

                return Created(location, article);
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateArticle(string id, [FromBody] UpdateArticle updateArticle)
        {
            if (ModelState.IsValid)
            {
                await articleService.UpdateArticleAsync(id, updateArticle);

                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteArticle(string id)
        {
            await articleService.DeleteArticleAsync(id);
            commentService.DeleteCommentCollection(id);

            return Ok();
        }

        [HttpGet]
        [Route("{id}/comments")]
        public async Task<IActionResult> GetRelatedComments(string id)
        {
            var comments = await commentService.GetCommentsBelongArticleAsync(id);

            return Ok(comments);
        }

        [HttpGet]
        [Route("{id}/comments/{commentId}")]
        public async Task<IActionResult> GetRelatedComments(string id, string commentId)
        {
            var comments = await commentService.GetCommentBelongArticleAsync(id, commentId);

            return Ok(comments);
        }

        [HttpPost]
        [Route("{id}/comments")]
        [Authorize]
        public async Task<IActionResult> AddCommentBelowArticle(string id, [FromBody] UpdateComment updateComment)
        {
            if (ModelState.IsValid)
            {
                var comment = await commentService.AddCommentBelongArticleAsync(id, updateComment, User.Identity.Name);
                var location = string.Format("/api/articles/{0}/comments/{1}", id, comment.CommentId);

                return Created(location, comment);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("{id}/comments/{commentId}")]
        [Authorize]
        public async Task<IActionResult> UpdateCommentBelongArticle(string id, string commentId, [FromBody] UpdateComment updateComment)
        {
            if (ModelState.IsValid)
            {
                await commentService.UpdateCommentBelongArticleAsync(id, commentId, updateComment);

                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}/comments/{commentId}")]
        [Authorize]
        public async Task<IActionResult> DeleteCommentBelongArticle(string id, string commentId)
        {
            await commentService.DeleteCommentBelongArticleAsync(id, commentId);

            return Ok();
        }
    }
}