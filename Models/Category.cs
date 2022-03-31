using System.Collections.Generic;

namespace NewsDesk.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Article> ArticlesClassed { get; set; }
    }
}
