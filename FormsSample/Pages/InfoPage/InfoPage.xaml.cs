using System;
using System.Collections.Generic;

using Xamarin.Forms;
using FormsSample.Pages.Info;
using FormsSample.Interfaces;

namespace FormsSample.Pages.Info
{
    public partial class InfoPage : ContentPage
    {
        public InfoPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var service = DependencyService.Get<IBatteryInfo>();

            var source = service.Source;
            var status = service.Status;

            var text = source + " - " + status;
            if (Device.RuntimePlatform == Device.Android) 
            {
                var mserivce = DependencyService.Get<IMessage>();

                Device.BeginInvokeOnMainThread(() =>
                {
                    mserivce.LongAlert(text);
                });

            }
            else {
                DisplayAlert("test", text, "OK");
            }
        }
    }
}
