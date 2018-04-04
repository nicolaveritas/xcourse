using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FormsSample.Pages.MasterPage
{
    public partial class RootPage : MasterDetailPage
    {
        public RootPage()
        {
            InitializeComponent();
            master.Menu.ItemTapped += OnItemSelected;
        }

        private void OnItemSelected(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as MasterPageItem;
            master.Menu.SelectedItem = null;
            if (item != null) 
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                IsPresented = false;
            }
        }
    }
}
