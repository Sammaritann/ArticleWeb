﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleWeb.Auth
{
    public class RegUser
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
