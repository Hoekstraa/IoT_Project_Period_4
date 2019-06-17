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

        public App()
        {
            InitializeComponent();
            Config.selectedCrop = db.GetSelectedSoort();
        }

        protected override void OnStart()
        {
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
