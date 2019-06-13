using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using Xamarin.Forms;

namespace Garduino.Database
{
    class DatabaseManager
    {
        private readonly SQLiteConnection _c;

        public DatabaseManager()
        {
            _c = DependencyService.Get<IDBInterface>().CreateConnection();
            _c.CreateTable<StartValues>();
            _c.CreateTable<SensorValues>();
        }

        public List<StartValues> GetStartValues() =>
            (from s in _c.Table<StartValues>() select s).ToList();

        public List<SensorValues> GetSensorValues() =>
    (from s in _c.Table<SensorValues>() select s).ToList();

        public void AddOrUpdateStartValues(StartValues s)
        {
            if (!DoesSpeciesExist(s.Soort))
                _c.Insert(s);
            else
                _c.Update(s);
        }

        public bool DoesSpeciesExist(string soort)
        {
            bool Equal(string s) => s == soort;
            return (from m in _c.Table<StartValues>() select m.Soort).Any(Equal);
        }
    }
}
