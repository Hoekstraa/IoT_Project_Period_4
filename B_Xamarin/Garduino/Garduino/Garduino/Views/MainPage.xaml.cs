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
            setParameters();
        }

        void setParameters()
        {
            DateTime datePlanted = DateTime.Now;
            DateTime estDone = DateTime.Today.AddDays(10);

            datePlantedLabel.Text = datePlanted.ToString("dd-MM-yyyy") ; 
            estDoneLabel.Text = estDone.ToString("dd-MM-yyyy") ; 
           
            string temp = "23";
            string moist = "34";
            string soil = "45";
            string licht = "Aan";
            string ventilator = "Uit";
            string waterpomp = "Uit";

            cropImg.Source = Config.selectedCrop.ImageSource;
            TempLabel.Text = temp + " °C";
            MoistLabel.Text = moist + " %";
            SoilLabel.Text = soil + " %";
            LightLabel.Text = licht;
            FanLabel.Text = ventilator;
            WaterLabel.Text = waterpomp; 
        }

    }
}
