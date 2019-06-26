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
    public partial class Setup_Summary : ContentPage
    {
        DatabaseManager db = new DatabaseManager(); 
        public Setup_Summary()
        {
            InitializeComponent();
            SetSummary();
        }

        void SetSummary()
        {
            cropImg.Source = Config.selectedCrop.ImageSource; 
            CropNameLabel.Text = Config.selectedCrop.CropName;
            DateSelectedLabel.Text = "Begindatum: " + Config.selectedCrop.DateSelected;
            HumidityLabel.Text = "Optimale waarde luchtvochtigheid: " + Config.selectedCrop.Humidity.ToString();
            GroundHumidityLabel.Text = "Optimale waarde grondvochtigheid: " + Config.selectedCrop.GroundHumidity.ToString();
            LightCycleLabel.Text = Config.selectedCrop.LightCycle.ToString() + " uren dat het licht aan staat" ;
            WaterAmountLabel.Text = "Hoeveelheid water wat vergeven word: " + Config.selectedCrop.WaterAmount.ToString() + " ml" ;
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Config.selectedCrop = null; 
            Navigation.PopModalAsync();
        }

        private void Confrim_Clicked(object sender, EventArgs e)
        {
            Config.selectedCrop.Selected = 1;
            db.AddOrUpdateStartValues(Config.selectedCrop);
            SetStartValues();
            Application.Current.MainPage = new MasterPage(); 
        }

        private void SetStartValues()
        {
            CC.Conn.Set("light_lenght", Config.selectedCrop.LightCycle);
            CC.Conn.Set("humidity_max", Config.selectedCrop.Humidity);
            CC.Conn.Set("moistness_min", Config.selectedCrop.GroundHumidity);
        }


    }
}