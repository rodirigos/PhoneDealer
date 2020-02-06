
using System.Threading.Tasks;
using ZXing.Mobile;

namespace PhoneDealer.Services
{
    public class LeitorQrService : ILeitorQrService
    {
        public LeitorQrService()
        {

        }

        public Task<string> GerarImageQrCode()
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> LerQrCode()
        {
            var optionsCustom = new MobileBarcodeScanningOptions();

            var scanner = new MobileBarcodeScanner()
            {
                TopText = "Escaneie o QR Code",
                BottomText = "Espere",
            };

            var scanResult = await scanner.Scan(optionsCustom);
            return scanResult.Text;
        }


    }
}
