using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleWeb.Services.Models.Article
{
    public class ViewArticle
    {
        public string ArticleId { get; set; }
        public string Title { get; set; }

        public string CreatedUser { get; set; }

        public DateTime CreatedDate { get; set; }

        public string ArticleText { get; set; }
    }
}
