using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using Xamarin.Forms;
using Garduino.Models;


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
        SQLiteConnection Dbconnection;

        public DatabaseManager()
        {
            Dbconnection = DependencyService.Get<IDBInterface>().CreateConnection();
        }
        public string GetDate()
        {
            string iets = "13 Juni 2019";
            return iets;
        }
        public List<Stats> GetTemp()
        {
            return new List<Stats>(Dbconnection.Query<Stats>("Select Temperature From SensorValues"));
        }
        public List<Stats> GetHumidity()
        {
            return new List<Stats>(Dbconnection.Query<Stats>("Select Humidity From SensorValues"));
        }
        public List<Stats> GetMoist()
        {
            return new List<Stats>(Dbconnection.Query<Stats>("Select Moist From SensorValues"));
        }
    }
}
