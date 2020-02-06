using PhoneDealer.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhoneDealer.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaConfiguracao : ContentPage
    {
        public PaginaConfiguracao()
        {
            InitializeComponent();
            BindingContext = new ConfiguracaoViewModel();
        }
    }
}