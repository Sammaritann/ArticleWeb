using FluentValidation;

namespace ArticleWeb.Services.Models.Article
{
    public class UpdateArticleValidator : AbstractValidator<UpdateArticle>
    {
        public UpdateArticleValidator()
        {
            RuleFor(a => a.Title).NotEmpty().MaximumLength(200);
            RuleFor(a => a.ArticleText).NotEmpty().MaximumLength(2000);
        }
    }
}