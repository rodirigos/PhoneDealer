using System.Threading.Tasks;

namespace PhoneDealer.Services
{
    public interface IQrSaverService
    {
        Task SalvarQrcode(string text, string filename, string description);
    }
}
