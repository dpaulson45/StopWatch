using System.IO;
using System.Configuration;

namespace StopWatch.Data.Services
{
    public class SqliteDatabase
    {
        private static string EmptyDatabase = ConfigurationManager.AppSettings["EmptyDatabase"];
        public static void ReadySqliteDatabase(string ApplicationSaveDirectory, string DatabaseFileName)
        {
            if (!File.Exists(Path.Combine(ApplicationSaveDirectory, DatabaseFileName)))
            {
                if (File.Exists(EmptyDatabase))
                {
                    File.Copy(EmptyDatabase, Path.Combine(ApplicationSaveDirectory, DatabaseFileName));
                }
            }
        }
    }
}
