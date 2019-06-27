using Garduino.Models;
using System;
using System.Collections.Generic;
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

            menuItems.Add(new MenuItems { Title = "Homepage", Icon = "home.png", TargetType = typeof(MainPage) });
            menuItems.Add(new MenuItems { Title = "Graphs", Icon = "chart.png", TargetType = typeof(Statistics) });
            menuItems.Add(new MenuItems { Title = "Statistics", Icon = "chart.png", TargetType = typeof(Statistics2) });
            menuItems.Add(new MenuItems { Title = "Controls", Icon = "sliders.png", TargetType = typeof(Controls) });
            menuItems.Add(new MenuItems { Title = "Settings", Icon = "gear.png", TargetType = typeof(Settings) });

            NavigationDrawerList.ItemsSource = menuItems;

            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(MainPage)));
        }

        private void NavigationDrawerList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MenuItems)e.SelectedItem;
            Type page = item.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}