using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FormsSample
{
    public partial class NextPage : ContentPage
    {
        public NextPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            var spinner = new ActivityIndicator();
            spinner.IsRunning = true;
            grid.Children.Add(spinner, 0, 1);

            var data = await RestService.GetData();
            System.Diagnostics.Debug.WriteLine(data);
            dataLabel.Text = data;

            grid.Children.Remove(spinner);
        }
    }
}
