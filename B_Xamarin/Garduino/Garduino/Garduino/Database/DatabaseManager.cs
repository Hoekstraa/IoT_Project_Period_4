using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;
using Garduino.Models;


namespace Garduino.Database
{
   
    class DatabaseManager
    {
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
