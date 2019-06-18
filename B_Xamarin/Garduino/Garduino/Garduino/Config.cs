using System;
using System.Collections.Generic;
using System.Text;
using Garduino.Database;
using Garduino.Models; 

namespace Garduino
{
    public static class Config
    {
        /// <summary>
        /// Object that represents the selectedCrop
        /// </summary>
        public static Soort selectedCrop { get; set; }

        /// <summary>
        ///  int array for saving states/
        ///  [0] = light
        ///  [1] = fan
        ///  [2] = pump
        /// </summary>
        public static int[] ControlStates { get; set; }
        
    }
}
