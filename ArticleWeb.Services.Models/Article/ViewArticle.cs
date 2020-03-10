using System;

namespace ArticleWeb.Services.Models.Article
{
    /// <summary>
    /// Represents response article .
    /// </summary>
    public class ViewArticle
    {
        /// <summary>
        /// Gets or sets the article identifier.
        /// </summary>
        /// <value>
        /// The article identifier.
        /// </value>
        public string ArticleId { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the created user.
        /// </summary>
        /// <value>
        /// The created user.
        /// </value>
        public string CreatedUser { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the article text.
        /// </summary>
        /// <value>
        /// The article text.
        /// </value>
        public string ArticleText { get; set; }
    }
}