using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
