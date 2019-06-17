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
	public partial class Setup_Confirm : ContentPage
	{
		public Setup_Confirm ()
        {
            InitializeComponent();
            //SelectVeg = Select;
        }

        public void Terug_Clicked()
        {
            //Navigation.PopAsync();
        }

        public void Verder_Clicked()
        {
            //Navigation.PushAsync(Setup_Select);
        }
    }
}