using System;
using FormsSample.Components;
using FormsSample.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using System.Runtime.Remoting.Contexts;
using Android.Content;
using Java.Lang;

[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]
namespace FormsSample.Droid
{
    public class MyEntryRenderer : EntryRenderer
    {
        public MyEntryRenderer(Android.Content.Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null) 
            {
                Control.SetBackgroundColor(global::Android.Graphics.Color.DeepPink);
            }
        }
    }
}
