using System;
using System.Collections.Generic;

using Xamarin.Forms;
using SkiaSharp.Views.Forms;
using SkiaSharp;

namespace FormsSample.Pages.Canvas
{
    public partial class CanvasPage : ContentPage
    {
        public CanvasPage()
        {
            //InitializeComponent();

            var canvas = new SKCanvasView();

            Content = canvas;

            canvas.PaintSurface += Draw;

            //canvas.InvalidateSurface();
        }

        private void Draw(object sender, SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            canvas.Clear(SKColors.DarkSalmon);

            var paint = new SKPaint
            {
                Color = ((Color)Application.Current.Resources["CustomerAccent"]).ToSKColor()
            };
            canvas.DrawCircle(e.Info.Width / 2, 0, e.Info.Width / 2, paint);
        }
    }
}
