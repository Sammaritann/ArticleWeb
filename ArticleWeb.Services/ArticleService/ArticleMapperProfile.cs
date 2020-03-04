using ArticleWeb.DataAccess.ArticleDAO;
using ArticleWeb.Services.Models.Article;

using AutoMapper;

namespace ArticleWeb.Services.ArticleService
{
    public class ArticleMapperProfile : Profile
    {
        public ArticleMapperProfile()
        {
            CreateMap<Article, ViewArticle>();
            CreateMap<UpdateArticle, Article>();
            CreateMap<ArticleListItem, ViewArticleListItem>();
        }
    }
}