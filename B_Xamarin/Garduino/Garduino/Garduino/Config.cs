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
        
        public static int[] GetStates()
        {
            int[] stateArray = new int[3];

            //for (int i = 0; i <= 2; i++)
            //{
            //    stateArray[i] = Convert.ToInt32(CC.Conn.Get("state[" + i + "]"));
            //}
            string light = CC.Conn.Get("light");
            string fan = CC.Conn.Get("fan");
            string pump = CC.Conn.Get("pump");

            stateArray[0] = Convert.ToInt32(light.Trim());
            stateArray[1] = Convert.ToInt32(fan.Trim());
            stateArray[2] = Convert.ToInt32(pump.Trim());

            return stateArray; 
        }

        public static int GetStateLight()
        {
            string light = CC.Conn.Get("light");
            return Convert.ToInt32(light.Trim());
        }
        public static int GetStateFan()
        {
            string fan = CC.Conn.Get("fan");
            return Convert.ToInt32(fan.Trim());
        }
        public static int GetStatePump()
        {
            string pump = CC.Conn.Get("pump");
            return Convert.ToInt32(pump.Trim());
        }
    }
}
