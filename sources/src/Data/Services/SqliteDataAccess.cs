using System.Configuration;
using System.Data;
using System.Data.SQLite;
using Dapper;
using StopWatch.Data.Models;

namespace StopWatch.Data.Services
{
    public class SqliteDataAccess
    {
#pragma warning disable SA1401 // Fields should be private needs to be public
        public static string DefaultConnectionString = ".\\WrongLocation.db";
#pragma warning restore SA1401 // Fields should be private

        public static void SaveLaborEntry(TimeTracker addSaveLaborEntry)
        {
            using (IDbConnection connection = new SQLiteConnection(DefaultConnectionString))
            {
                connection.Execute("insert into TimeTracker (TimeType, SubGroupTimeType, Notes, WorkedDate, TimeWorkedAmount, DateTimeEntered) values (@TimeType, @SubGroupTimeType, @Notes, @WorkedDate, @TimeWorkedAmount, @DateTimeEntered)", addSaveLaborEntry);
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
