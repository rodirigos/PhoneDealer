using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using Xamarin.Forms;

namespace PhoneDealer.Control
{
    // 
    public class Circle : ContentView
    {

        #region Propriedades Vinculaveis

        public static BindableProperty SphereColorProperty = BindableProperty.Create(
            propertyName: "SphereColor",
            returnType: typeof(string),
            declaringType: typeof(Circle),
            defaultValue: "#000000",
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: ChangeColorValueChanged);

        public static BindableProperty SphereSizeProperty = BindableProperty.Create(
            propertyName: "SphereSize",
            returnType: typeof(int),
            declaringType: typeof(Circle),
            defaultBindingMode: BindingMode.TwoWay);

        public string SphereColor
        {
            get => (string)GetValue(SphereColorProperty);
            set
            {
                SetValue(SphereColorProperty, value);
                OnPropertyChanged();
                RaiseColorChanged();
                //canvasView.InvalidateSurface();
            }
        }

        public int SphereSize
        {
            get => (int)GetValue(SphereSizeProperty);
            set
            {
                SetValue(SphereSizeProperty, value);
                OnPropertyChanged();
            }
        }

        public EventHandler ColorChanged;

        private void RaiseColorChanged()
        {
            if (ColorChanged != null)
                ColorChanged(this, EventArgs.Empty);
        }

        #endregion

        private SKCanvasView canvasView;

        public Circle()
        {
            canvasView = new SKCanvasView();
            canvasView.PaintSurface += CanvasView_PaintSurface;
            Content = canvasView;
        }

        private SKPaint paint;
        private SKCanvas canvas;

        private void CanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            canvas = surface.Canvas;
            canvas.Clear();

            paint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = Color.FromHex(SphereColor).ToSKColor(),
                IsAntialias = true
            };
            canvas.DrawCircle(info.Width / 2, info.Height / 2, SphereSize, paint);
        }

        private static void ChangeColorValueChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Circle bindableCanvas = bindable as Circle;
            bindableCanvas?.canvasView.InvalidateSurface();
        }

    }
}
