namespace ArticleWeb.Auth.User
{
    /// <summary>
    /// Represents reset password user model.
    /// </summary>
    public class ResetPasswordUser
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public string UserId { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the confirm passwrod.
        /// </summary>
        /// <value>
        /// The confirm passwrod.
        /// </value>
        public string ConfirmPasswrod { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string Code { get; set; }
    }
}