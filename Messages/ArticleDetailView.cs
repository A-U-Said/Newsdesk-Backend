using NewsDesk.Models;

namespace NewsDesk.Messages
{
    public class ArticleDetailView : ArticleListView
    {
        public string Body { get; set; }
        public AuthorListView Author { get; set; }
        public CategoryListView Category { get; set; }
    }
}
