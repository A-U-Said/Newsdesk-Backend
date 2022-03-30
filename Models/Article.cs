using System;


namespace NewsDesk.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int? Category { get; set; }
        public int? Author { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
