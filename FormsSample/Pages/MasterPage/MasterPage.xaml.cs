using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using FormsSample.Pages.Info;

namespace FormsSample.Pages.MasterPage
{
    public partial class MasterPage : ContentPage
    {

        public ListView Menu 
        {
            get => menu;
        }

        public MasterPage()
        {
            InitializeComponent();
            Title = "Master";
            InitMenu();
        }

        public void InitMenu() 
        {
            var items = new ObservableCollection<MasterPageItem>();

            items.Add(new MasterPageItem
            {
                Title = "Main Page",
                TargetType = typeof(FormsSamplePage)
            });
            items.Add(new MasterPageItem
            {
                Title = "Info page",
                TargetType = typeof(InfoPage)
            });

            menu.ItemsSource = items;
        }
    }
}
