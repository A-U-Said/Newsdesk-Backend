namespace NewsDesk.Messages
{
    public class NewArticleCommand
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int? Category { get; set; }
        public int? Author { get; set; }
}
}
