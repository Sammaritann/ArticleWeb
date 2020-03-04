using ArticleWeb.Services.Models;

using Autofac;

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