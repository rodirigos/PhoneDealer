
using PhoneDealer.Models;
using PhoneDealer.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;
using ZXing.Net.Mobile.Forms;
using ZXing.QrCode;

namespace PhoneDealer.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaExibirQrCode : ContentPage
    {

        readonly IQrSaverService qrSaverService;
        ItemEmprestimo _itemEmprestimo;

        ZXingBarcodeImageView zXingBarcodeImageView;
        public PaginaExibirQrCode(ItemEmprestimo itemEmprestimo)
        {
            InitializeComponent();
            BindingContext = this;
            qrSaverService = DependencyService.Get<IQrSaverService>();
            _itemEmprestimo = itemEmprestimo;
            zXingBarcodeImageView = GenerateQR(_itemEmprestimo.Id);
            vwQrCode.Children.Add(zXingBarcodeImageView);
        }

        ZXingBarcodeImageView GenerateQR(string codeValue)
        {
            var qrCode = new ZXingBarcodeImageView
            {
                BarcodeFormat = BarcodeFormat.QR_CODE,
                BarcodeOptions = new QrCodeEncodingOptions
                {
                    Height = 350,
                    Width = 350
                },
                BarcodeValue = codeValue,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Start
            };
            // Workaround for iOS
            qrCode.WidthRequest = 350;
            qrCode.HeightRequest = 350;
            return qrCode;
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            qrSaverService.SalvarQrcode(_itemEmprestimo.Id, _itemEmprestimo.Descricao, _itemEmprestimo.Descricao);
        }

        private async void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            await App.navigationPage.PopAsync();
        }
    }


}