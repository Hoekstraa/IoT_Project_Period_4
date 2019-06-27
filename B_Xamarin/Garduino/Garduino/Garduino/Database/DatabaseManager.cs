using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using Xamarin.Forms;
using Garduino.Models;
using CC;

namespace Garduino.Database
{
   
    class DatabaseManager
    {
         SQLiteConnection Connection;

        public DatabaseManager()
        {       
            Connection = DependencyService.Get<IDBInterface>().CreateConnection();
        }

        
        public Soort GetSoort(string soortnaam)
        {
            return Connection.FindWithQuery<Soort>("SELECT * FROM [Soort] WHERE CropName = @0", soortnaam); 
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
         
       
        public List<SensorValues> GetAll()
        {
            return new List<SensorValues>(Connection.Query<SensorValues>("Select * From SensorValues"));
        }

        public void addValues(string datetime, int temperature, int humidity, int soilMoisture)
        {
            Connection.Insert(new SensorValues { DateTime = datetime, Temperature = temperature, Humidity = humidity, SoilMoisture = soilMoisture });
        }
        
    }
}
