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
         SQLiteConnection Connection;

        public DatabaseManager()
        {       
            Connection = DependencyService.Get<IDBInterface>().CreateConnection();
        }

        
        public List<Soort> GetSoorten()
        {
            return new List<Soort>(Connection.Query<Soort>("SELECT * FROM [Soort]")); 
        }

        public Soort GetSelectedSoort()
        {
            return Connection.FindWithQuery<Soort>("SELECT * FROM Soort WHERE Selected = 1");
        }

        public List<SensorValues> GetSensorValues() =>
            (from s in Connection.Table<SensorValues>() select s).ToList();

        public void AddOrUpdateStartValues(Soort s)
        {
            if (!DoesSpeciesExist(s.CropName))
                Connection.Insert(s);
            else
                Connection.Update(s);
        }

        public bool DoesSpeciesExist(string soort)
        {
            bool Equal(string s) => s == soort;
            return (from m in Connection.Table<Soort>() select m.CropName).Any(Equal);
        }
         
        public List<SensorValues> GetDate()
        {
            return new List<SensorValues>(Connection.Query<SensorValues>("Select DateTime From [SensorValues]"));
        }
        public List<SensorValues> GetTemp()
        {
            return new List<SensorValues>(Connection.Query<SensorValues>("Select Temperature From [SensorValues]"));
        }
        public List<SensorValues> GetHumidity()
        {
            return new List<SensorValues>(Connection.Query<SensorValues>("Select Humidity From SensorValues"));
        }
        public List<SensorValues> GetMoist()
        {
            return new List<SensorValues>(Connection.Query<SensorValues>("Select SoilMoisture From SensorValues"));
        }
    }
}
