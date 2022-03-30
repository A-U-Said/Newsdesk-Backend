using NewsDesk.Models;
using System;
using System.Collections.Generic;

namespace NewsDesk.Messages

{
    public class ArticleListView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishedDate { get; set; }
        public int CategoryId { get; set; }
    }

    public class ItemsWrapper
    {
        public List<ArticleListView> Items { get; set; }
    }
}