using SQLite;

namespace Garduino.Database
{
    public interface IDBInterface
    {
        SQLiteConnection CreateConnection();
    }
}
