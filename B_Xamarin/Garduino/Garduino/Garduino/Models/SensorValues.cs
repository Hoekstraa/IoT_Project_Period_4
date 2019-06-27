using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Garduino.Database
{
    [Table("SensorValues")]
    class SensorValues
    {
        [PrimaryKey, Unique] public string DateTime { get; set; }
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public int SoilMoisture { get; set; }
        public int FanInterval { get; set; }

    }
}
