using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleWeb.DataAccess
{
    public class DependencyRegistrationModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ArticleDAO.ArticleContext>().As<ArticleDAO.IArticleContext>();
            builder.RegisterType<CommentDAO.CommentContext>().As<CommentDAO.ICommentContext>();
            builder.RegisterType<MongoContext>().SingleInstance();
        }
    }
}
