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
            CreateMap<Article, ArticleDetailView>()
                .IncludeBase<Article, ArticleListView>();

            CreateMap<Author, AuthorListView>();
            CreateMap<Author, AuthorDetailView>()
                .IncludeBase<Author, AuthorListView>();

            CreateMap<Category, CategoryListView>();
            CreateMap<Category, CategoryDetailView>()
                .IncludeBase<Category, CategoryListView>();

            CreateMap<NewArticleCommand, Article>();

        }
    }
}
