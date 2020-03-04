using ArticleWeb.DataAccess.CommentDAO;
using ArticleWeb.Services.Models.Comment;

using AutoMapper;

namespace ArticleWeb.Services.CommentService
{
    public class CommentMapperProfile : Profile
    {
        public CommentMapperProfile()
        {
            CreateMap<Comment, ViewComment>();

            CreateMap<UpdateComment, Comment>();
        }
    }
}