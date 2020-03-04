using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleWeb.Auth.User
{
    public class ResetPasswordUser
    {
        public string UserId { get; set; }
        public string Password { get; set; }

        public string ConfirmPasswrod { get; set; }

        public string Code { get; set; }
    }
}
