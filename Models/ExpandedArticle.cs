namespace NewsDesk.Models
{
    public class ExpandedArticle : Article
    {
        public Category CategoryExpanded { get; set; }
        public Author AuthorExpanded { get; set; }
    }
}
