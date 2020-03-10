namespace ArticleWeb.Services.Models.Article
{
    /// <summary>
    /// Represents request model article.
    /// </summary>
    public class UpdateArticle
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the article text.
        /// </summary>
        /// <value>
        /// The article text.
        /// </value>
        public string ArticleText { get; set; }
    }
}