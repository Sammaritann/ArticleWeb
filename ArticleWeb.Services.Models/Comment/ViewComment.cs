using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleWeb.Services.Models.Comment
{
    public class ViewComment
    {
        public string CommentId { get; set; }

        public string CreatedUser { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CommentText { get; set; }
    }
}
