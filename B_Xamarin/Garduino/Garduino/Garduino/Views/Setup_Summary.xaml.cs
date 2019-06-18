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
            SelectedLabel.Text = Config.selectedCrop.Selected.ToString();
            DateSelectedLabel.Text = Config.selectedCrop.DateSelected;
            ImageSourceLabel.Text = Config.selectedCrop.ImageSource;
            HumidityLabel.Text = Config.selectedCrop.Humidity.ToString();
            GroundHumidityLabel.Text = Config.selectedCrop.GroundHumidity.ToString();
            LightCycleLabel.Text = Config.selectedCrop.LightCycle.ToString();
            WaterAmountLabel.Text = Config.selectedCrop.WaterAmount.ToString();
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
            Application.Current.MainPage = new MasterPage(); 
        }


    }
}