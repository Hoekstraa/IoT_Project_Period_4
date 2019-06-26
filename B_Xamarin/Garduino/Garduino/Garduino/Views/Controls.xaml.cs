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
        
        private int _fan;
        private int _soil;
        private int _humidity;
        public Controls()
        {
            InitializeComponent();
        }

        public void FanSlider_DragCompleted(object sender, EventArgs e)
        {
            _fan = Convert.ToInt32(Math.Round(FanSlider.Value));
            FanLabel.Text =  Convert.ToString(_fan);

        }

        public void SoilSlider_DragCompleted(object sender, EventArgs e)
        {
            _soil = Convert.ToInt32(Math.Round(SoilSlider.Value));

            SoilLabel.Text = Convert.ToString(_soil);
        }

        public void HumiditySlider_DragCompleted(object sender, EventArgs e)
        {
            _humidity = Convert.ToInt32(Math.Round(HumiditySlider.Value));
            Humiditylabel.Text =  Convert.ToString(_humidity);
        }

        public void FanSend_Clicked(object sender, EventArgs e)
        {
            CC.Conn.Set("fan1", _fan);
        }

        public void SoilSend_Clicked(object sender, EventArgs e)
        {
            CC.Conn.Set("gnd1", _soil);
        }

        public void HumiditySend_Clicked(object sender, EventArgs e)
        {
            CC.Conn.Set("hmd1", _humidity);
        }
    }
}