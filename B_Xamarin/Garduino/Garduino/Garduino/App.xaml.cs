using Garduino.Database;
using Garduino.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml; 

namespace Garduino
{
    public partial class App : Application
    {
        DatabaseManager db = new DatabaseManager();
        List<Database.Settings> settings = new List<Database.Settings>(); 

        public App()
        {
            InitializeComponent();
            settings = db.GetSettings();

            if (settings[0] != null)
            {
                MainPage = new MasterPage();
            }
            else
            {
                MainPage = new Setup_Select(); 
            }
        }

        protected override void OnStart()
        {

            if (settings[0] != null)
            {
                Config.cropSelected = settings[0].ToString(); 
                MainPage = new MasterPage();
            }
            else
            {
                MainPage = new Setup_Select();
            }
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
