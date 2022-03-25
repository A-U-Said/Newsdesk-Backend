using Dapper;
using Microsoft.Data.SqlClient;
using NewsDesk.Context;
using NewsDesk.Interfaces;
using NewsDesk.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace NewsDesk.Data
{
    public class CategoriesRepository : IRepository<Category>
    {
        private IDbConnection _db;
        public CategoriesRepository(DatabaseContext _dbContext)
        {
            _db = new SqlConnection(_dbContext.ConnectionString);
        }

        public Category Add(Category newItem)
        {
            var sql =
                "INSERT INTO Categories (Name) VALUES(@Name); " +
                "SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = _db.Query<int>(sql, newItem).Single();
            newItem.Id = id;
            return newItem;
        }

        public Category Find(int id)
        {
            return _db.Query<Category>("SELECT * FROM Categories WHERE Id = @Id", new { id }).SingleOrDefault();
        }

        public List<Category> GetAll()
        {
            return _db.Query<Category>("SELECT * FROM Categories").ToList();
        }

        public void Remove(int id)
        {
            _db.Execute("DELETE FROM Categories WHERE Id = @Id", new { id });
        }

        public Category Update(Category editItem)
        {
            var sql =
                "UPDATE Categories " +
                "SET Name = @Name, " +
                "WHERE Id = @Id";
            _db.Execute(sql, editItem);
            return editItem;
        }
    }
}
