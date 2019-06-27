using Garduino.Database;
using Garduino.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CC;

    
namespace Garduino
{
    public partial class App : Application
    {
        DatabaseManager db = new DatabaseManager();

        public App()
        {
            InitializeComponent();
            Config.selectedCrop = db.GetSelectedSoort();
        }

        protected override void OnStart()
        {

            // Get states of arduino for start-up
            Config.ControlStates = new int[3];
            Config.ControlStates = Config.GetStates();

            //Add items to database
            string datetime = Convert.ToString(DateTime.Now);
            int temp = Convert.ToInt32(Conn.Get("tmp"));
            int humid = Convert.ToInt32(Conn.Get("hmd"));
            int soilmoist = Convert.ToInt32(Conn.Get("gnd"));
            db.addValues(datetime, temp, humid, soilmoist);

            // Get selected soort 
            Config.selectedCrop = db.GetSelectedSoort();

            if (Config.selectedCrop != null)
                MainPage = new MasterPage();
            else
                MainPage = new Setup_Select();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
