using NewsDesk.Models;

namespace NewsDesk.Messages
{
    public class ArticleDetailView : ArticleListView
    {
        public string Body { get; set; }
        public AuthorDetailView Author { get; set; }
        public CategoryListView Category { get; set; }
    }
}
