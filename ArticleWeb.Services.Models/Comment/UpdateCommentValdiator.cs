using FluentValidation;

namespace ArticleWeb.Services.Models.Comment
{
    public class UpdateCommentValdiator : AbstractValidator<UpdateComment>
    {
        public UpdateCommentValdiator()
        {
            RuleFor(c => c.CommentText).NotEmpty().MaximumLength(200);
        }
    }
}