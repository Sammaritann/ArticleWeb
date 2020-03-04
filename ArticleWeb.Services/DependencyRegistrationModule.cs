using ArticleWeb.Services.CommentService;
using ArticleWeb.Services.Models;
using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleWeb.Services
{
    public class DependencyRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ArticleService.ArticleService>().As<IArticleService>();
            builder.RegisterType<CommentService.CommentService>().As<ICommentService>();
        }
    }
}
