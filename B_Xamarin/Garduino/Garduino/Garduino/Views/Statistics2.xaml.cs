using Garduino.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Garduino.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Statistics2 : ContentPage
    {
        DatabaseManager databaseManager = new DatabaseManager();
        
        public Statistics2()
        {
            InitializeComponent();
            
             DateTimeList.ItemsSource = databaseManager.GetAll(); 
             TempList.ItemsSource=  databaseManager.GetAll();
             HumidityList.ItemsSource = databaseManager.GetAll();
             MoistList.ItemsSource = databaseManager.GetAll();


        }
    }
}