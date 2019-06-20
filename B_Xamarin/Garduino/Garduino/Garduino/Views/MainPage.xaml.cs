using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CC;

namespace Garduino
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            // Get dateTimes
            DateTime datePlanted = DateTime.Parse(Config.selectedCrop.DateSelected);
            DateTime estDone = datePlanted.AddDays(Config.selectedCrop.DaysToFinish);
            // Set dateTimes
            datePlantedLabel.Text = datePlanted.ToString("dd-MM-yyyy");
            estDoneLabel.Text = estDone.ToString("dd-MM-yyyy");
            cropImg.Source = Config.selectedCrop.ImageSource;

            // Set images
            SetFanImage();
            SetLightImage();
            SetPumpImage();
            SetSensorValues();

            // Get and set sensorvalues

            Device.StartTimer(TimeSpan.FromSeconds(30), () =>
            {
                SetSensorValues();
                return true; 
            });


        }
        
        private void SetSensorValues()
        {

            string temp = Conn.Get("tmp");
            string humid = Conn.Get("hmd");
            string soil = Conn.Get("gnd");

            TempLabel.Text = temp + " °C";
            MoistLabel.Text = humid + " %";
            SoilLabel.Text = soil + " %";
        }


        private void SelectImage_Clicked(object sender, EventArgs e)
        {
            // Gets name of selected crop
            var buttonSender = (Image)sender;
            string buttonName = buttonSender.ClassId;
            int []stateArray = Config.GetStates();


            if (buttonName == "light")
            {
                // Connection toggle light
                // Connection change state 
                if (stateArray[0] == 0)//if off turn on 
                {
                    CC.Conn.Set("state[0]", 1);
                    Config.ControlStates[0] = 1;
                }
                else // if on turn off
                {
                    CC.Conn.Set("state[0]", 0);
                    Config.ControlStates[0] = 0;
                }
                SetLightImage();
            }
            else if (buttonName == "fan")
            {
                if (stateArray[1] == 0)
                {
                    CC.Conn.Set("state[1]", 1);
                    Config.ControlStates[1] = 1;
                }
                else
                {
                    CC.Conn.Set("state[1]", 0);
                    Config.ControlStates[1] = 0;
                }
                SetFanImage();
            }
            else if(buttonName == "pump")
            {
                if (stateArray[2] == 0)
                {
                    CC.Conn.Set("state[2]", 1);
                    Config.ControlStates[2] = 1;
                }
                else
                {
                    CC.Conn.Set("state[2]", 0);
                    Config.ControlStates[2] = 0;
                }
                SetPumpImage();
            }
        }

        /// <summary>
        /// Set Images bases on states given at app start-up
        /// </summary>
        private void SetLightImage()
        {
            if (Config.ControlStates[0] == 1)
            {
                LightImg.Source = "lightON.png";
                LightLabel.Text = "Aan";
            }
            else
            {
                LightImg.Source = "lightOFF.png";
                LightLabel.Text = "Uit";
            }
        }

        private void SetFanImage()
        {
            if (Config.ControlStates[1] == 1)
            {
                FanImg.Source = "fanON.png";
                FanLabel.Text = "Aan";
            }
            else
            {
                FanImg.Source = "fanOFF.png";
                FanLabel.Text = "Uit";
            }
        }

        private void SetPumpImage()
        {
            if (Config.ControlStates[2] == 1)
            {
                PumpImg.Source = "pumpON.png";
                PumpLabel.Text = "Aan";
            }
            else
            {
                PumpImg.Source = "pumpOFF.png";
                PumpLabel.Text = "Uit";
            }
        }

    }
}
