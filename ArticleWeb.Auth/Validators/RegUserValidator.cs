﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleWeb.Auth.Validators
{
    public class RegUserValidator : AbstractValidator<RegUser>
    {
        public RegUserValidator()
        {
            RuleFor(r => r.Password).NotEmpty();
            RuleFor(r => r.ConfirmPassword).NotEmpty().Must((x, y) => x.Password == y);
            RuleFor(r => r.Email).NotEmpty().EmailAddress();
            RuleFor(r => r.UserName).NotEmpty().MaximumLength(100);

        }
    }
}
