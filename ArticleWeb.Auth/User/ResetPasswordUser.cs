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