using Android.Graphics;
using Android.Support.V4.Print;
using PhoneDealer.Services;
using Plugin.CurrentActivity;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneDealer.Droid.Service.ImprimirService))]
namespace PhoneDealer.Droid.Service
{
    public class ImprimirService : IImprimirService
    {
        public bool PrintImage(Stream img)
        {
            PrintHelper photoPrinter = new PrintHelper(CrossCurrentActivity.Current.Activity);
            photoPrinter.ScaleMode = PrintHelper.ScaleModeFit;
            Bitmap bitmap = BitmapFactory.DecodeStream(img);
            photoPrinter.PrintBitmap("PrintSampleImg.jpg", bitmap);

            return true;
        }
    }
}