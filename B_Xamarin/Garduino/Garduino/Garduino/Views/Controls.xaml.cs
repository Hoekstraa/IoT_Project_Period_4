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
    public partial class Controls : ContentPage
    {

        private double Fan;
        private double Soil;
        private double Humidity;
        public Controls()
        {
            InitializeComponent();
        }

        public void FanSlider_DragCompleted(object sender, EventArgs e)
        {
             Fan = FanSlider.Value;
            FanLabel.Text =  Convert.ToString(FanSlider.Value);

        }

        public void SoilSlider_DragCompleted(object sender, EventArgs e)
        {
            Soil = SoilSlider.Value;
            SoilLabel.Text = Convert.ToString(SoilSlider.Value);
        }

        public void HumiditySlider_DragCompleted(object sender, EventArgs e)
        {
            Humidity = HumiditySlider.Value;
            Humiditylabel.Text =  Convert.ToString(HumiditySlider.Value);
        }

        public void FanSend_Clicked(object sender, EventArgs e)
        {
           
        }

        public void SoilSend_Clicked(object sender, EventArgs e)
        {

        }

        public void HumiditySend_Clicked(object sender, EventArgs e)
        {
             
        }
    }
}