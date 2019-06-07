using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace week5
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        Connection connec = new Connection(); 

        public MainPage()
        {
            InitializeComponent();
            

        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            connec.OpenConnection();
            var response = connec.Recieve();

            
            string recieve = connec.Transmit("3");
            if (recieve == "\0")
                Button1.BackgroundColor = Color.Red; 
            else
                Button1.BackgroundColor = Color.FromHex("#66ff66");
                 
            connec.CloseConnection(); 
        }

        private void Button2_Clicked(object sender, EventArgs e)
        {
            connec.OpenConnection();
            string recieve = connec.Transmit("4");
            if (recieve == "\0")
                Button2.BackgroundColor = Color.Red;
            else 
                Button2.BackgroundColor = Color.FromHex("#66ff66");

            connec.CloseConnection();
        }
        private void Button3_Clicked(object sender, EventArgs e)
        {
            connec.OpenConnection();
            string recieve = connec.Transmit("5");
            if (recieve == "\0")
                Button3.BackgroundColor = Color.Red;
            else
                Button3.BackgroundColor = Color.FromHex("#66ff66");

            connec.CloseConnection();
        }
    }
}
