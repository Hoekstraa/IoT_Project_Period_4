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
         SQLiteConnection _c;

        public DatabaseManager()
        {
            
            _c = DependencyService.Get<IDBInterface>().CreateConnection();
            //_c.CreateTable<StartValues>();
            //_c.CreateTable<SensorValues>();
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
         
        public List<Settings> GetSettings()
        {
            return new List<Settings>(_c.Query<Settings>("SELECT * FROM [Settings]"));
        }

        public List<SensorValues> GetDate()
        {
            return new List<SensorValues>(_c.Query<SensorValues>("Select DateTime From [SensorValues]"));
        }
        public List<SensorValues> GetTemp()
        {
            return new List<SensorValues>(_c.Query<SensorValues>("Select Temperature From [SensorValues]"));
        }
        public List<SensorValues> GetHumidity()
        {
            return new List<SensorValues>(_c.Query<SensorValues>("Select Humidity From SensorValues"));
        }
        public List<SensorValues> GetMoist()
        {
            return new List<SensorValues>(_c.Query<SensorValues>("Select SoilMoisture From SensorValues"));
        }
    }
}
