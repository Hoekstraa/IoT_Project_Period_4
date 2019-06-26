using Garduino.Database;
using Microcharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Garduino.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Statistics : ContentPage
    {
        DatabaseManager DatabaseManager = new DatabaseManager();

        List<float> iets = new List<float> { 33.3f, 25.3f, 15.3f};
    
   
        
       
        
        public Statistics()
        {
            InitializeComponent();
            GetData();
        }
        private void GetData()
        {
            var source = new List<ChartEntry>();
            var source2 = new List<ChartEntry>();
            var source3 = new List<ChartEntry>();



            foreach (var s in DatabaseManager.GetAll())
            {
                source.Add(new ChartEntry(s.Temperature) {
                    ValueLabel = "i",
                    Color = SKColor.Parse("ff0000"),
                    TextColor = SKColor.Parse("ff0000"),
                    Label = s.DateTime
                });
                source2.Add(new ChartEntry(s.Humidity)
                {
                    ValueLabel = "i",
                    Color = SKColor.Parse("ff0000"),
                    TextColor = SKColor.Parse("ff0000"),
                    Label = s.DateTime
                });
                source3.Add(new ChartEntry(s.SoilMoisture)
                {
                    ValueLabel = "i",
                    Color = SKColor.Parse("ff0000"),
                    TextColor = SKColor.Parse("ff0000"),
                    Label = s.DateTime
                });
            }


            var Chart = new LineChart()
            {
                Entries = source,
            };
            var Chart2 = new LineChart()
            {
                Entries = source2
            };
            var Chart3 = new LineChart()
            {
                Entries = source3
            };
            this.chartView.Chart = Chart;
            this.chartView2.Chart = Chart2;
            this.chartView3.Chart = Chart3;
         


        }
    }
}