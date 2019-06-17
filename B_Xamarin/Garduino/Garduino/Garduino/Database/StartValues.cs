using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Garduino
{
    class StartValues
    {
        [PrimaryKey, Unique]
        public string Soort { get; set; }
        public int LightCycle { get; set; }
        public int Humidity { get; set; }
        public int SoilMoisture { get; set; }
        public int FanInterval { get; set; }
    }
}
