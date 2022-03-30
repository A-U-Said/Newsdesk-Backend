using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NewsDesk.Context;

namespace NewsDesk.Extensions
{
    public static class DatabaseExtensions
    {
        //public static bool CanConnect<T>(this IRepository<T> dbContext)
        //    where T : IRepository<T>
        public static bool CanConnect(this DatabaseContext databaseContext)
        {
            using var testConnection = new SqlConnection(databaseContext.Database.GetDbConnection().ConnectionString);
            try
            {
                testConnection.Open();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
}
