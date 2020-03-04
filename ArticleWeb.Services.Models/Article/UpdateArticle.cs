using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleWeb.Services.Models.Article
{
    public class UpdateArticle
    {
        public string Title { get; set; }

        public string ArticleText { get; set; }

        public string CreatedUser { get; set; }

    }
}
