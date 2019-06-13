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
    public partial class Statistics : ContentPage
    {
        DatabaseManager DatabaseManager = new DatabaseManager();
        
        public Statistics()
        {
            InitializeComponent();
            DateTimeList.ItemsSource = DatabaseManager.GetDate();
            TempList.ItemsSource = DatabaseManager.GetTemp();
            HumidityList.ItemsSource = DatabaseManager.GetHumidity();
            MoistList.ItemsSource = DatabaseManager.GetMoist();
        }
    }
}