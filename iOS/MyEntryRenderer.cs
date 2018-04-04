using System;
using FormsSample.Components;
using Xamarin.Forms;
using FormsSample.iOS;
using Xamarin.Forms.Platform.iOS;
using UIKit;

[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]
namespace FormsSample.iOS
{
    public class MyEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null) 
            {
                Control.BackgroundColor = UIColor.Magenta;
            }
        }
    }
}
