using System.IO;
using SQLite;
using Garduino.Database;
using Environment = System.Environment;

namespace Garduino.Droid
{
    public class DatabaseService : IDBInterface
    {
        public SQLiteConnection CreateConnection()
        {
            var sqliteFilename = "MovieDB.db";
            string documentDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentDirectoryPath, sqliteFilename);

            if (!File.Exists(path))
            {
                using (var binaryReader = new BinaryReader(Android.App.Application.Context.Assets.Open(sqliteFilename)))
                {
                    using (var binaryWriter = new BinaryWriter(new FileStream(path, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int length = 0;
                        while ((length = binaryReader.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            binaryWriter.Write(buffer, 0, length);
                        }
                    }
                }
            }
            var connection = new SQLiteConnection(path);

            return connection;
        }
    }
}