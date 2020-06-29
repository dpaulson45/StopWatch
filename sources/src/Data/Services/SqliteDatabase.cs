using System.Configuration;
using System.IO;

namespace StopWatch.Data.Services
{
    public class SqliteDatabase
    {
        private static readonly string EmptyDatabase = ConfigurationManager.AppSettings["EmptyDatabase"];

        public static void ReadySqliteDatabase(string applicationSaveDirectory, string databaseFileName)
        {
            if (!File.Exists(Path.Combine(applicationSaveDirectory, databaseFileName)))
            {
                if (File.Exists(EmptyDatabase))
                {
                    File.Copy(EmptyDatabase, Path.Combine(applicationSaveDirectory, databaseFileName));
                }
            }
        }
    }
}
