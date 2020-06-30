using System.Collections.Generic;
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

        public static List<TimeTracker> ReadLaborEntries(List<string> dates)
        {
            using (var connection = new SQLiteConnection(DefaultConnectionString))
            {
                connection.Open();
                var resultsList = new List<TimeTracker>();
                foreach (var date in dates)
                {
                    var query = "SELECT * FROM TimeTracker WHERE WorkedDate='" + date + "'";
                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        var results = cmd.ExecuteReader();

                        while (results.Read())
                        {
                            var timeEntry = new TimeTracker
                            {
                                TimeType = results.GetString(results.GetOrdinal("TimeType")),
                                SubGroupTimeType = results.GetString(results.GetOrdinal("SubGroupTimeType")),
                                Notes = results.GetString(results.GetOrdinal("Notes")),
                                WorkedDate = results.GetString(results.GetOrdinal("WorkedDate")),
                                TimeWorkedAmount = results.GetInt32(results.GetOrdinal("TimeWorkedAmount")),
                                DateTimeEntered = results.GetString(results.GetOrdinal("DateTimeEntered")),
                            };

                            resultsList.Add(timeEntry);
                        }
                    }
                }

                return resultsList;
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
