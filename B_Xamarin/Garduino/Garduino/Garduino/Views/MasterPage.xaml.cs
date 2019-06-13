using Garduino.Models;
using Plugin.Iconize;
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
    public partial class MasterPage : MasterDetailPage
    {
        List<MenuItems> menuItems = new List<MenuItems>(); 
        public MasterPage()
        {
            InitializeComponent();

            menuItems.Add(new MenuItems { Title = "Homepage" });
        }
    }
}