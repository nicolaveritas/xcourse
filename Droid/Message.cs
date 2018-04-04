using System;
using FormsSample.Droid;
using FormsSample.Interfaces;
using Android.Widget;
using Android.App;

[assembly: Xamarin.Forms.Dependency(typeof(MessageImplentation))]
namespace FormsSample.Droid
{
    public class MessageImplentation : IMessage
    {
        public MessageImplentation()
        {
        }

        public void LongAlert(string message)
        {
            var toast = Toast.MakeText(Application.Context, message, ToastLength.Long);
            toast.Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}
