using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Garduino
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            setParameters();
        }

        void setParameters()
        {
            DateTime datePlanted = DateTime.Now;
            DateTime estDone = DateTime.Today.AddDays(10);

            datePlantedLabel.Text = datePlanted.ToString("dd-MM-yyyy") ; 
            estDoneLabel.Text = estDone.ToString("dd-MM-yyyy") ; 

            string imgSource = "tomaat.png";
            string temp = "23";
            string moist = "34";
            string soil = "45";
            string licht = "Aan";
            string ventilator = "Uit";
            string waterpomp = "Uit";

            cropImg.Source = imgSource; 
            TempLabel.Text = temp + " °C";
            MoistLabel.Text = moist + " %";
            SoilLabel.Text = soil + " %";
            LightLabel.Text = licht;
            FanLabel.Text = ventilator;
            WaterLabel.Text = waterpomp; 
        }

    }
}
