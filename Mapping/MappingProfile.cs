using AutoMapper;
using NewsDesk.Messages;
using NewsDesk.Models;

namespace NewsDesk.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Article, ArticleListView>();
            CreateMap<ExpandedArticle, ArticleDetailView>()
                .IncludeBase<Article, ArticleListView>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.AuthorExpanded))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.CategoryExpanded));

            CreateMap<Author, AuthorListView>();
            CreateMap<Author, AuthorDetailView>()
                .IncludeBase<Author, AuthorListView>();

            CreateMap<Category, CategoryListView>();

            CreateMap<NewArticleCommand, Article>();

        }
    }
}
