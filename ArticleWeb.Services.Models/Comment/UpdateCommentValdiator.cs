using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleWeb.Services.Models.Comment
{
    public class UpdateCommentValdiator : AbstractValidator<UpdateComment>
    {
        public UpdateCommentValdiator()
        {
            RuleFor(c => c.CreatedUser).NotEmpty().MaximumLength(100);
            RuleFor(c => c.CommentText).NotEmpty().MaximumLength(200);
        }
    }
}
