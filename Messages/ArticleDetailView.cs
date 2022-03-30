using NewsDesk.Models;

namespace NewsDesk.Messages
{
    public class ArticleDetailView : ArticleListView
    {
        public string Body { get; set; }
        public Author Author { get; set; }
        public new Category Category { get; set; }
    }
}
