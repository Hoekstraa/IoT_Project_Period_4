using Garduino.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Garduino.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Controls : ContentPage
    {

        private int _wateramount;
        private int _soil;
        private int _humidity;

        DatabaseManager db = new DatabaseManager(); 
        public Controls()
        {
            InitializeComponent();
            SetLabels(); 
        }

        private void SetLabels()
        {
            HumidityLabel.Text = "Luchtvochtigheid is ingesteld op: " + Config.selectedCrop.Humidity + " %"; 
            GroundHumidityLabel.Text = "Bodem vocht is ingesteld op: " + Config.selectedCrop.GroundHumidity + " %"; 
            LightCycle.Text = "Het aantal minuten licht per dag: " + Config.selectedCrop.LightCycle; 
        }


        public void SoilSlider_DragCompleted(object sender, EventArgs e)
        {
            _soil = Convert.ToInt32(Math.Round(SoilSlider.Value));
            SoilLabel.Text = Convert.ToString(_soil);
        }

        public void HumiditySlider_DragCompleted(object sender, EventArgs e)
        {
            _humidity = Convert.ToInt32(Math.Round(HumiditySlider.Value));
            Humiditylabel.Text =  Convert.ToString(_humidity);
        }


        public void SoilSend_Clicked(object sender, EventArgs e)
        {
            Config.selectedCrop.GroundHumidity = _soil;
            SetLabels();
            db.AddOrUpdateStartValues(Config.selectedCrop);
            CC.Conn.Set("moistness_min", _soil);
        }

        public void HumiditySend_Clicked(object sender, EventArgs e)
        {
            Config.selectedCrop.Humidity = _humidity;
            SetLabels();
            db.AddOrUpdateStartValues(Config.selectedCrop);
            CC.Conn.Set("humidity_max", _humidity);
        }

        private void LichtCycle_Clicked(object sender, EventArgs e)
        {
            int lightcycle = Convert.ToInt32(lightCycleEntry.Text); 
            Config.selectedCrop.LightCycle= lightcycle;
            SetLabels();
            db.AddOrUpdateStartValues(Config.selectedCrop);
            CC.Conn.Set("light_lenght", lightcycle);
        }
    }
}