using System.Threading.Tasks;

namespace PhoneDealer.Services
{
    public interface ILeitorQrService
    {
        Task<string> LerQrCode();

        Task<string> GerarImageQrCode();
    }
}
