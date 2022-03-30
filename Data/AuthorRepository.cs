using Dapper;
using Microsoft.EntityFrameworkCore;
using NewsDesk.Context;
using NewsDesk.Interfaces;
using NewsDesk.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace NewsDesk.Data
{
    public class AuthorRepository : IRepository<Author>
    {
        private readonly IDbConnection _db;
        private readonly DbSet<Author> _authors;
        private readonly DatabaseContext _dbContext;
        public AuthorRepository(DatabaseContext dbContext)
        {
            _db = dbContext.Database.GetDbConnection();
            _dbContext = dbContext;
            _authors = dbContext.Authors;
        }

        public Author Add(Author newItem)
        {
            var sql =
                "INSERT INTO Authors (Name, Email) VALUES(@Name, @Email); " +
                "SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = _db.Query<int>(sql, newItem).Single();
            newItem.Id = id;
            return newItem;     //Dapper
            //_authors.Add(newItem);
            //_dbContext.SaveChanges();
            //return newItem;   //EF
        }

        public Author Find(int id)
        {
            return _db.Query<Author>("SELECT * FROM Authors WHERE Id = @Id", new { id }).SingleOrDefault(); //Dapper
            //return _authors.SingleOrDefault(author => author.Id == id); //EF
        }

        public List<Author> GetAll()
        {
            return _db.Query<Author>("SELECT * FROM Authors").ToList(); //Dapper
            //return _authors.Select(author => author).ToList(); //EF
        }

        public void Remove(int id)
        {
            _db.Execute("DELETE FROM Authors WHERE Id = @Id", new { id }); //Dapper
            //_authors.Remove(_authors.First(author => author.Id == id));
            //_dbContext.SaveChanges(); //EF
        }

        public Author Update(Author editItem)
        {
            var sql =
                "UPDATE Authors " +
                "SET Name = @Name, " +
                "Email = @Email " +
                "WHERE Id = @Id";
            _db.Execute(sql, editItem);
            return editItem;
        }
    }
}
