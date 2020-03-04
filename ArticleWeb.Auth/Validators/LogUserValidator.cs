using FluentValidation;

namespace ArticleWeb.Auth.Validators
{
    public class LogUserValidator : AbstractValidator<LogUser>
    {
        public LogUserValidator()
        {
            RuleFor(r => r.Password).NotEmpty();
            RuleFor(r => r.UserName).NotEmpty().MaximumLength(100);
        }
    }
}