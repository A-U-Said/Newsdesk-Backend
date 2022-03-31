using System.Collections.Generic;

namespace NewsDesk.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Article> ArticlesWritten { get; set; }
    }
}
