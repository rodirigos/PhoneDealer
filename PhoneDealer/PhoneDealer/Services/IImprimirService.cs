using System.IO;

namespace PhoneDealer.Services
{
    public interface IImprimirService
    {
        bool PrintImage(Stream img);
    }
}
