using NewsDesk.Interfaces;
using NewsDesk.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Dapper;
using NewsDesk.Context;
using Microsoft.EntityFrameworkCore;

namespace NewsDesk.Data
{
    public class ArticleRepository : IRepository<Article, ExpandedArticle>
    {
        private readonly IDbConnection _db;
        private readonly DbSet<Article> _articles;
        public ArticleRepository(DatabaseContext _dbContext)
        {
            _db = _dbContext.Database.GetDbConnection();
            _articles = _dbContext.Articles;
        }

        public Article Add(Article newItem)
        {
            var sql =
                "INSERT INTO Articles (Title, Body, PublishedDate, Category, Author) VALUES(@Title, @Body, @PublishedDate, @Category, @Author); " +
                "SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = _db.Query<int>(sql, newItem).Single();
            newItem.Id = id;
            return newItem;
        }

        public ExpandedArticle Find(int id)
        {
            var sql = "SELECT * FROM Articles " +
                        "INNER JOIN Categories ON Articles.Category = Categories.id " +
                        "INNER JOIN Authors ON Articles.Author = Authors.id " +
                        "WHERE Articles.Id = @Id";
            return _db.Query<ExpandedArticle, Category, Author, ExpandedArticle>(sql, (article, category, author) =>
            {
                article.CategoryExpanded = category;
                article.AuthorExpanded = author;
                return article;
            }, new { id }).SingleOrDefault();

            //return _articles.SingleOrDefault(article => article.Id == id); //EF
        }

        public List<Article> GetAll()
        {
            return _db.Query<Article>("SELECT * FROM Articles").ToList(); //Dapper
            //return _articles.Select(article => article).ToList(); //EF
        }

        public void Remove(int id)
        {
            _db.Execute("DELETE FROM Articles WHERE Id = @Id", new { id });
        }

        public Article Update(Article editItem)
        {
            var sql =
                "UPDATE Articles " +
                "SET Title = @Title, " +
                "Body = @Body, " +
                "PublishedDate = @PublishedDate, " +
                "Category = @Category, " +
                "Author = @Author " +
                "WHERE Id = @Id";
            _db.Execute(sql, editItem);
            return editItem;
        }
    }
}