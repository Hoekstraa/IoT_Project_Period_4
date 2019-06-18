using Garduino.Database;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Garduino.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Setup_Select : ContentPage
    {
        DatabaseManager db = new DatabaseManager();
        public Setup_Select()
        {
            InitializeComponent();
        }

        public void SelectImage_Clicked(object sender, EventArgs e)
        {
            // Gets name of selected crop
            var buttonSender = (Image)sender;
            string buttonName = buttonSender.ClassId; 
 
            // Makes new soort and updates soort as selected + day selected
            Soort soort = db.GetSoort(buttonName);
            soort.DateSelected =  DateTime.Now.ToString("dd/MM/yy");

            // Sets selected crop in configfile
            Config.selectedCrop = soort;

            // Push to new page
            Navigation.PushModalAsync(new Setup_Summary());  
        }
    }
}