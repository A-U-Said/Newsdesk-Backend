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
    public class ArticleRepository : IRepository<Article>
    {
        //private readonly IDbConnection _db;                   //Dapper
        private readonly DatabaseContext _dbContext;
        public ArticleRepository(DatabaseContext dbContext)
        {
            //_db = dbContext.Database.GetDbConnection();       //Dapper
            _dbContext = dbContext;
        }

        public Article Add(Article newItem)
        {
            //var sql =
            //    "INSERT INTO Articles (Title, Body, PublishedDate, CategoryId, AuthorId) VALUES(@Title, @Body, @PublishedDate, @CategoryId, @AuthorId); " +
            //    "SELECT CAST(SCOPE_IDENTITY() as int)";
            //var id = _db.Query<int>(sql, newItem).Single();
            //newItem.Id = id;
            //return newItem;                 //Dapper
            _dbContext.Articles.Add(newItem);
            _dbContext.SaveChanges();
            return newItem;               //EF
        }

        public Article Find(int id)
        {
            //var sql = "SELECT * FROM Articles " +
            //            "INNER JOIN Categories ON Articles.CategoryId = Categories.id " +
            //            "INNER JOIN Authors ON Articles.AuthorId = Authors.id " +
            //            "WHERE Articles.Id = @Id";
            //return _db.Query<Article, Category, Author, Article>(sql, (article, category, author) =>
            //{
            //    article.Category = category;
            //    article.Author = author;
            //    return article;
            //}, new { id }).SingleOrDefault();                                   //Dapper
            return _dbContext.Articles
                   .Include(article => article.Category)
                   .Include(article => article.Author)
                   .Where(article => article.Id == id)
                   .FirstOrDefault();                                            //EF

        }

        public List<Article> GetAll()
        {
            //return _db.Query<Article>("SELECT * FROM Articles").ToList();   //Dapper
            return _dbContext.Articles.Select(article => article).ToList();         //EF
        }

        public void Remove(int id)
        {
            //_db.Execute("DELETE FROM Articles WHERE Id = @Id", new { id });     //Dapper
            _dbContext.Articles.Remove(_dbContext.Articles.First(article => article.Id == id));
            _dbContext.SaveChanges();                                         //EF
        }

        public Article Update(Article editItem)
        {
            //var sql =
            //    "UPDATE Articles " +
            //    "SET Title = @Title, " +
            //    "Body = @Body, " +
            //    "PublishedDate = @PublishedDate, " +
            //    "CategoryId = @CategoryId, " +
            //    "AuthorId = @AuthorId " +
            //    "WHERE Id = @Id";
            //_db.Execute(sql, editItem);
            //return editItem;                //Dapper
            var article = _dbContext.Articles.First(article => article.Id == editItem.Id);
            article.Title = editItem.Title;
            article.Body = editItem.Body;
            article.PublishedDate = editItem.PublishedDate;
            article.CategoryId = editItem.CategoryId;
            article.AuthorId = editItem.AuthorId;
            _dbContext.SaveChanges();
            return editItem;                 //EF
        }
    }
}