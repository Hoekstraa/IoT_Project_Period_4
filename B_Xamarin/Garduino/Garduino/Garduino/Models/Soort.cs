using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Garduino
{
    public class Soort
    {
        [PrimaryKey, Unique, NotNull]
        public string CropName { get; set; }
        public int Selected { get; set; }
        public string DateSelected { get; set; }
        [Unique, NotNull]
        public string ImageSource { get; set; }
        public int Humidity { get; set; }
        public int GroundHumidity { get; set; }
        public int LightCycle { get; set; }
        public int WaterAmount { get; set; }
        public int DaysToFinish { get; set; }
    }
}
