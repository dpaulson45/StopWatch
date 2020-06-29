using System.Configuration;
using System.Data;
using System.Data.SQLite;
using Dapper;
using StopWatch.Data.Models;

namespace StopWatch.Data.Services
{
    public class SqliteDataAccess
    {
        public static string DefaultConnectionString = ".\\WrongLocation.db";
        public static void SaveLaborEntry(TimeTracker AddSaveLaborEntry)
        {
            using (IDbConnection connection = new SQLiteConnection(DefaultConnectionString))
            {
                connection.Execute("insert into TimeTracker (TimeType, SubGroupTimeType, Notes, WorkedDate, TimeWorkedAmount, DateTimeEntered) values (@TimeType, @SubGroupTimeType, @Notes, @WorkedDate, @TimeWorkedAmount, @DateTimeEntered)", AddSaveLaborEntry); 
            }
        }
        
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
