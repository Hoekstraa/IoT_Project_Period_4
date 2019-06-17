using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Garduino.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Setup_Select : ContentPage
    {
        public Setup_Select()
        {
            InitializeComponent();
        }

        public void Button_Clicked(object sender, EventArgs e)
        {
            string buttonName = ((Button)sender).Text;
            var confirm = new Setup_Summary();

            switch (buttonName)
            {
                case "Cucumber":
                    {

                        Navigation.PushAsync(confirm);
                        break;
                    }
                case "Tomato":
                    {
                        Navigation.PushAsync(confirm);
                        break;
                    }
                case "Courgette":
                    {
                        Navigation.PushAsync(confirm);
                        break;
                    }
                case "Paprika":
                    {
                        Navigation.PushAsync(confirm);
                        break;
                    }
                case "Parsley":
                    {
                        Navigation.PushAsync(confirm);
                        break;
                    }
                case "Potato":
                    {
                        Navigation.PushAsync(confirm);
                        break;
                    }
                case "Radish":
                    {
                        Navigation.PushAsync(confirm);
                        break;
                    }
                case "Turnip":
                    {
                        Navigation.PushAsync(confirm);
                        break;
                    }
            }
        }
    }
}