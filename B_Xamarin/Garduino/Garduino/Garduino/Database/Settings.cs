using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Garduino.Database
{
    class Settings
    {
        [PrimaryKey]
        public string SelectedCrop { get; set; }
        public string CropSelected { get; set; }
    }
}
