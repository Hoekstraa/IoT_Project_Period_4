using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Garduino
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            SetParameters();
            setImages();
            
        }

        void SetParameters()
        {
            DateTime datePlanted = DateTime.Parse(Config.selectedCrop.DateSelected);
            DateTime estDone = datePlanted.AddDays(Config.selectedCrop.DaysToFinish);

            datePlantedLabel.Text = datePlanted.ToString("dd-MM-yyyy");
            estDoneLabel.Text = estDone.ToString("dd-MM-yyyy");
            cropImg.Source = Config.selectedCrop.ImageSource;

            string temp = "23";
            string moist = "34";
            string soil = "45";
            string licht = "Aan";
            string ventilator = "Uit";
            string waterpomp = "Uit";

            TempLabel.Text = temp + " °C";
            MoistLabel.Text = moist + " %";
            SoilLabel.Text = soil + " %";
            LightLabel.Text = licht;
            FanLabel.Text = ventilator;
            PumpLabel.Text = waterpomp; 
        }

        /// <summary>
        /// Set Images bases on states given at app start-up
        /// </summary>
        private void setImages()
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

        private void SelectImage_Clicked(object sender, EventArgs e)
        {
            // Gets name of selected crop
            var buttonSender = (Image)sender;
            string buttonName = buttonSender.ClassId;

            if(buttonName == "light")
            {
                // Connection toggle light
                // Connection change state 
                if(Config.ControlStates[0] == 1)
                {

                }
                    
            }
            else if (buttonName == "fan")
            {
                // Connection toggle fan
                if (Config.ControlStates[1] == 1)
                {

                }
            }
            else if(buttonName == "pump")
            {
                // Connection toggle pump 
                if (Config.ControlStates[2] == 1)
                {

                }
            }
        }

    }
}
