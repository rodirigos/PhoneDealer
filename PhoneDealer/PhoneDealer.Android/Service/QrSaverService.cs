using Android.Content;
using Android.Graphics;
using PhoneDealer.Services;
using Plugin.CurrentActivity;
using System.IO;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(PhoneDealer.Droid.Service.QrSaverService))]
namespace PhoneDealer.Droid.Service
{
    public class QrSaverService : IQrSaverService
    {

        public Task SalvarQrcode(string text, string filename, string description)
        {
            try
            {
                var barcodeWriter = new ZXing.Mobile.BarcodeWriter
                {
                    Format = ZXing.BarcodeFormat.QR_CODE,
                    Options = new ZXing.Common.EncodingOptions
                    {
                        Width = 1000,
                        Height = 1000,
                        Margin = 5
                    }
                };

                barcodeWriter.Renderer = new ZXing.Mobile.BitmapRenderer();
                var bitmap = barcodeWriter.Write(text);
                var stream = new MemoryStream();
                bitmap.Compress(Bitmap.CompressFormat.Png, 100, stream);  // this is the diff between iOS and Android
                stream.Position = 0;

                byte[] imageData = stream.ToArray();

                string filePath = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures) + $"/{filename}.png";


                System.IO.File.WriteAllBytes(filePath, imageData);
                //mediascan adds the saved image into the gallery
                var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);

                Intent sendIntent = new Intent(global::Android.Content.Intent.ActionSend);
                sendIntent.SetFlags(ActivityFlags.NewTask);
                sendIntent.PutExtra(global::Android.Content.Intent.ExtraText, description);

                sendIntent.SetType("image/*");

                //Uri apkURI = FileProvider.GetUriForFile(
                //            CrossCurrentActivity.Current.AppContext,
                //            CrossCurrentActivity.Current.AppContext.ApplicationContext
                //            .PackageName + ".provider",);
                // sendIntent.SetDataAndType(apkURI, mimeType);
                sendIntent.AddFlags(ActivityFlags.GrantReadUriPermission);

                sendIntent.PutExtra(Intent.ExtraStream, Android.Net.Uri.Parse("file://" + filePath));
                CrossCurrentActivity.Current.Activity.StartActivity(Intent.CreateChooser(sendIntent, "Compartilhando o qrcode"));
                return Task.FromResult(0);


            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}