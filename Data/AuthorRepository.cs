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
        public AuthorRepository(DatabaseContext dbContext)
        {
            _db = dbContext.Database.GetDbConnection();
        }

        public Author Add(Author newItem)
        {
            var sql =
                "INSERT INTO Authors (Name, Email) VALUES(@Name, @Email); " +
                "SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = _db.Query<int>(sql, newItem).Single();
            newItem.Id = id;
            return newItem;
        }

        public Author Find(int id)
        {
            return _db.Query<Author>("SELECT * FROM Authors WHERE Id = @Id", new { id }).SingleOrDefault();
        }

        public List<Author> GetAll()
        {
            return _db.Query<Author>("SELECT * FROM Authors").ToList();
        }

        public void Remove(int id)
        {
            _db.Execute("DELETE FROM Authors WHERE Id = @Id", new { id });
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
