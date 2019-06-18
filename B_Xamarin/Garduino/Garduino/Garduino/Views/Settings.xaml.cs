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
    public partial class Settings : ContentPage
    {
        DatabaseManager db = new DatabaseManager(); 
        public Settings()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            // Sets current crop to not selected
            Config.selectedCrop.DateSelected = null;
            Config.selectedCrop.Selected = 0;

            // Updates database with new config
            db.AddOrUpdateStartValues(Config.selectedCrop);
            
            // Reset selectedCrop
            Config.selectedCrop = null;

            // Go to setuppage
            Application.Current.MainPage = new Setup_Select(); 
        }
    }
}