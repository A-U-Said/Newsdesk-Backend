namespace NewsDesk.Messages
{
    public class NewArticleCommand
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
}
}
