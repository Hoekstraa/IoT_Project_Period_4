using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CCPOC
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void B1_OnPressed(object sender, EventArgs e)
        {
            L1.Text = CC.Conn.Get("temp1");
        }

        private void B2_OnPressed(object sender, EventArgs e)
        {
            L2.Text = CC.Conn.Set("temp1", 5);
        }

        private void B3_OnPressed(object sender, EventArgs e)
        {
            L3.Text = CC.Conn.Set("temp1", 9001);
        }
    }
}
